using Rumors.Desktop.Common;
using System.ComponentModel;

namespace Rumors.Desktop.ViewModels
{
    public abstract class BaseViewModel : INotifyPropertyChanged, IBaseViewModel
    {
        protected IPageNavigator PageNavigator { get; }

        public event PropertyChangedEventHandler? PropertyChanged;

        protected BaseViewModel(IPageNavigator pageNavigator)
        {
            PageNavigator = pageNavigator;
        }

        protected virtual void RaisePropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        public virtual async Task OnLoad()
        {
            await Task.CompletedTask;
        }
    }

}
