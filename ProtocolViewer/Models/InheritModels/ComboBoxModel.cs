using System.Collections.ObjectModel;

namespace ProtocolViewer.Models.InheritModels
{
    public class ComboBoxModel : GenericModel
    {
        #region Fields
        private bool _isEnabled;
        private bool _isVisible;
        private bool _isLabelVisible;
        private bool _isTextEditable;
        private bool _isConclusionTemplate;
        private bool _isSelectedFromNetrika;
        private bool _isUseNetrika;
        private string _value;
        private ObservableCollection<string> _values;
        #endregion Fields
        #region Properties
        public bool IsEnabled { get => _isEnabled; set => SetProperty(ref _isEnabled, value); }
        public bool IsVisible { get => _isVisible; set => SetProperty(ref _isVisible, value); }
        public bool IsLabelVisible { get => _isLabelVisible; set => SetProperty(ref _isLabelVisible, value); }
        public bool IsTextEditable { get => _isTextEditable; set => SetProperty(ref _isTextEditable, value); }
        public bool IsConclusionTemplate { get => _isConclusionTemplate; set => SetProperty(ref _isConclusionTemplate, value); }
        public bool IsSelectedFromNetrika { get => _isSelectedFromNetrika; set => SetProperty(ref _isSelectedFromNetrika, value); }
        public bool IsUseNetrika { get => _isUseNetrika; set => SetProperty(ref _isUseNetrika, value); }
        public string Value { get => _value; set => SetProperty(ref _value, value); }
        public ObservableCollection<string> Values { get => _values; set => SetProperty(ref _values, value); }
        #endregion Properties
        #region Ctor
        public ComboBoxModel()
        {
            IsEnabled = true;
            IsVisible = true;
            IsLabelVisible = true;
            IsTextEditable = false;
            IsConclusionTemplate = false;
            IsSelectedFromNetrika = false;
            IsUseNetrika = false;
            Value = string.Empty;
            Values = new ObservableCollection<string>();
        }
        #endregion Ctor
    }
}
