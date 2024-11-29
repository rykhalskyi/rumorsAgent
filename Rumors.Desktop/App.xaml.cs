using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Rumors.Desktop.Agent.Logging;
using Rumors.Desktop.Common.Messages.MessageHub;
using Rumors.Desktop.Common.Pipes;
using Rumors.Desktop.Logging;
using Rumors.Desktop.MessageHandlers;
using Serilog;
using Serilog.Events;
using System.Diagnostics;
using System.Windows;

namespace Rumors.Desktop
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private PipeServer _pipeServer = new PipeServer(PipeConsts.PipeName);
        private IMessageHub _messageHub;
        private CancellationTokenSource _cts = new CancellationTokenSource();
        private ILogger<App> _logger;
        private IChatNotifier _logNotifier;

        protected override void OnStartup(StartupEventArgs e)
        {
            
            ApplicationEntryPoint.RegisterServices();
            ConfigureLogging();
            _logger = ApplicationEntryPoint.ServiceProvider.GetService<ILogger<App>>()!;
            _logNotifier = ApplicationEntryPoint.ServiceProvider.GetService<IChatNotifier>()!;

            var messageHandlerList = ApplicationEntryPoint.ServiceProvider.GetService<IMessageHandlersList>();
            messageHandlerList!.Initialize();
            _messageHub = ApplicationEntryPoint.ServiceProvider.GetService<IMessageHub>()!;
            
            _pipeServer.Start(OnMessage, _cts.Token, _logger);

            base.OnStartup(e);

            this.ShutdownMode = ShutdownMode.OnMainWindowClose;
            this.DispatcherUnhandledException += App_DispatcherUnhandledException;

            _logger.LogInformation("App started");
        }

        private void App_DispatcherUnhandledException(object sender, System.Windows.Threading.DispatcherUnhandledExceptionEventArgs e)
        {
            _logger.LogCritical(e.Exception, "Unhandled Exception");
        }

        private async Task<string> OnMessage(string message)
        {
            return await _messageHub.Handle(message);
        }

        protected override void OnExit(ExitEventArgs e)
        {
            _cts.Cancel();
            _pipeServer.Stop();
            base.OnExit(e);
        }

        

        private void ConfigureLogging()
        {
            Action<LogEvent> logToUi = logEvent =>
            {
                string message = logEvent.RenderMessage();
                Application.Current.Dispatcher.Invoke(() =>
                {
                    Debug.WriteLine($"Log >> {message}");
                    _logNotifier.RaiseOnlog(message);
                });
            };

            var configuration = ApplicationEntryPoint.ServiceProvider.GetService<IConfiguration>()!;

            Log.Logger = new LoggerConfiguration()
                .ReadFrom.Configuration(configuration)
                .WriteTo.Sink(new UiSink(logToUi))
                .CreateLogger();
        }


    }

}
