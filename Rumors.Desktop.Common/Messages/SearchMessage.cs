using Rumors.Desktop.Common.Dto;

namespace Rumors.Desktop.Common.Messages
{
    public class SearchMessage : BaseMessage
    {
        public SearchDto Search { get; set; }
    }
}
