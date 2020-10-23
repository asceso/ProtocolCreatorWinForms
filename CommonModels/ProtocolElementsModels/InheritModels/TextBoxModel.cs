namespace CommonModels.ProtocolElementsModels.InheritModels
{
    public class TextBoxModel : GenericModel
    {
        #region Fields
        private string _value;
        private string _toolTip;
        private bool _isEnabled;
        private bool _isStretch;
        private bool _isVisible;
        private bool _isLabelVisible;
        private bool _isBoldLabel;
        private bool _isConclusion;
        #endregion
        #region Properies
        public string Value { get => _value; set => SetProperty(ref _value, value); }
        public string ToolTip { get => _toolTip; set => SetProperty(ref _toolTip, value); }
        public bool IsEnabled { get => _isEnabled; set => SetProperty(ref _isEnabled, value); }
        public bool IsStretch { get => _isStretch; set => SetProperty(ref _isStretch, value); }
        public bool IsVisible { get => _isVisible; set => SetProperty(ref _isVisible, value); }
        public bool IsLabelVisible { get => _isLabelVisible; set => SetProperty(ref _isLabelVisible, value); }
        public bool IsBoldLabel { get => _isBoldLabel; set => SetProperty(ref _isBoldLabel, value); }
        public bool IsConclusion { get => _isConclusion; set => SetProperty(ref _isConclusion, value); }
        #endregion
        #region Ctor
        public TextBoxModel()
        {
            ID = "DefaultID";
            Name = string.Empty;
            Value = string.Empty;
            IsEnabled = true;
            IsStretch = true;
            IsVisible = true;
            IsLabelVisible = true;
            IsBoldLabel = false;
            IsConclusion = false;
        }
        #endregion Ctor
    }
}
