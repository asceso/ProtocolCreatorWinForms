namespace ProtocolViewer.Models.InheritModels
{
    public class CheckBoxModel : GenericModel
    {
        #region Fields
        private string _textTrue;
        private string _textFalse;
        private bool _isEnabled;
        private bool _isVisible;
        private bool _isLabelVisible;
        #endregion Fields
        #region Properties
        public string TextTrue { get => _textTrue; set => SetProperty(ref _textTrue, value); }
        public string TextFalse { get => _textFalse; set => SetProperty(ref _textFalse, value); }
        public bool IsEnabled { get => _isEnabled; set => SetProperty(ref _isEnabled, value); }
        public bool IsVisible { get => _isVisible; set => SetProperty(ref _isVisible, value); }
        public bool IsLabelVisible { get => _isLabelVisible; set => SetProperty(ref _isLabelVisible, value); }
        #endregion Properties
        #region Ctor
        public CheckBoxModel()
        {
            ID = "DefaultID";
            Name = string.Empty;
            TextTrue = "да";
            TextFalse = "нет";
            IsEnabled = true;
            IsVisible = true;
            IsLabelVisible = true;
            MinWidth = 0;
        }
        #endregion Ctor
    }
}
