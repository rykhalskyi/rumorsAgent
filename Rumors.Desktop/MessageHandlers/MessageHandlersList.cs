using Rumors.Desktop.Common.Messages.MessageHub;
using Rumors.Desktop.Logging;

namespace Rumors.Desktop.MessageHandlers
{
    public class MessageHandlersList : IMessageHandlersList
    {
        private readonly IMessageHub _messageHub;
        private readonly IChatNotifier _chatNotifier;

        public MessageHandlersList(IMessageHub messageHub, IChatNotifier chatNotifier)
        {
            _messageHub = messageHub;
            _chatNotifier = chatNotifier;
        }

        public void Initialize()
        {
            _messageHub.AddHandler(new ChatMessageHandler(_chatNotifier));
        }
    }
}
