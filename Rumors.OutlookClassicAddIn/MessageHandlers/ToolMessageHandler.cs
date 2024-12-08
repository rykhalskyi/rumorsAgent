using Rumors.Desktop.Common.Messages;
using Rumors.Desktop.Common.Messages.MessageHub;
using System.Threading.Tasks;

namespace Rumors.OutlookClassicAddIn.MessageHandlers
{
    public class ToolMessageHandler : BaseMessageHandler<ToolMessage>
    {
        protected override async Task<BaseMessage> Process(ToolMessage message)
        {


            return await Task.FromResult(new ToolMessage() { Text = "Tool response" });
        }
    }
}
