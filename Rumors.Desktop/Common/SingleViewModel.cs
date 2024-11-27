using System.ComponentModel;

namespace Rumors.Desktop.Common
{
    public class SingleViewModel<T> : INotifyPropertyChanged
    {

        private T _value = default(T)!;
        public T Value { 
            get { return _value; }
            set 
            { 
                _value = value;
                OnChanged(_value);
                RaisePropertyChanged(nameof(Value));
            } 
        }

        private Action<T> OnChanged { get; } = delegate {  };

        public event PropertyChangedEventHandler? PropertyChanged;

        protected virtual void RaisePropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        public SingleViewModel()
        {
        }

        public SingleViewModel(Action<T> onChanged)
        {
            OnChanged = onChanged;
        }
    }
}
