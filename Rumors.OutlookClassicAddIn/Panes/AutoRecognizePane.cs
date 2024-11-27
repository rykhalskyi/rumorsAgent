
using Microsoft.Office.Interop.Outlook;
using Rumors.Desktop.Common.Dto;
using Rumors.Desktop.Common.Messages;
using Rumors.OutlookClassicAddIn.emailLogic;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Rumors.OutlookClassicAddIn.Panes
{
    public partial class AutoRecognizePane : UserControl, IPaneUserControl
    {
        public AutoRecognizePane()
        {
            InitializeComponent();
        }

        public string Caption => "Rumors: Auto";

        #region Events
        public void OnPanelAdded()
        {
            //throw new NotImplementedException();
        }

        public void OnPanelOpened()
        {
            //throw new NotImplementedException();
        }

        private void button1_Click(object sender, System.EventArgs e)
        {
            var conversationEntries = GetConversation();
            if (conversationEntries == null) return;
            var sb = new StringBuilder();
            foreach ( var item in conversationEntries.Emails.OrderBy(i=>i.CreationTime))
            {
                sb.AppendLine("---------------//------------------");
                sb.AppendLine(item.CreationTime.ToString());
                sb.AppendLine(item.From);
                sb.AppendLine(item.Subject);
                sb.AppendLine(item.Body);
                foreach (var att in item.Attachments)
                {
                    sb.AppendLine($"- {att.Name}: {att.File.Length}");
                }

            }

            txb_out.Text = sb.ToString();
        }

        private async void button2_Click(object sender, System.EventArgs e)
        {
            var conversation = GetConversation();
            var message = new AutoAnalyzeMessage
            {
                Conversations = new ConversationDto[] { conversation }
            };

            await Task.Run(() =>
            {
                var response = ThisAddIn.PipeClient.Send(message);
                if (!(response is AutoAnalyzeMessage responseMessage)) return;

                var sb = new StringBuilder();
                foreach (var item in responseMessage.Sugestions) {
                    sb.AppendLine("------------ // Response // ------------ ");
                    sb.AppendLine($"Suggested Period: {item.Period}");
                    sb.AppendLine($"Suggested Project: {item.ProjectName}");
                    sb.AppendLine($"Suggested Category: {item.CategoryName}");

                    foreach (var log in item.LogSugestions)
                    {
                        sb.AppendLine("..........");
                        sb.AppendLine($"Status: {log.Status}");
                        sb.AppendLine($"From: {log.Email.From}");
                        sb.AppendLine($"Message: {log.Email.Body}");
                    }
                     }
                txb_out.Text = sb.ToString();
            });

        }
        #endregion


        private ConversationDto GetConversation()
        {
            var selection = Globals.ThisAddIn.Application.ActiveExplorer().Selection;
            if (selection.Count < 1 || !(selection[1] is MailItem mailItem)) return null;
            return ConversationUtils.GetConversation(mailItem);
        }

        
    }
}
