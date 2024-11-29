using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Rumors.Desktop.Logging;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Media;

namespace Rumors.Desktop.Pages
{
    /// <summary>
    /// Interaction logic for PoCLandingPage.xaml
    /// </summary>
    public partial class PoCLandingPage : Page
    {
        ILogger<PoCLandingPage> _logger;
        public PoCLandingPage()
        {
            InitializeComponent();
            var logNotifier = ApplicationEntryPoint.ServiceProvider.GetService<IChatNotifier>()!;
          
            logNotifier.OnLog += OnLog;
            logNotifier.OnUserMessage += AddUserMessage;
            logNotifier.OnAgentMessage += AddAgentMessage;

            _logger = ApplicationEntryPoint.ServiceProvider.GetService<ILogger<PoCLandingPage>>()!;

        }

        private void OnLog(string obj)
        {
            var date = DateTime.Now;
            AddLog(obj);
        }

        public void AddLog(string message)
        {
            RunSafe(() =>
            {
                var caption = new Bold(new Run("[Log]: "));
                var dateRun = new Italic(new Run($"{DateTime.Now.ToString()}: "));
                var run = new Run(message);

                var paragraph = new Paragraph() { TextAlignment = System.Windows.TextAlignment.Left };
                paragraph.Inlines.Add(caption);
                paragraph.Inlines.Add(dateRun);
                paragraph.Inlines.Add(new Run(message));
                logRtichTextBox.Document.Blocks.Add(paragraph);
            });
        }

        public void AddUserMessage(string message)
        {
            RunSafe(() =>
            {
                var caption = new Bold(new Run("[User]: "));
                var run = new Run(message);

                var paragraph = new Paragraph() { TextAlignment = System.Windows.TextAlignment.Right };
                paragraph.Inlines.Add(caption);
                paragraph.Inlines.Add(new Run(message));
                logRtichTextBox.Document.Blocks.Add(paragraph);
            });
        }

        public void AddAgentMessage(string message)
        {
            RunSafe(() =>
            {
                var caption = new Bold(new Run("[Agent]: "));
                var run = new Run(message);

                var paragraph = new Paragraph() { TextAlignment = System.Windows.TextAlignment.Left };
                paragraph.Inlines.Add(caption);
                paragraph.Inlines.Add(new Run(message));
                logRtichTextBox.Document.Blocks.Add(paragraph);
            });
        }

        private void Button_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            _logger.LogInformation("Click click");
        }

        private void RunSafe(Action action)
        {
            Application.Current.Dispatcher.Invoke(action);
        }
    }
}
