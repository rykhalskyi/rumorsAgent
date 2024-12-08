using Microsoft.Office.Core;
using Rumors.OutlookClassicAddIn.Panes;
using Rumors.Desktop.Common.Messages.MessageHub;
using Rumors.Desktop.Common.Messages.Serialization;
using Rumors.Desktop.Common.Pipes;
using Microsoft.Extensions.Configuration;
using Serilog;
using System;
using System.Windows;
using System.Threading.Tasks;
using System.Threading;
using Serilog.Core;
using System.Windows.Forms;
using Microsoft.Extensions.Logging;
using Rumors.OutlookClassicAddIn.MessageHandlers;



namespace Rumors.OutlookClassicAddIn
{
    public partial class ThisAddIn
    {
        public IMessageHub MessageHub { get; private set; }
        public static TaskPanes TaskPanes { get; private set; }
        public static RumorsRibbon Ribbon { get; private set; }
        public static PipeClient PipeClient { get; private set; }

        private static PipeServer _pipeServer;
        private CancellationTokenSource _cts = new CancellationTokenSource();

        private ILoggerFactory _loggerFactory;
        private ILogger<ThisAddIn> _logger;

        private void ThisAddIn_Startup(object sender, System.EventArgs e)
        {
            CreateLogger();

            AppDomain.CurrentDomain.UnhandledException += CurrentDomain_UnhandledException;
            TaskScheduler.UnobservedTaskException += TaskScheduler_UnobservedTaskException;

            TaskPanes = new TaskPanes();
            MessageHub = new MessageHub(new MessageSerializer());
            MessageHub.AddHandler(new ToolMessageHandler());
            MessageHub.AddHandler(new SearchMessageHandler());

            PipeClient = new PipeClient(PipeConsts.PipeName, ex => { });
            _pipeServer = new PipeServer(PipeConsts.ReversedPipeName);
            _pipeServer.Start(OnMessage, _cts.Token, _logger);
        }

        private async Task<string> OnMessage(string message)
        {
            return await MessageHub.Handle(message);
        }

        private void TaskScheduler_UnobservedTaskException(object sender, UnobservedTaskExceptionEventArgs e)
        {
            Log.Error(e.Exception, "Unobserved task exception.");
            e.SetObserved();
        }

        private void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            Log.Error((Exception)e.ExceptionObject, "Unhandled exception caught in AppDomain.");
        }

        private void CreateLogger()
        {
            try
            {
                var configuration = LoadConfiguration();
                ConfigureLogging(configuration);

                Log.Information("VSTO Add-In started.");
            }
            catch (Exception ex)
            {
                System.Windows.MessageBox.Show(ex.ToString(), "Log Creating Exception");
            }
        }

        private void ThisAddIn_Shutdown(object sender, System.EventArgs e)
        {
            // Note: Outlook no longer raises this event. If you have code that 
            //    must run when Outlook shuts down, see https://go.microsoft.com/fwlink/?LinkId=506785
        }

        #region VSTO generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InternalStartup()
        {
            this.Startup += new System.EventHandler(ThisAddIn_Startup);
            this.Shutdown += new System.EventHandler(ThisAddIn_Shutdown);
        }

        protected override IRibbonExtensibility CreateRibbonExtensibilityObject()
        {
            Ribbon = new RumorsRibbon();
            return Ribbon;
           // return base.CreateRibbonExtensibilityObject();
        }

        #endregion

        #region Logs
        private IConfiguration LoadConfiguration()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);

            return builder.Build();
        }

        private void ConfigureLogging(IConfiguration configuration)
        {
            _loggerFactory = new LoggerFactory();
            _loggerFactory.AddSerilog();

            _logger = _loggerFactory.CreateLogger<ThisAddIn>();

            Log.Logger = new LoggerConfiguration()
                .ReadFrom.Configuration(configuration)
                .CreateLogger();
        }
        #endregion
    }
}
