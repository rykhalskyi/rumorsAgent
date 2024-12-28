using Rumors.Desktop.Common.Messages;
using Rumors.Desktop.Common.Messages.MessageHub;
using System.Threading.Tasks;
using Microsoft.Office.Interop.Outlook;
using Rumors.OutlookClassicAddIn.emailLogic;

namespace Rumors.OutlookClassicAddIn.MessageHandlers
{
    public class GetConversationMessageHandler : BaseMessageHandler<GetConversationMessage>
    {
        protected override async Task<BaseMessage> Process(GetConversationMessage message)
        {
            {
                var outlookNamespace = Globals.ThisAddIn.Application.GetNamespace("MAPI");
                var mailItem = (MailItem)outlookNamespace.GetItemFromID(message.EmailEntityId);
                var result = ConversationUtils.GetConversation(mailItem);

                return await Task.FromResult(new GetConversationMessage { Conversation = result });
            }
        }
    }
}
