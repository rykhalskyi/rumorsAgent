using Rumors.Desktop.Common.Messages;
using Rumors.Desktop.Common.Messages.MessageHub;
using Rumors.Desktop.Logging;

namespace Rumors.Desktop.MessageHandlers
{
    internal class ChatMessageHandler : BaseMessageHandler<ChatMessage>
    {
        private readonly IChatNotifier _chatNotifier;

        public ChatMessageHandler(IChatNotifier chatNotifier)
        {
            _chatNotifier = chatNotifier;
        }
        protected async override Task<BaseMessage> Process(ChatMessage message)
        {
            var response = new ChatMessage() { Text = "Response from Desktop client"};

            _chatNotifier.RaiseOnUserMessage(message.Text);
            _chatNotifier.RaiseOnAgentMessage(response.Text);

            return await Task.FromResult(response);
        }
    }
}
