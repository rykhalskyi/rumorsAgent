using Rumors.Desktop.AiAgent;
using Rumors.Desktop.Common.Messages.MessageHub;
using Rumors.Desktop.Logging;

namespace Rumors.Desktop.MessageHandlers
{
    public class MessageHandlersList : IMessageHandlersList
    {
        private readonly IMessageHub _messageHub;
        private readonly IChatNotifier _chatNotifier;
        private readonly Playground _playground;

        public MessageHandlersList(IMessageHub messageHub, IChatNotifier chatNotifier, Playground playground)
        {
            _messageHub = messageHub;
            _chatNotifier = chatNotifier;
            _playground = playground;
        }

        public void Initialize()
        {
            _messageHub.AddHandler(new ChatMessageHandler(_chatNotifier, _playground));
        }
    }
}
