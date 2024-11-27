using Rumors.Desktop.Common.Messages.MessageHub;

namespace Rumors.Desktop.MessageHandlers
{
    public class MessageHandlersList : IMessageHandlersList
    {
        private readonly IMessageHub _messageHub;

        public MessageHandlersList(IMessageHub messageHub)
        {
            _messageHub = messageHub;
        }

        public void Initialize()
        {
            //_messageHub.AddHandler(new GetProjectsMessageHandler(_mediator));
        }
    }
}
