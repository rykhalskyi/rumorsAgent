using System;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Rumors.OutlookClassicAddIn.Panes
{
    public partial class GetStatusPane : UserControl, IPaneUserControl
    {
        public GetStatusPane()
        {
            InitializeComponent();

        }


        public string Caption => "Agent";


        public async void OnPanelAdded()
        {
            await RequestData();
        }

        private async Task RequestData()
        {
        }


        public void OnPanelOpened()
        {
        }


        private async void btn_AskAi_Click(object sender, EventArgs e)
        {
           //RunSafe(()=> progressBar1.Visible = true);

           // btn_AskAi.Enabled = false;
           // txt_Chat.Text = $"[YOU:] {txt_Question.Text}{Environment.NewLine}{Environment.NewLine}{txt_Chat.Text}";

           // var responseText = string.Empty;
           // await Task.Run(()=>
           // {
           //     var response = ThisAddIn.PipeClient.Send(new SendAiRequestMessage()
           //     {
           //         Story = txtStory.Text,
           //         Question = txt_Question.Text,
           //     });
           //     if (!(response is SendAiRequestMessage message)) return;
           //      responseText = RestorePersons(message.Response);
           // });
  
           // txt_Chat.Text = $"[ChatGPT:] {responseText}{Environment.NewLine}{Environment.NewLine}{txt_Chat.Text}";
           // txt_Question.Text = string.Empty;
            
           //RunSafe(()=> progressBar1.Visible = false);
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
