using Prism.Commands;
using Prism.Mvvm;
using System.Windows.Input;

namespace ProtocolViewer.ViewModels
{
    class ProtocolsViewVM : BindableBase
    {
        private string _message;
        public string Message
        {
            get { return _message; }
            set { SetProperty(ref _message, value); }
        }
        public ICommand GetAct { get; set; }
        public ProtocolsViewVM()
        {
            Message = "Protocol views";
            GetAct = new DelegateCommand(() => Message = "Кнопка была нажата");
        }
    }
}
