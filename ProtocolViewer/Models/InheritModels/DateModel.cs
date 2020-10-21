namespace ProtocolViewer.Models.InheritModels
{
    public class DateModel : GenericModel
    {
        #region Fields
        private string _tooltip;
        private bool _isEnabled;
        private bool _isVisible;
        private bool _isLabelVisible;
        #endregion Fields
        #region Properties
        public string ToolTip { get => _tooltip; set => SetProperty(ref _tooltip, value); }
        public bool IsEnabled { get => _isEnabled; set => SetProperty(ref _isEnabled, value); }
        public bool IsVisible { get => _isVisible; set => SetProperty(ref _isVisible, value); }
        public bool IsLabelVisible { get => _isLabelVisible; set => SetProperty(ref _isLabelVisible, value); }
        #endregion Properties
        #region Ctor
        public DateModel()
        {
            ID = "DefaultID";
            Name = string.Empty;
            ToolTip = string.Empty;
            IsEnabled = false;
            IsVisible = true;
            IsLabelVisible = true;
        }
        #endregion Ctor
    }
}
