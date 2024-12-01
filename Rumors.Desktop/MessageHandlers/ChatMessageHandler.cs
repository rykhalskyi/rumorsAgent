using Rumors.Desktop.AiAgent;
using Rumors.Desktop.Common.Messages;
using Rumors.Desktop.Common.Messages.MessageHub;
using Rumors.Desktop.Logging;

namespace Rumors.Desktop.MessageHandlers
{
    internal class ChatMessageHandler : BaseMessageHandler<ChatMessage>
    {
        private readonly IChatNotifier _chatNotifier;
        private readonly Playground _playground;

        public ChatMessageHandler(IChatNotifier chatNotifier, Playground playground)
        {
            _chatNotifier = chatNotifier;
            _playground = playground;
        }
        protected async override Task<BaseMessage> Process(ChatMessage message)
        {
            _chatNotifier.RaiseOnUserMessage(message.Text);
            var aiResponse = await _playground.Chat(message.Text);

            var response = new ChatMessage() { Text = aiResponse };
            _chatNotifier.RaiseOnAgentMessage(response.Text);

            return await Task.FromResult(response);
        }
    }
}
