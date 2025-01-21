using Rumors.Desktop.AiAgent;
using Rumors.Desktop.Common.Messages.MessageHub;
using Rumors.Desktop.Logging;

namespace Rumors.Desktop.MessageHandlers
{
    public class MessageHandlersList : IMessageHandlersList
    {
        private readonly IMessageHub _messageHub;
        private readonly IChatNotifier _chatNotifier;
        private readonly IAiAssistant _aiAssistent;

        public MessageHandlersList(IMessageHub messageHub, IChatNotifier chatNotifier, IAiAssistant aiAssistent)
        {
            _messageHub = messageHub;
            _chatNotifier = chatNotifier;
            _aiAssistent = aiAssistent;
        }

        public void Initialize()
        {
            _messageHub.AddHandler(new ChatMessageHandler(_chatNotifier, _aiAssistent));
        }
    }
}
