namespace Rumors.Desktop.Logging
{
    public interface ILogNotifier
    {
        Action<string> OnLog { get; set; }
        void RaiseOnlog(string message);
    }
}