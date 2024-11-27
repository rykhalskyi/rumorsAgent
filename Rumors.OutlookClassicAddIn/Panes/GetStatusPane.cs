using Rumors.Desktop.Common.Dto;
using Rumors.Desktop.Common.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Rumors.OutlookClassicAddIn.Panes
{
    public partial class GetStatusPane : UserControl, IPaneUserControl
    {
        public GetStatusPane()
        {
            InitializeComponent();
            cmb_Category.DisplayMember = "Name";
            cmb_Projects.DisplayMember = "Name";

            cmb_Projects.SelectionChangeCommitted += Cmb_Projects_SelectionChangeCommitted;

        }

        private void Cmb_Projects_SelectionChangeCommitted(object sender, EventArgs e)
        {
            FillCategories();
        }

        public string Caption => "Ask AI Status";

        private List<ProjectDto> _projectDtos = new List<ProjectDto>();
        private List<PersonDto> _persons = new List<PersonDto>();

        public async void OnPanelAdded()
        {
            await RequestData();
        }

        private async Task RequestData()
        {
            progressBar1.Visible = true;
            await Task.Run(() =>
            {
                var response = ThisAddIn.PipeClient.Send(new GetProjectsMessage());
                if (!(response is GetProjectsMessage message)) return;

                _projectDtos = message.Projects;
                _persons = message.Persons;

            });

            cmb_Projects.Items.Clear();
            cmb_Projects.Items.AddRange(_projectDtos.ToArray());
            cmb_Projects.SelectedIndex = 0;

            FillCategories();
            progressBar1.Visible = false;
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

        public void OnPanelOpened()
        {
        }

        private async void btn_FindEmail_Click(object sender, EventArgs e)
        {
            RunSafe(() => progressBar1.Visible = true);

            if (cmb_Category.SelectedItem is CategoryDto selectedDto)
            {
                var response = ThisAddIn.PipeClient.Send(new GetStoryMessage()
                {
                    CategoryId = selectedDto.Id
                });
                if (!(response is GetStoryMessage message)) return;
                txtStory.Text = message.Story.Replace("\n",Environment.NewLine);
            }
            RunSafe(() => progressBar1.Visible = false);
        }

        private void txtStory_TextChanged(object sender, EventArgs e)
        {
            SetSendButton();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            SetSendButton();
        }

        private void SetSendButton()
        {
            btn_AskAi.Enabled = !string.IsNullOrEmpty(txtStory.Text) && !string.IsNullOrEmpty(txt_Question.Text);
        }

        private async void btn_AskAi_Click(object sender, EventArgs e)
        {
           RunSafe(()=> progressBar1.Visible = true);

            btn_AskAi.Enabled = false;
            txt_Chat.Text = $"[YOU:] {txt_Question.Text}{Environment.NewLine}{Environment.NewLine}{txt_Chat.Text}";

            var responseText = string.Empty;
            await Task.Run(()=>
            {
                var response = ThisAddIn.PipeClient.Send(new SendAiRequestMessage()
                {
                    Story = txtStory.Text,
                    Question = txt_Question.Text,
                });
                if (!(response is SendAiRequestMessage message)) return;
                 responseText = RestorePersons(message.Response);
            });
  
            txt_Chat.Text = $"[ChatGPT:] {responseText}{Environment.NewLine}{Environment.NewLine}{txt_Chat.Text}";
            txt_Question.Text = string.Empty;
            
           RunSafe(()=> progressBar1.Visible = false);
        }

        private string RestorePersons(string text)
        {
            text = text.Replace("\n",Environment.NewLine);

            string pattern = @"Person_[A-Za-z0-9]{8}";

            MatchCollection matches = Regex.Matches(text, pattern);

            foreach (Match match in matches)
            {
                var id = match.Value.Substring(7);
                var personName = _persons.FirstOrDefault(i=>i.Id.ToString().StartsWith(id)).Name;
                if (!string.IsNullOrEmpty(personName))
                {
                    text = text.Replace(match.Value, personName);
                }
            }

            return text;
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
    }
}
