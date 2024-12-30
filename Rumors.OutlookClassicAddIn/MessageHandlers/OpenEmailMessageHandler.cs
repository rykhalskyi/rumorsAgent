using Microsoft.Office.Interop.Outlook;
using Rumors.Desktop.Common.Messages;
using Rumors.Desktop.Common.Messages.MessageHub;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Rumors.OutlookClassicAddIn.MessageHandlers
{
    public class OpenEmailMessageHandler : BaseMessageHandler<OpenEmailMessage>
    {
        protected override async Task<BaseMessage> Process(OpenEmailMessage message)
        {
            try
            {
                var outlookNamespace = Globals.ThisAddIn.Application.GetNamespace("MAPI");

                MailItem mailItem = (MailItem)outlookNamespace.GetItemFromID(message.EmailId);

                if (mailItem != null)
                {
                    mailItem.Display();
                }
                else
                {
                    MessageBox.Show("Mail item not found.");
                }
            }
            catch (System.Exception ex)
            {
                Log.Error(ex, "FindEmail");
                return await Task.FromResult(new SimpleResponseMessage { Message = ex.ToString() });
            }

            return await Task.FromResult(new SimpleResponseMessage { Message = "OK" });
        }
    }
}
