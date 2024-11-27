using Microsoft.Office.Interop.Outlook;
using System.Text;
using System.Windows.Forms;
using Outlook = Microsoft.Office.Interop.Outlook;

namespace Rumors.OutlookClassicAddIn.Panes
{
    public partial class InfoTaskPane : UserControl, IPaneUserControl
    {
        public InfoTaskPane()
        {
            InitializeComponent();
        }

        public string Caption => "Rumors: Email Info";

        public void OnPanelAdded()
        {
            Globals.ThisAddIn.Application.ActiveExplorer().SelectionChange += AddLogPane_SelectionChange;
            GetEmailInfo();
        }

        private void AddLogPane_SelectionChange()
        {
            GetEmailInfo();
        }

        private void GetEmailInfo()
        {
            var selection = Globals.ThisAddIn.Application.ActiveExplorer().Selection;

            if (selection.Count > 0 && selection[1] is Outlook.MailItem mailItem)
            {
                var sb = new StringBuilder();
                sb.AppendLine("From:");
                sb.AppendLine($"{mailItem.SenderEmailAddress} ({mailItem.SenderName})");
                sb.AppendLine();
                sb.AppendLine("To:");
                sb.AppendLine($"{mailItem.To}");
                sb.AppendLine($"Recieved by: {mailItem.ReceivedByName}");
                sb.AppendLine();
                sb.AppendLine($"Subject: {mailItem.Subject}");
                sb.AppendLine($"Recieved: {mailItem.ReceivedTime}");
                sb.AppendLine($"CC: {mailItem.CC}");
                sb.AppendLine($"BCC: {mailItem.BCC}");
                sb.AppendLine();
                sb.AppendLine($"Email ID:");
                sb.AppendLine(mailItem.EntryID);
                sb.AppendLine();
                sb.AppendLine($"Conversation ID:");
                sb.AppendLine(mailItem.ConversationID);
                sb.AppendLine();
                sb.AppendLine($"Sender ID:");
                sb.AppendLine(mailItem.Sender.ID);
                sb.AppendLine();
                sb.AppendLine($"Reciever ID: ");
                sb.AppendLine(mailItem.ReceivedByEntryID);
                txt_Info.Text = sb.ToString();

                GetConversationInfo(mailItem);
            }
        }

        private void GetConversationInfo(MailItem mailItem)
        {
            var sb = new StringBuilder();
            var conversation = mailItem.GetConversation();
            var table = conversation.GetTable();

            while (!table.EndOfTable)
            {
                var row = table.GetNextRow();
                sb.AppendLine("----------------------------");
                sb.AppendLine("ID:  "+ row["EntryID"]);
                sb.AppendLine("Subject:  " + row["Subject"]);
                sb.AppendLine("Creation Time:  " + row["CreationTime"]);
                sb.AppendLine("Last Modification Time:  " + row["LastModificationTime"]);
                sb.AppendLine("Message Class:  " + row["MessageClass"]);
                sb.AppendLine();
            }

            txt_Conversation.Text = sb.ToString();
        }


        public void OnPanelOpened()
        {
            GetEmailInfo();
        }
    }
}
