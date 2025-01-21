using Rumors.Desktop.AiAgent;
using Rumors.Desktop.Common.Messages;
using Rumors.Desktop.Common.Messages.MessageHub;
using Rumors.Desktop.Logging;

namespace Rumors.Desktop.MessageHandlers
{
    internal class ChatMessageHandler : BaseMessageHandler<ChatMessage>
    {
        private readonly IChatNotifier _chatNotifier;
        private readonly IAiAssistant _aiAssistant;

        public ChatMessageHandler(IChatNotifier chatNotifier, IAiAssistant aiAssistant)
        {
            _chatNotifier = chatNotifier;
            _aiAssistant = aiAssistant;
        }
        protected async override Task<BaseMessage> Process(ChatMessage message)
        {
            _chatNotifier.RaiseOnUserMessage(message.Text);
            var aiResponse = await _aiAssistant.Chat(message.Text);

            var response = new ChatMessage() { Text = aiResponse };
            _chatNotifier.RaiseOnAgentMessage(response.Text);

            return await Task.FromResult(response);
        }
    }
}
