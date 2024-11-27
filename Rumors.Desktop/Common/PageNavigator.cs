
using System.Windows;
using System.Windows.Navigation;

namespace Rumors.Desktop.Common
{
    public class PageNavigator : IPageNavigator
    {
        public IMainWindow MainWindow { get; set; }
        public NavigationService NavigationService { get; set; }

        public event Func<string?> ShowPrompt;

        public void ToggleProgressBar(bool visible)
        {
            MainWindow?.ToggleProgressBarLayout(visible);
        }

        public void GoBack()
        {
            Application.Current.Dispatcher.Invoke(() =>
            {
                NavigationService.GoBack();
            });
        } 


    }
}
