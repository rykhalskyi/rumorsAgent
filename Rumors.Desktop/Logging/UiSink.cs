using Serilog.Core;
using Serilog.Events;

namespace Rumors.Desktop.Agent.Logging
{
    internal class UiSink : ILogEventSink
    {
        private readonly Action<LogEvent> _onLogReceived;

        public UiSink(Action<LogEvent> onLogReceived)
        {
            _onLogReceived = onLogReceived ?? throw new ArgumentNullException(nameof(onLogReceived));
        }

        public void Emit(LogEvent logEvent)
        {
            _onLogReceived?.Invoke(logEvent);
        }
    }
}