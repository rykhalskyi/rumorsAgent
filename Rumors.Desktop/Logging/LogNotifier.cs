namespace Rumors.Desktop.Logging
{
    public class LogNotifier : ILogNotifier
    {
        public Action<string> OnLog { get; set; } = delegate { };
        public void RaiseOnlog(string message)
        {
            OnLog(message);
        }
    }
}
