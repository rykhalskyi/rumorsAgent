using Rumors.Desktop.Common.Messages;
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
            await SendUserMessage();
        }

        private async Task SendUserMessage()
        {
            RunSafe(() => progressBar1.Visible = true);
            await Task.Run(() =>
            {
                var response = ThisAddIn.PipeClient.Send(new ChatMessage { Text = txt_Input.Text });
                if (response is ChatMessage message)
                {
                    RunSafe(() => { 
                        txt_Chat.Text = $"[Agent:] {message.Text}{Environment.NewLine}{Environment.NewLine}{txt_Chat.Text}";
                        txt_Input.Text = string.Empty;
                    });
                }
            });

            RunSafe(() => progressBar1.Visible = false);
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

        private void txt_Input_TextChanged(object sender, EventArgs e)
        {
            btn_SendMessage.Enabled = !string.IsNullOrWhiteSpace(txt_Input.Text);
        }

        private async void txt_Input_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;

                if (!string.IsNullOrWhiteSpace(txt_Input.Text))
                    await SendUserMessage();
                
            }
        }
    }
}
