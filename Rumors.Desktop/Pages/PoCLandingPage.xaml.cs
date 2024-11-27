using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Rumors.Desktop.Logging;
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
            var logNotifier = ApplicationEntryPoint.ServiceProvider.GetService<ILogNotifier>()!;
            logNotifier.OnLog += OnLog;

            _logger = ApplicationEntryPoint.ServiceProvider.GetService<ILogger<PoCLandingPage>>()!;

        }

        private void OnLog(string obj)
        {
            var date = DateTime.Now;
            AddLog($"Log >> {date.ToString()}  {obj}");
        }

        public void AddLog(string message)
        {
            var run = new Run(message); //Fix it
            run.Foreground = Brushes.Red;
            
            var paragraph = new Paragraph();
            paragraph.Inlines.Add(new Run(message));
            logRtichTextBox.Document.Blocks.Add(paragraph);
        }

        private void Button_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            _logger.LogInformation("Click click");
        }
    }
}
