namespace CommonModels.ProtocolElementsModels.InheritModels
{
    public class NumericModel : GenericModel
    {
        #region Fields
        private bool _isEnabled;
        private bool isVisible;
        private bool _isLabelVisible;
        private float _value;
        private float _step;
        private string _formatString;
        private string _unit;
        #endregion Fields
        #region Properties
        public bool IsEnabled { get => _isEnabled; set => SetProperty(ref _isEnabled, value); }
        public bool IsVisible { get => isVisible; set => SetProperty(ref isVisible, value); }
        public bool IsLabelVisible { get => _isLabelVisible; set => SetProperty(ref _isLabelVisible, value); }
        public float Value { get => _value; set => SetProperty(ref _value, value); }
        public float Step { get => _step; set => SetProperty(ref _step, value); }
        public string FormatString { get => _formatString; set => SetProperty(ref _formatString, value); }
        public string Unit { get => _unit; set => SetProperty(ref _unit, value); }
        #endregion Properties
        #region Ctor
        public NumericModel()
        {
            IsEnabled = true;
            IsVisible = true;
            IsLabelVisible = true;
            Value = 0;
            Step = 0.1f;
            FormatString = string.Empty;
            Unit = string.Empty;
        }
        #endregion Ctor
    }
}
