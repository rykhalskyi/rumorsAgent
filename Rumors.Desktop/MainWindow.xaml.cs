using System.Windows;
using System.Windows.Controls;
using Microsoft.Extensions.DependencyInjection;
using Rumors.Desktop.Common;
using Rumors.Desktop.Logging;
using Rumors.Desktop.Pages;
using Rumors.Desktop.ViewModels;

namespace Rumors.Desktop
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, IMainWindow
    {
        private const string AppName = "Rumors Desktop PoC";

        private TaskCompletionSource<(bool, string)> _stringInputComplitionSource;
        private TaskCompletionSource<bool> _confirmationComplitionSource;
        private TaskCompletionSource<bool> _customDialogComplitionSource;

        public event Action<bool> CustomDialogClosed = delegate { };

        IPageNavigator _navigator;
        public MainWindow()
        {
            InitializeComponent();

            _navigator = ApplicationEntryPoint.ServiceProvider.GetRequiredService<IPageNavigator>();
            _navigator.NavigationService = MainFrame.NavigationService;

            //MainFrame.Navigate(new ProjectListPage());

            // ---- PoC ----
            var logNotifier = ApplicationEntryPoint.ServiceProvider.GetService<ILogNotifier>()!;
            ProgressBarLayer.Visibility = Visibility.Collapsed;
            MainFrame.Navigate(new PoCLandingPage(logNotifier));
            // ---- PoC ----

            _navigator.NavigationService.Navigated += NavigationService_Navigated;
            _navigator.MainWindow = this;
            
        }

        private void NavigationService_Navigated(object sender, System.Windows.Navigation.NavigationEventArgs e)
        {
            if (MainFrame.NavigationService.Content is Page page) 
            {
                if (page.DataContext is IBaseViewModel vm)
                {
                   Task.Run(async () => 
                   {
                       ToggleProgressBarLayout(true);
                       await vm.OnLoad();
                       ToggleProgressBarLayout(false);
                   });
                }
            }
        }

        public void ToggleProgressBarLayout(bool visible)
        {
            Application.Current.Dispatcher.Invoke(() =>
            {
                if (!visible)
                {
                    ProgressBarLayer.Visibility = Visibility.Collapsed;
                }
                else
                {
                    ProgressBarLayer.Visibility = Visibility.Visible;
                }
            });
        }


    }
}