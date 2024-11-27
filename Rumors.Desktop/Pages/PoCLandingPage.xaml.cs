using Rumors.Desktop.Logging;
using System.Windows.Controls;
using System.Windows.Documents;

namespace Rumors.Desktop.Pages
{
    /// <summary>
    /// Interaction logic for PoCLandingPage.xaml
    /// </summary>
    public partial class PoCLandingPage : Page
    {
        public PoCLandingPage(ILogNotifier logNotifier)
        {
            InitializeComponent();
            logNotifier.OnLog += OnLog;

        }

        private void OnLog(string obj)
        {
            AddLog(obj);
        }

        public void AddLog(string message)
        {
            logRtichTextBox.Document.Blocks.Add(new Paragraph(new Run(message)));
        }
    }
}
