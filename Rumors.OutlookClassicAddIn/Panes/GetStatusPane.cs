using Rumors.Desktop.Common.Messages;
using System;
using System.Drawing;
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


        private async void btn_Clear_Click(object sender, EventArgs e)
        {
            richTextBox1.Text = string.Empty;
        }

        private async Task SendUserMessage()
        {
            
            RunSafe(() => progressBar1.Visible = true);

            await Task.Run(() =>
            {
                var request = txt_Input.Text;

                RunSafe(()=>
                {
                    richTextBox1.SelectionColor = Color.Blue;
                    richTextBox1.SelectionAlignment = HorizontalAlignment.Right;
                    richTextBox1.AppendText($"[User]: {txt_Input.Text}");
                    richTextBox1.AppendText($"{Environment.NewLine}");
                    richTextBox1.AppendText($"{Environment.NewLine}");

                    txt_Input.Text = string.Empty;
                });

                var response = ThisAddIn.PipeClient.Send(new ChatMessage { Text = request });
                if (response is ChatMessage message)
                {
                    RunSafe(() => {
                        richTextBox1.SelectionColor = Color.Black;
                        richTextBox1.SelectionAlignment = HorizontalAlignment.Left;
                        richTextBox1.AppendText($"[Agent]: {message.Text}");
                        richTextBox1.AppendText($"{Environment.NewLine}");
                        richTextBox1.AppendText($"{Environment.NewLine}");
                    });
                }
                else if (response is SimpleResponseMessage errorMessage) {
                    RunSafe(() => {
                        richTextBox1.SelectionColor = Color.Red;
                        richTextBox1.SelectionAlignment = HorizontalAlignment.Left;
                        richTextBox1.AppendText($"[Error]: {errorMessage.Message}");
                        richTextBox1.AppendText($"{Environment.NewLine}");
                        richTextBox1.AppendText($"{Environment.NewLine}");
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
