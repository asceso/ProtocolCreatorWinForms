using Prism.Mvvm;

namespace ProtocolerWPF.ViewModels
{
    public class MainWindowViewModel : BindableBase
    {
        private string _title = "Конструктор протоколов";
        public string Title
        {
            get => _title;
            set
            {
                SetProperty(ref _title, value);
            }
        }

        public MainWindowViewModel()
        {

        }
    }
}
