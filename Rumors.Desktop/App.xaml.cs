using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Rumors.Desktop.Common.Messages.MessageHub;
using Rumors.Desktop.Common.Pipes;
using Rumors.Desktop.MessageHandlers;
using Rumors.Desktop.ViewModels;
using Serilog;
using System.Configuration;
using System.IO;
using System.Windows;

namespace Rumors.Desktop
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private PipeServer _pipeServer = new PipeServer();
        private IMessageHub _messageHub;
        private CancellationTokenSource _cts = new CancellationTokenSource();
        private ILogger<App> _logger;

        protected override void OnStartup(StartupEventArgs e)
        {
            
            ApplicationEntryPoint.RegisterServices();
            ConfigureLogging();
            _logger = ApplicationEntryPoint.ServiceProvider.GetService<ILogger<App>>()!;

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
            var configuration = ApplicationEntryPoint.ServiceProvider.GetService<IConfiguration>()!;

            Log.Logger = new LoggerConfiguration()
                .ReadFrom.Configuration(configuration)
                .CreateLogger();
        }


    }

}
