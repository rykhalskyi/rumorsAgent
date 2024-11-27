
using System.Windows.Navigation;

namespace Rumors.Desktop.Common
{
    public interface IPageNavigator
    {
        IMainWindow MainWindow {get; set;}
        NavigationService NavigationService { get; set; }
        void ToggleProgressBar(bool visible);
        void GoBack();

    }
}