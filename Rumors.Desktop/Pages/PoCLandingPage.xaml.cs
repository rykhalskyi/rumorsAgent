using System.Windows.Controls;
using System.Windows.Documents;

namespace Rumors.Desktop.Pages
{
    /// <summary>
    /// Interaction logic for PoCLandingPage.xaml
    /// </summary>
    public partial class PoCLandingPage : Page
    {
        public PoCLandingPage()
        {
            InitializeComponent();
        }

        public void AddLog(string message)
        {
            logRtichTextBox.Document.Blocks.Add(new Paragraph(new Run(message)));
        }
    }
}
