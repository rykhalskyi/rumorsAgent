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



namespace Rumors.OutlookClassicAddIn
{
    public partial class ThisAddIn
    {
        public IMessageHub MessageHub { get; private set; }
        public static TaskPanes TaskPanes { get; private set; }
        public static RumorsRibbon Ribbon { get; private set; }
        public static PipeClient PipeClient { get; private set; }

        private void ThisAddIn_Startup(object sender, System.EventArgs e)
        {
            CreateLogger();

            AppDomain.CurrentDomain.UnhandledException += CurrentDomain_UnhandledException;
            TaskScheduler.UnobservedTaskException += TaskScheduler_UnobservedTaskException;

            TaskPanes = new TaskPanes();
            MessageHub = new MessageHub(new MessageSerializer());
            PipeClient = new PipeClient(PipeConsts.PipeName, ex => { });

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
                MessageBox.Show(ex.ToString(), "Log Creating Exception");
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
           

            Log.Logger = new LoggerConfiguration()
                .ReadFrom.Configuration(configuration)
                .CreateLogger();
        }
        #endregion
    }
}
