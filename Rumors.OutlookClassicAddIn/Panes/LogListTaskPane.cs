using Microsoft.Office.Interop.Outlook;
using Rumors.Desktop.Common.Dto;
using Rumors.Desktop.Common.Helpers;
using Rumors.Desktop.Common.Messages;
using Rumors.OutlookClassicAddIn.etc;
using Serilog;
using stdole;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Action = System.Action;

namespace Rumors.OutlookClassicAddIn.Panes
{
    public partial class LogListTaskPane : UserControl, IPaneUserControl
    {
        private List<ProjectDto> _projectDtos = new List<ProjectDto>();
        private List<LogDto> _logDtos = new List<LogDto>();
        private List<EmailDto> _emailChains = new List<EmailDto>();
        private List<PersonDto> _persons = new List<PersonDto>();
        private List<StatusDto> _statuses = new List<StatusDto>();

        private DataTable _dataTable;
        private ProjectDto _oldProject;
        private CategoryDto _oldCategory;

        private string _currentlyClickedEmail;
        private static readonly SemaphoreSlim _semaphore = new SemaphoreSlim(1, 1);
        private readonly AsyncLock _requestDataAsyncLock = new AsyncLock();

        private EmailTaskPaneStatus _currentState = EmailTaskPaneStatus.Unknown;

        private MailItem CurrentMail => GetCurrentMailItem();
        private Explorer _activeExplorer;
        private Explorer ActiveExplorer
        {
            get
            {
                var explorer = Globals.ThisAddIn.Application.ActiveExplorer();
                if (_activeExplorer != explorer)
                {
                    if (_activeExplorer != null)
                        _activeExplorer.SelectionChange -= Email_SelectionChange;

                    _activeExplorer = explorer;

                    _activeExplorer.SelectionChange += Email_SelectionChange;
                    Log.Information($"Set new active explorer {_activeExplorer.GetHashCode()}");
                }
                return _activeExplorer;
            }
        }

        public LogListTaskPane()
        {
            InitializeComponent();

            cmb_Category.DisplayMember = "Name";
            cmb_Projects.DisplayMember = "Name";
            cmb_Category.SelectionChangeCommitted += Cmb_Category_SelectedValueChanged;
            cmb_Projects.SelectionChangeCommitted += Cmb_Projects_SelectionChangeCommitted;

            dataGridView1.CellFormatting += DataGridView1_CellFormatting;
        }

        public string Caption => "Rumors: Email";

        public async void OnPanelAdded()
        {
            //this is important for initial set of active explorer
            var explorer = ActiveExplorer;

            SetPaneState(EmailTaskPaneStatus.Unknown);

            await RequestData();
            await RecalculatePageState();
        }

        private async void Email_SelectionChange()
        {
            await _semaphore.WaitAsync();
            try
            {
                if (string.IsNullOrEmpty(_currentlyClickedEmail) ||
                    !_currentlyClickedEmail.Equals(CurrentMail.EntryID))
                {
                    _currentlyClickedEmail = CurrentMail.EntryID;
                    //  Log.Information($"Open >> {CurrentMail.EntryID}");
                    await RecalculatePageState();
                }
            }
            finally
            {
                _semaphore.Release();
            }

        }

        private async Task RequestData()
        {
            using (await _requestDataAsyncLock.LockAsync())
            {
                progressBar.Style = ProgressBarStyle.Marquee;

                _oldProject = cmb_Projects.SelectedItem as ProjectDto;
                _oldCategory = cmb_Category.SelectedItem as CategoryDto;

                await Task.Run(() =>
                {
                    var response = ThisAddIn.PipeClient.Send(new GetProjectsMessage());
                    if (!(response is GetProjectsMessage message)) return;

                    _projectDtos = message.Projects;
                    _statuses = message.Statuses;
                    _persons = message.Persons;
                    _emailChains = message.EmailChains;

                });

                cmb_Projects.Items.Clear();
                cmb_Projects.Items.AddRange(_projectDtos.ToArray());
                cmb_Projects.SelectedIndex = 0;

                if (_oldProject != null)
                {
                    var prj = cmb_Projects.Items.Cast<ProjectDto>().FirstOrDefault(i => i.Id == _oldProject.Id);
                    if (prj != null)
                    {
                        cmb_Projects.SelectedIndex = cmb_Projects.Items.IndexOf(prj);
                    }
                }

                FillCategories();

                if (_oldCategory != null)
                {
                    var ctg = cmb_Category.Items.Cast<CategoryDto>().FirstOrDefault(i => i.Id == _oldCategory.Id);
                    if (ctg != null)
                    {
                        cmb_Category.SelectedIndex = cmb_Category.Items.IndexOf(ctg);
                    }
                }

                await GetLogs();

                progressBar.Style = ProgressBarStyle.Continuous;
            }
        }

        private void FillCategories()
        {
            if (cmb_Projects.SelectedItem is ProjectDto selectedDto)
            {
                cmb_Category.Items.Clear();
                cmb_Category.Text = "";

                var categories = selectedDto.Categories.ToArray();
                if (categories.Any())
                {
                    cmb_Category.Items.AddRange(categories);
                    cmb_Category.SelectedIndex = 0;
                }
            };
        }

        private async void Cmb_Category_SelectedValueChanged(object sender, EventArgs e)
        {
            SetEmaiFoundState(false);
            await GetLogs();
        }

        private async Task GetLogs()
        {
            progressBar.Style = ProgressBarStyle.Marquee;

            try
            {
                _dataTable = new DataTable();
                dataGridView1.DataSource = _dataTable;

                if (cmb_Category.SelectedItem is CategoryDto category)
                {
                    await Task.Run(() =>
                    {
                        var response = ThisAddIn.PipeClient.Send(new GetLogsMessage() { CategoryId = category.Id });
                        if (!(response is GetLogsMessage message)) return;

                        _logDtos = message.Logs.OrderByDescending(i => i.EmailDateTime).ToList();
                    });

                    InitializeDataGrid();
                }
            }
            catch (System.Exception ex)
            {
                Log.Error(ex, "GetLogs");
            }

            RunSafe(() => progressBar.Style = ProgressBarStyle.Continuous);
        }

        private void InitializeDataGrid()
        {
            if (InvokeRequired)
            {
                Invoke(new MethodInvoker(InitializeDataGrid));
                return;
            }

            if (!_logDtos.Any()) return;

            _dataTable = new DataTable();
            _dataTable.Columns.Add("Id", typeof(Guid));
            _dataTable.Columns.Add("Date", typeof(string));
            _dataTable.Columns.Add("Status", typeof(string));
            _dataTable.Columns.Add("Message", typeof(string));
            _dataTable.Columns.Add("Color", typeof(string));
            _dataTable.Columns.Add("EmailId", typeof(string));


            dataGridView1.DataSource = _dataTable;
            dataGridView1.Columns["Id"].Visible = false;
            dataGridView1.Columns["Color"].Visible = false;
            dataGridView1.Columns["EmailId"].Visible = false;

            foreach (var item in _logDtos.OrderByDescending(i => i.EmailDateTime))
            {
                _dataTable.Rows.Add(item.Id, item.EmailDateTime.ToString(), item.Status.Name, item.Message, item.Status.RgbColor, item.EmailId);
            }

        }

        private async void Cmb_Projects_SelectionChangeCommitted(object sender, EventArgs e)
        {
            try
            {
                SetEmaiFoundState(false);

                RunSafe(FillCategories);
                await GetLogs();
            }
            catch (System.Exception ex)
            {
                Log.Error(ex, "Cmb_Projects_SelectionChangeCommitted");
            }
        }

        private void DataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            try
            {
                var dataGridView = sender as DataGridView;
                if (dataGridView == null) return;

                var row = dataGridView.Rows[e.RowIndex];

                var colorString = row.Cells["Color"]?.Value?.ToString();
                if (string.IsNullOrEmpty(colorString)) return;

                var color = ColorTranslator.FromHtml(colorString);
                if (color == null) return;

                row.DefaultCellStyle.BackColor = color;
            }
            catch (System.Exception ex)
            {
                Log.Error(ex, "Cell Formating");
            }
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                var selectedRow = dataGridView1.SelectedRows[0];

                if (Guid.TryParse(selectedRow.Cells["Id"].Value?.ToString(), out var id))
                {
                    var selectedLog = _logDtos.FirstOrDefault(i => i.Id == id);
                    if (selectedLog != null)
                    {
                        SetLogDetails(selectedLog);
                    }
                }
                var hasEmailId = !string.IsNullOrEmpty(selectedRow.Cells["EmailId"].Value?.ToString());
                SetEmaiFoundState(hasEmailId);
            }
        }

        private void SetLogDetails(LogDto log)
        {
            var sb = new StringBuilder(log.CreatedAt.ToString());
            sb.AppendLine();
            sb.AppendLine($"Status {log.Status.Name} set by {log.Person.Name}");
            sb.AppendLine($"with comment \" {log.Message}\" ");
            sb.AppendLine();
            sb.AppendLine($"Conversation Id: {log.ConversationId}");
            sb.AppendLine($"Entry Id: {log.EmailId}");
            txt_LogDetails.Text = sb.ToString();
        }

        private void txt_Search_TextChanged(object sender, EventArgs e)
        {
            string filter = txt_Search.Text.Trim().ToLower();
            if (string.IsNullOrEmpty(filter))
            {
                dataGridView1.DataSource = _dataTable;
            }
            else
            {
                var filteredTable = _dataTable.Clone();
                foreach (DataRow row in _dataTable.Select($"Message LIKE '%{filter}%'"))
                {
                    filteredTable.ImportRow(row);
                }
                dataGridView1.DataSource = filteredTable;
            }
        }

        private bool PreSelectCategory()
        {
            var category = _emailChains.FirstOrDefault(i => i.ConversationIds.Contains(CurrentMail.ConversationID));

            if (category == null) return false;

            var project = _projectDtos.FirstOrDefault(i => i.Categories.Any(j => j.Id == category.CategoryId));
            if (project == null) return false;

            cmb_Projects.SelectedItem = cmb_Projects.Items.OfType<ProjectDto>().FirstOrDefault(i => i.Id == project.Id);

            FillCategories();

            cmb_Category.SelectedItem = cmb_Category.Items.OfType<CategoryDto>().FirstOrDefault(i => i.Id == category.CategoryId);


            return true;
        }

        private void SelectLog()
        {
            SetEmaiFoundState(false);

            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                row.Selected = false;
            }

            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                var cellValue = row.Cells["EmailId"].Value;
                if (cellValue == null) break;

                var emailId = cellValue.ToString();

                var rowFound = !string.IsNullOrEmpty(emailId)
                    && emailId.Equals(CurrentMail.EntryID, StringComparison.OrdinalIgnoreCase);

                if (rowFound)
                {
                    row.Selected = true;
                    SetEmaiFoundState(true);
                    SetPaneState(EmailTaskPaneStatus.CheckedIn);

                    var colorString = row.Cells["Color"]?.Value?.ToString();
                    if (string.IsNullOrEmpty(colorString)) break;
                    
                    panel_logStatus.BackColor = ColorTranslator.FromHtml(colorString);
                    var message = row.Cells["Message"]?.Value.ToString();
                    label_Status.Text = message;
                    toolTip1.SetToolTip(label_Status, message);

                    break;
                }
            }

        }

        private void SetEmaiFoundState(bool found)
        {
            contextMenuStrip1.Items[0].Enabled = found;
        }

        private MailItem GetCurrentMailItem()
        {
            var selection = ActiveExplorer.Selection;
            if (selection.Count > 0 && selection[1] is MailItem mailItem)
            {
                return mailItem;
            }
            return null;
        }

        private async void RerunButton_Click(object sender, EventArgs e)
        {
            switch (_currentState)
            {
                case EmailTaskPaneStatus.Unknown:
                    await RecalculatePageState();
                    break;
                case EmailTaskPaneStatus.Found:
                case EmailTaskPaneStatus.NotFound:
                    CheckIn();
                    break;
                case EmailTaskPaneStatus.CheckedIn:
                default:
                    break;
            }
        }

        private async Task RecalculatePageState()
        {
            try
            {
                if (!PreSelectCategory())
                {
                    SetPaneState(EmailTaskPaneStatus.NotFound);
                    return;
                }

                SetPaneState(EmailTaskPaneStatus.Found);

                await GetLogs();
                SelectLog();
            }
            catch (System.Exception ex)
            {
                Log.Error(ex, "RerunButton_Click");
            }
        }

        private async void btn_Reload_Click(object sender, EventArgs e)
        {
            await RequestData();
            await RecalculatePageState();
        }

        private void RunSafe(Action action)
        {
            if (InvokeRequired)
            {
                Invoke(new MethodInvoker(action));
            }
            else
            {
                action();
            }
        }

        private void btn_FindEmail_Click(object sender, EventArgs e)
        {
            FindAndOpenEmail();
        }

        private void FindAndOpenEmail()
        {
            try
            {
                var entryId = string.Empty;
                if (dataGridView1.SelectedRows[0] != null)
                {
                    var cellValue = dataGridView1.SelectedRows[0].Cells["EmailId"].Value;
                    if (cellValue != null)
                    {
                        entryId = cellValue.ToString();
                    }
                }

                if (string.IsNullOrEmpty(entryId)) return;

                var outlookNamespace = Globals.ThisAddIn.Application.GetNamespace("MAPI");

                MailItem mailItem = (MailItem)outlookNamespace.GetItemFromID(entryId);

                if (mailItem != null)
                {
                    mailItem.Display();
                }
                else
                {
                    MessageBox.Show("Mail item not found.");
                }
            }
            catch (System.Exception ex)
            {
                Log.Error(ex, "FindEmail");
            }
        }

        private void btn_AddLog_Click(object sender, EventArgs e)
        {
            CheckIn();
        }

        private void CheckIn()
        {
            if (!(cmb_Category.SelectedItem is CategoryDto category)) return;
            if (!(cmb_Projects.SelectedItem is ProjectDto project)) return;

            if (CheckLogExist(CurrentMail.EntryID)) return;


            var dialog = new AddLogDialogForm()
            {
                ProjectDtos = _projectDtos,
                Persons = _persons,
                Statuses = _statuses,
                SelectedCategory = category,
                SelectedProject = project,
                CurrentMail = CurrentMail
            };

            dialog.Init();
            dialog.ShowDialog();
        }


        private bool CheckLogExist(string emailId)
        {
            var message = new CheckLogExistMessage { EmailId = emailId };
            var response = ThisAddIn.PipeClient.Send(message) as CheckLogExistMessage;
            if (string.IsNullOrEmpty(response.Message))
                return false;

            MessageBox.Show(response.Message, "Log Exists");
            return true;
        }

        public void OnPanelOpened()
        {
        }

        private void SetPaneState(EmailTaskPaneStatus status)
        {
            var state = EmailTaskPanelStates.Get(status);
            lbl_status.Text = state.Label;
            panelStatus.BackColor = Color.FromArgb(state.Red, state.Green, state.Blue);
            btn_ActionBtn.Text = state.Button;

            _currentState = status;

            if (_currentState != EmailTaskPaneStatus.CheckedIn)
            {
                dataGridView1.ClearSelection();
            }
            
            groupBox_Log.Visible = _currentState == EmailTaskPaneStatus.CheckedIn;
            btn_ActionBtn.Enabled = _currentState != EmailTaskPaneStatus.CheckedIn;

            if (_currentState == EmailTaskPaneStatus.NotFound ||
                _currentState == EmailTaskPaneStatus.Unknown)
            {
                cmb_Projects.SelectedItem = null;
                cmb_Category.SelectedItem = null;
                dataGridView1.DataSource = null;
            }
        }

        private void findEmailToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FindAndOpenEmail();
        }

        private void dataGridView1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                // Get the row index where the click occurred
                var hitTestInfo = dataGridView1.HitTest(e.X, e.Y);

                if (hitTestInfo.Type == DataGridViewHitTestType.Cell)
                {
                    // Select the clicked row
                    dataGridView1.ClearSelection();
                    dataGridView1.Rows[hitTestInfo.RowIndex].Selected = true;

                    // Show the context menu at the mouse location
                    contextMenuStrip1.Show(dataGridView1, new Point(e.X, e.Y));
                }
            }
        }
    }
}
