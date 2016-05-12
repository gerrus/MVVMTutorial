using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;

namespace MVVMTutorial.ViewModel
{
    public class MainViewModel : ViewModelBase
    {
        public string Message
        {
            get { return _message; }
            set { Set(ref _message, value); }
        }

        public string Name
        {
            get { return _name; }

            set
            {
                Set(ref _name, value);
                SayHello.RaiseCanExecuteChanged();
            }
        }

        public RelayCommand SayHello
        {
            get
            {
                return _sayHello ??
                       (_sayHello =
                           new RelayCommand(() => { Message = $"Hello {Name}"; }, () => !string.IsNullOrEmpty(Name)));
            }
        }

        private string _message;
        private string _name;
        private RelayCommand _sayHello;
    }
}