using Microsoft.Office.Interop.Outlook;
using Rumors.Desktop.Common.Dto;
using System;
using System.Text;

namespace Rumors.OutlookClassicAddIn.emailLogic
{
    internal class EmailSearch
    {
        public string Search(string searchQuery)
        {
            try
            {
                var outlookNamespace = Globals.ThisAddIn.Application.GetNamespace("MAPI");
                var inbox = outlookNamespace.GetDefaultFolder(OlDefaultFolders.olFolderInbox);

                var items = inbox.Items;

                // Create Filter for Subject Keyword
                string filter = SearchFilter.FromString(searchQuery);

                var filteredItems = items.Restrict(filter);

                if (filteredItems.Count == 0)
                {
                    return "Not found";
                }

                var builder = new StringBuilder();
                foreach (var item in filteredItems)
                {
                    if (item is MailItem mail)
                    {
                        builder.AppendLine($"Recieved: {mail.ReceivedTime}");
                        builder.AppendLine($"From: {mail.Sender.Address}");
                        builder.AppendLine($"Subject: {mail.Subject}");
                        builder.AppendLine($"Conversation Id: {mail.ConversationID}");
                        builder.AppendLine($"");
                    }

                }

                return builder.ToString();
            }
            catch (System.Exception ex)
            {
                return ex.ToString();
            }
        }
    }
}
