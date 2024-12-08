using Rumors.Desktop.Common.Messages.MessageHub;
using Rumors.Desktop.Common.Messages;
using System.Threading.Tasks;
using Rumors.OutlookClassicAddIn.emailLogic;

namespace Rumors.OutlookClassicAddIn.MessageHandlers
{
    public class SearchMessageHandler : BaseMessageHandler<SearchMessage>
    {
        protected override async Task<BaseMessage> Process(SearchMessage message)
        {
            var emailSearcher = new EmailSearch();
            var result = emailSearcher.Search(message.Search);
            return await Task.FromResult(new SimpleResponseMessage { Message = result });
        }
    }
}
