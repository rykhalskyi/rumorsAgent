using Rumors.Desktop.Common.Dto;
using Rumors.Desktop.Common.Messages;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Rumors.OutlookClassicAddIn.Panes
{
    public partial class AddPersonForm : Form
    {
        public List<ProjectDto> Projects { get; set; } = new List<ProjectDto>();
        public int SelectedIndex { get; set; } = 0;

        public string Email { get; set; } = string.Empty;
        public string PersonName { get; set; } = string.Empty;

        public AddPersonForm()
        {
            InitializeComponent();
        }

        public void Init()
        {
            cmb_Project.DisplayMember = "Name";

            tbx_Email.Text = Email;
            tbx_Name.Text = PersonName;
            
            cmb_Salutation.SelectedIndex = 0;

            cmb_Project.Items.Clear();
            cmb_Project.Items.AddRange(Projects.ToArray());

            cmb_Project.SelectedIndex = SelectedIndex;
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void cbx_Global_CheckedChanged(object sender, EventArgs e)
        {
            cmb_Project.Enabled = !cbx_Global.Checked;
        }

        private void field_TextChanged(object sender, EventArgs e)
        {
            btn_Save.Enabled = !string.IsNullOrEmpty(tbx_Email.Text) 
                && !string.IsNullOrEmpty(tbx_Comapny.Text)
                && !string.IsNullOrEmpty(tbx_Name.Text)
                && !string.IsNullOrEmpty(cmb_Salutation.Text);
        }

        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void btn_Save_Click(object sender, EventArgs e)
        {
            var project = cmb_Project.SelectedItem as ProjectDto;
            var response = ThisAddIn.PipeClient.Send(new AddPersonMessage
            {
                Salutation = GetSalutation(cmb_Salutation.Text),
                Name = tbx_Name.Text,
                Company = tbx_Comapny.Text,
                Email = tbx_Email.Text,
                Phone = tbx_Phone.Text,
                Project = cbx_Global.Checked ? null : project?.Id
            }); ;

            DialogResult = DialogResult.Cancel;
            if (response is SimpleResponseMessage message)
            {
                MessageBox.Show(message.Message);
                if (message.Successful) {
                    DialogResult = DialogResult.OK;
                    Close(); 
                } 
            }

            
        }

        private int GetSalutation(string salutationString)
        {
            switch (salutationString)
            {
                case "Mr.": return 1;
                case "Ms.": return 2;
                default: return 0;
            }
        }
    }
}
