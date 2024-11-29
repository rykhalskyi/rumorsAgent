namespace Rumors.Desktop.Logging
{
    public class LogNotifier : IChatNotifier
    {
        public Action<string> OnLog { get; set; } = delegate { };
        public Action<string> OnUserMessage { get; set; } = delegate { };
        public Action<string> OnAgentMessage { get; set; } = delegate { };

        public void RaiseOnAgentMessage(string message)
        {
            OnAgentMessage(message);
        }

        public void RaiseOnlog(string message)
        {
            OnLog(message);
        }

        public void RaiseOnUserMessage(string message)
        {
            OnUserMessage(message);
        }
    }
}
