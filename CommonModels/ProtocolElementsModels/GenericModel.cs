using Prism.Mvvm;

namespace CommonModels.ProtocolElementsModels
{
    public class GenericModel : BindableBase
    {
        #region Fields
        private string _id;
        private string _name;
        private int _minWidth;
        private int _lines;
        #endregion Fields
        #region Properties
        public string ID { get => _id; set => SetProperty(ref _id, value); }
        public string Name { get => _name; set => SetProperty(ref _name, value); }
        public int MinWidth { get => _minWidth; set => SetProperty(ref _minWidth, value); }
        public int Lines { get => _lines; set => SetProperty(ref _lines, value); }
        #endregion Properties
        #region Ctor
        public GenericModel()
        {
            ID = "DefaultID";
            Name = string.Empty;
            MinWidth = 0;
            Lines = 0;
        }
        #endregion Ctor
    }
}
