using Rumors.Desktop.Common.Dto;

namespace Rumors.Desktop.Common.Messages
{
    public class GetConversationMessage : BaseMessage
    {
        public string EmailEntityId { get; set; }

        public ConversationDto Conversation { get; set; }
    }
}
