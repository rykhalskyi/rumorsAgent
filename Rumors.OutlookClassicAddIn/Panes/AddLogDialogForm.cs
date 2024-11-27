using Microsoft.Office.Interop.Outlook;
using Rumors.Desktop.Common.Dto;
using Rumors.Desktop.Common.Messages;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace Rumors.OutlookClassicAddIn.Panes
{
    public partial class AddLogDialogForm : Form
    {
        public List<ProjectDto> ProjectDtos { get; set; }
        public List<PersonDto> Persons { get; set; }
        public List<StatusDto> Statuses {  get; set; }
        public ProjectDto SelectedProject { get; set; }
        public CategoryDto SelectedCategory { get; set; }
        public MailItem CurrentMail { get; set; }

        private byte[] _screenshot;

        public AddLogDialogForm()
        {
            InitializeComponent();
            cmb_Category.DisplayMember = "Name";
            cmb_Projects.DisplayMember = "Name";
            cmb_Persons.DisplayMember = "Email";
            cmb_Statuses.DisplayMember = "Name";
            img_Screenshot.SizeMode = PictureBoxSizeMode.Zoom;
        }

        public void Init()
        {
            cmb_Projects.Items.AddRange(ProjectDtos.ToArray());
            cmb_Projects.SelectedIndex = ProjectDtos.IndexOf(SelectedProject);
            FillCategories();

            txt_Message.Text = CurrentMail.Subject;
            cmb_Persons.Items.AddRange(Persons.Where(i => i.ProjectId == null || i.ProjectId.Value == SelectedProject.Id).ToArray());

            var email = cmb_Persons.Items.Cast<PersonDto>().FirstOrDefault(i => i.Email.Equals(CurrentMail.SenderEmailAddress));

            if (email != null)
            {
                cmb_Persons.SelectedItem = email;
            }

            cmb_Statuses.Items.AddRange(Statuses.ToArray());
            cmb_Statuses.SelectedIndex = 0;

            ShowColor();
        }

        private void btn_addPerson_Click(object sender, EventArgs e)
        {
            if (!(cmb_Projects.SelectedItem is ProjectDto projectDto)) return;

            var form = new AddPersonForm()
            {
                Projects = ProjectDtos.ToList(),
                Email = CurrentMail.SenderEmailAddress,
                PersonName = CurrentMail.SenderName,
                SelectedIndex = ProjectDtos.IndexOf(projectDto)
            };

            form.Init();
            form.ShowDialog();

            if (form.DialogResult == DialogResult.OK)
            {
                Close(); 
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
                    cmb_Category.SelectedIndex = categories.ToList().IndexOf(SelectedCategory);
                }
            };
        }

        private void ShowColor()
        {
            if (cmb_Statuses.SelectedItem is StatusDto statusDto)
            {
                var color = ColorTranslator.FromHtml(statusDto.RgbColor);
                Bitmap bitmap = new Bitmap(40, 20);
                using (var g = Graphics.FromImage(bitmap))
                {
                    g.Clear(color);
                }

                pbx_Status.Image = bitmap;
            }
        }

        private void cmb_Statuses_SelectionChangeCommitted(object sender, EventArgs e)
        {
            ShowColor();
        }

        private void SetSaveButtonEnabled()
        {
            btn_Save.Enabled = !string.IsNullOrEmpty(txt_Message.Text) &&
                    (!cbx_CreateVersion.Checked ||
                    (!string.IsNullOrEmpty(txt_VersionName.Text) && _screenshot != null)
                );
        }

        private void txt_Message_TextChanged(object sender, EventArgs e)
        {
            SetSaveButtonEnabled();
        }

        private void cbx_CreateVersion_SizeChanged(object sender, EventArgs e)
        {
            txt_VersionName.Enabled = cbx_CreateVersion.Checked;
            btn_clearImage.Enabled = cbx_CreateVersion.Checked;
            btn_InsertImage.Enabled = cbx_CreateVersion.Checked;

            SetSaveButtonEnabled();
        }

        #region Save

        private void btn_Save_Click(object sender, EventArgs e)
        {
            if (!(cmb_Category.SelectedItem is CategoryDto category)) return;
            if (!(cmb_Persons.SelectedItem is PersonDto person)) return;
            if (!(cmb_Statuses.SelectedItem is StatusDto status)) return;

            var message = new SaveLogMessage
            {
                Message = txt_Message.Text,
                CategoryId = category.Id,
                PersonId = person.Id,
                StatusId = status.Id,
                AddVersion = cbx_CreateVersion.Checked,
            };

            if (message.AddVersion)
            {
                message.VersionName = txt_VersionName.Text;
                message.Image = _screenshot;
            }

            FillEmailFields(message);

            var response = ThisAddIn.PipeClient.Send(message);

            if (response is SimpleResponseMessage responseMessage)
            {
                MessageBox.Show(responseMessage.Message, "Log saved");

                txt_Message.Text = "";
                txt_VersionName.Text = "";
                cbx_CreateVersion.Checked = false;
                _screenshot = null;
                img_Screenshot.Image = null;

                this.Close();
            }
            else
            {
                MessageBox.Show("Error occured on save");
            }
        }
      

        private void FillEmailFields(SaveLogMessage message)
        {
            var selection = Globals.ThisAddIn.Application.ActiveExplorer().Selection;


            if (selection.Count > 0 && selection[1] is Microsoft.Office.Interop.Outlook.MailItem)
            {
                var mailItem = selection[1] as Microsoft.Office.Interop.Outlook.MailItem;

                message.ConversationId = mailItem.ConversationID;
                message.EmailSubject = mailItem.Subject;
                message.EmailBody = mailItem.Body;
                message.EmailId = mailItem.EntryID;
                message.EmailDate = DateTime.SpecifyKind(mailItem.ReceivedTime, DateTimeKind.Local);

                var conversation = mailItem.GetConversation();
                var table = conversation.GetTable();

                message.ChainIds = new List<string>();
                while (!table.EndOfTable)
                {
                    var row = table.GetNextRow();
                    message.ChainIds.Add(row["EntryID"]);
                }
            }
        }

        #endregion

        #region Image

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

        #endregion

        private void btn_InsertImage_Click(object sender, EventArgs e)
        {
            if (Clipboard.ContainsImage())
            {
                var image = Clipboard.GetImage();
                img_Screenshot.Image = image;
                _screenshot = ImageToByteArray(image);
            }
            SetSaveButtonEnabled();
        }

        private void btn_clearImage_Click(object sender, EventArgs e)
        {
            img_Screenshot.Image = null;
            _screenshot = null;
            SetSaveButtonEnabled();
        }

        private void cbx_CreateVersion_CheckedChanged(object sender, EventArgs e)
        {
            txt_VersionName.Enabled = cbx_CreateVersion.Checked;
            btn_clearImage.Enabled = cbx_CreateVersion.Checked;
            btn_InsertImage.Enabled = cbx_CreateVersion.Checked;

            SetSaveButtonEnabled();
        }

        
    }
}
