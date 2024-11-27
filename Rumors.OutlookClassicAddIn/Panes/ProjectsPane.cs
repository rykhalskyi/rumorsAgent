using Rumors.Desktop.Common.Dto;
using Rumors.Desktop.Common.Messages;
using Serilog;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Rumors.OutlookClassicAddIn.Panes
{
    public partial class ProjectsPane : UserControl, IPaneUserControl
    {
        public ProjectsPane()
        {
            InitializeComponent();

            cmb_Category.DisplayMember = "Name";
            cmb_Projects.DisplayMember = "Name";
        }
        
        public string Caption => "Rumors: Projects";
        private List<ProjectDto> _projectDtos = new List<ProjectDto>();
        private byte[] _screenshot;
        private List<EmailDto> _emailChains = new List<EmailDto>();
        private List<PersonDto> _persons = new List<PersonDto>();
        private DataTable _dataTable;
        private List<LogDto> _logDtos = new List<LogDto>();

        public async void OnPanelAdded()
        {
            await RequestData();
            Globals.ThisAddIn.Application.ActiveExplorer().SelectionChange += AddLogPane_SelectionChange;
        }

        private void AddLogPane_SelectionChange()
        {
        }

        private void btn_Update_Click(object sender, System.EventArgs e)
        {
            RequestData();
        }

        private async Task RequestData()
        {
            progressBar.Visible = true;
            var statusDtos = new List<StatusDto>();
            var personDtos = new List<PersonDto>();

            await Task.Run(() =>
            {
                var response = ThisAddIn.PipeClient.Send(new GetProjectsMessage());
                if (!(response is GetProjectsMessage message)) return;

                _projectDtos = message.Projects;
                statusDtos = message.Statuses;
                _persons = message.Persons;
                _emailChains = message.EmailChains;

            });

            cmb_Projects.Items.Clear();
            cmb_Projects.Items.AddRange(_projectDtos.ToArray());
            cmb_Projects.SelectedIndex = 0;

            FillCategories();

            await GetLogs();

            progressBar.Visible = false;
        }

        private async void CurrentProject_Changed(object sender, System.EventArgs e)
        {
            RunSafe(FillCategories);
            await GetLogs();
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
        
        public byte[] ImageToByteArray(Image image)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                // Save the image to the memory stream in the desired format (e.g., PNG)
                image.Save(ms, System.Drawing.Imaging.ImageFormat.Png);

                // Convert the memory stream to a byte array
                return ms.ToArray();
            }
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

        public void OnPanelOpened()
        {
        }

        private async void cmb_Category_SelectionChangeCommitted(object sender, EventArgs e)
        {
            await GetLogs();
        }
    }
}
