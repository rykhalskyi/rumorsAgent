namespace Rumors.Desktop.Logging
{
    public interface IChatNotifier
    {
        Action<string> OnLog { get; set; }
        void RaiseOnlog(string message);

        Action<string> OnUserMessage { get; set; }
        void RaiseOnUserMessage(string message);

        Action<string> OnAgentMessage { get; set; }
        void RaiseOnAgentMessage(string message);
    }
}