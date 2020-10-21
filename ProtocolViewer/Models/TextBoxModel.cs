using Prism.Mvvm;

namespace ProtocolViewer.Models
{
    public class TextBoxModel : BindableBase
    {
        #region Fields
        private string _id;
        private string _name;
        private string _value;
        private bool _isEnabled;
        private bool _isStretch;
        private bool _isVisible;
        private bool _isLabelVisible;
        private bool _isBoldLabel;
        private bool _isConclusion;
        private int _lines;
        private int _listIndex;
        #endregion
        #region Properies
        public string ID { get => _id; set => SetProperty(ref _id, value); }
        public string Name { get => _name; set => SetProperty(ref _name, value); }
        public string Value { get => _value; set => SetProperty(ref _value, value); }
        public bool IsEnabled { get => _isEnabled; set => SetProperty(ref _isEnabled, value); }
        public bool IsStretch { get => _isStretch; set => SetProperty(ref _isStretch, value); }
        public bool IsVisible { get => _isVisible; set => SetProperty(ref _isVisible, value); }
        public bool IsLabelVisible { get => _isLabelVisible; set => SetProperty(ref _isLabelVisible, value); }
        public bool IsBoldLabel { get => _isBoldLabel; set => SetProperty(ref _isBoldLabel, value); }
        public bool IsConclusion { get => _isConclusion; set => SetProperty(ref _isConclusion, value); }
        public int Lines { get => _lines; set => SetProperty(ref _lines, value); }
        public int ListIndex { get => _listIndex; set => SetProperty(ref _listIndex, value); }
        //public string ID 
        //{ 
        //    get => _id;
        //    set { 
        //        SetProperty(ref _id, value);
        //        RaisePropertyChanged("PreviewResult");
        //    }
        //}
        //public string Name
        //{
        //    get => _name;
        //    set
        //    {
        //        SetProperty(ref _name, value);
        //        RaisePropertyChanged("PreviewResult");
        //    }
        //}
        //public string Value
        //{
        //    get => _value;
        //    set
        //    {
        //        SetProperty(ref _value, value);
        //        RaisePropertyChanged("PreviewResult");
        //    }
        //}
        //public bool IsEnabled
        //{
        //    get => _isEnabled;
        //    set
        //    {
        //        SetProperty(ref _isEnabled, value);
        //        RaisePropertyChanged("PreviewResult");
        //    }
        //}
        //public bool IsStretch
        //{
        //    get => _isStretch;
        //    set
        //    {
        //        SetProperty(ref _isStretch, value);
        //        RaisePropertyChanged("PreviewResult");
        //    }
        //}
        //public bool IsVisible
        //{
        //    get => _isVisible;
        //    set
        //    {
        //        SetProperty(ref _isVisible, value);
        //        RaisePropertyChanged("PreviewResult");
        //    }
        //}
        //public bool IsLabelVisible
        //{
        //    get => _isLabelVisible;
        //    set
        //    {
        //        SetProperty(ref _isLabelVisible, value);
        //        RaisePropertyChanged("PreviewResult");
        //    }
        //}
        //public bool IsBoldLabel
        //{
        //    get => _isBoldLabel;
        //    set
        //    {
        //        SetProperty(ref _isBoldLabel, value);
        //        RaisePropertyChanged("PreviewResult");
        //    }
        //}
        //public bool IsConclusion
        //{
        //    get => _isConclusion;
        //    set
        //    {
        //        SetProperty(ref _isConclusion, value);
        //        RaisePropertyChanged("PreviewResult");
        //    }
        //}
        //public int Lines
        //{
        //    get => _lines;
        //    set
        //    {
        //        SetProperty(ref _lines, value);
        //        RaisePropertyChanged("PreviewResult");
        //    }
        //}
        #endregion
        #region Ctor
        public TextBoxModel()
        {
            ID = "DefaultID";
            IsEnabled = true;
            IsStretch = true;
            IsVisible = true;
            IsLabelVisible = true;
            IsBoldLabel = false;
            IsConclusion = false;
            Lines = 1;
        }
        #endregion Ctor
    }
}
