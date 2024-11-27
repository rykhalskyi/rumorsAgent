namespace Rumors.Desktop.Common.Messages
{
    public class SimpleResponseMessage : BaseMessage
    {
        public bool Successful { get; set; } = true;
        public string Message { get; set; } = string.Empty;
    }
}
