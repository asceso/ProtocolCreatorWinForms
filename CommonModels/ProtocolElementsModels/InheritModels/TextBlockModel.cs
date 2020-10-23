namespace CommonModels.ProtocolElementsModels.InheritModels
{
    public class TextBlockModel : GenericModel
    {
        #region Fields
        private string _value;
        private bool _isEnabled;
        private bool _isStretch;
        private bool _isVisible;
        private bool _isBold;
        #endregion
        #region Properies
        public string Value { get => _value; set => SetProperty(ref _value, value); }
        public bool IsEnabled { get => _isEnabled; set => SetProperty(ref _isEnabled, value); }
        public bool IsStretch { get => _isStretch; set => SetProperty(ref _isStretch, value); }
        public bool IsVisible { get => _isVisible; set => SetProperty(ref _isVisible, value); }
        public bool IsBold { get => _isBold; set => SetProperty(ref _isBold, value); }
        #endregion
        #region Ctor
        public TextBlockModel()
        {
            ID = "DefaultID";
            Name = string.Empty;
            Value = string.Empty;
            IsEnabled = true;
            IsStretch = true;
            IsVisible = true;
            IsBold = false;
            MinWidth = 0;
        }
        #endregion Ctor
    }
}
