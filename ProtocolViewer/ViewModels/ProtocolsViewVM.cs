using Prism.Commands;
using Prism.Mvvm;
using Prism.Regions;
using ProtocolViewer.Models;
using ProtocolViewer.Models.InheritModels;
using ProtocolViewer.Views;
using System.Windows.Input;
using Unity;

namespace ProtocolViewer.ViewModels
{
    public class ProtocolsViewVM : BindableBase
    {
        #region Fields
        private readonly IRegionManager regionManager;
        private readonly IUnityContainer container;
        private string selectedProtocolItem;
        private string cbListBoxSelectedItem;
        private string cbListBoxTemplateItem;
        private TextBoxModel textBoxModel;
        private TextBlockModel textBlockModel;
        private DateModel dateModel;
        private CheckBoxModel checkBoxModel;
        private ComboBoxModel comboBoxModel;
        public string[] AvailableItems => new string[]
        {
            "TextBox", "TextBlock", "Date", "CheckBox", "ComboBox"
        };
        #endregion Fields
        #region Properties
        #region SelectedProtocolType
        public string SelectedProtocolItem
        {
            get => selectedProtocolItem;
            set
            {
                SetProperty(ref selectedProtocolItem, value);
                RaisePropertyChanged(nameof(PreviewResult));
                CheckAllVisibility();
            }
        }
        private bool SelectedItemHasValue() => SelectedProtocolItem != null;
        #endregion SelectedProtocolType
        #region SelectedComboBoxListItem
        public string CBListBoxSelectedItem 
        {
            get => cbListBoxSelectedItem;
            set
            {
                SetProperty(ref cbListBoxSelectedItem, value);
                CBListBoxTemplateItem = value;
            }
        }
        private bool CBListBoxSelectedItemHasValue() => CBListBoxSelectedItem != null;
        public string CBListBoxTemplateItem
        {
            get => cbListBoxTemplateItem;
            set
            {
                SetProperty(ref cbListBoxTemplateItem, value);
            }
        }
        private bool CBListBoxTemplateItemHasValue() => CBListBoxTemplateItem != null;
        #endregion
        #region VisibilityBlocks
        public bool TextBoxItemVisibility => SelectedItemHasValue() && SelectedProtocolItem.Equals("TextBox");
        public bool TextBlockItemVisibility => SelectedItemHasValue() && SelectedProtocolItem.Equals("TextBlock");
        public bool DateItemVisibility => SelectedItemHasValue() && SelectedProtocolItem.Equals("Date");
        public bool CheckBoxItemVisibility => SelectedItemHasValue() && SelectedProtocolItem.Equals("CheckBox");
        public bool ComboBoxItemVisibility => SelectedItemHasValue() && SelectedProtocolItem.Equals("ComboBox");

        private void CheckAllVisibility()
        {
            RaisePropertyChanged(nameof(TextBoxItemVisibility));
            RaisePropertyChanged(nameof(TextBlockItemVisibility));
            RaisePropertyChanged(nameof(DateItemVisibility));
            RaisePropertyChanged(nameof(CheckBoxItemVisibility));
            RaisePropertyChanged(nameof(ComboBoxItemVisibility));
        }
        #endregion VisibilityBlocks
        #region Models
        public TextBoxModel TextBoxModel { get => textBoxModel; set => SetProperty(ref textBoxModel, value); }
        public TextBlockModel TextBlockModel { get => textBlockModel; set => SetProperty(ref textBlockModel, value); }
        public DateModel DateModel { get => dateModel; set => SetProperty(ref dateModel, value); }
        public CheckBoxModel CheckBoxModel { get => checkBoxModel; set => SetProperty(ref checkBoxModel, value); }
        public ComboBoxModel ComboBoxModel { get => comboBoxModel; set => SetProperty(ref comboBoxModel, value); }
        #endregion models
        #endregion
        #region Commands
        public ICommand OpenSettingsCommand { get; private set; }
        public ICommand NumericClickCommand { get; private set; }
        public ICommand GenerateCodeCommand { get; private set; }
        public ICommand ResetCurrentModelCommand { get; private set; }
        public ICommand CBAddListBoxItem { get; private set; }
        public ICommand CBEditListBoxItem { get; private set; }
        public ICommand CBDeleteListBoxItem { get; private set; }
        #endregion Commands
        #region Ctor
        public ProtocolsViewVM(IRegionManager regionManager, IUnityContainer container)
        {
            this.regionManager = regionManager;
            this.container = container;

            TextBoxModel = new TextBoxModel();
            TextBlockModel = new TextBlockModel();
            DateModel = new DateModel();
            CheckBoxModel = new CheckBoxModel();
            ComboBoxModel = new ComboBoxModel();
            
            OpenSettingsCommand = new DelegateCommand(OnOpenSettings);
            NumericClickCommand = new DelegateCommand<string>(OnNumericButtonClick);
            GenerateCodeCommand = new DelegateCommand(OnGenerateButtonClick);
            ResetCurrentModelCommand = new DelegateCommand(OnResetCurrentModel);

            CBAddListBoxItem = new DelegateCommand(OnAddListBoxItemCB, () => CBListBoxTemplateItemHasValue())
                .ObservesProperty(()=>CBListBoxTemplateItem);
            CBEditListBoxItem = new DelegateCommand(OnEditListBoxItemCB, () => CBListBoxSelectedItemHasValue())
                .ObservesProperty(()=> CBListBoxSelectedItem);
            CBDeleteListBoxItem = new DelegateCommand(OnDeleteListBoxItemCB, () => CBListBoxSelectedItemHasValue())
                .ObservesProperty(() => CBListBoxSelectedItem);
        }
        #endregion Ctor
        #region Methods
        #region GenericMethods
        private void OnOpenSettings()
        {
            NavigationParameters nav = new NavigationParameters();
            nav.Add("backUri", nameof(ProtocolsView));
            regionManager.RequestNavigate("MainRegion", "SettingsView",nav);
        }
        private void OnResetCurrentModel()
        {
            if (SelectedProtocolItem == null)
                return;
            switch (SelectedProtocolItem)
            {
                case "TextBox":
                    TextBoxModel = new TextBoxModel();
                    break;
                case "TextBlock":
                    TextBlockModel = new TextBlockModel();
                    break;
                case "Date":
                    DateModel = new DateModel();
                    break;
                case "CheckBox":
                    CheckBoxModel = new CheckBoxModel();
                    break;
                case "ComboBox":
                    ComboBoxModel = new ComboBoxModel();
                    break;
            }
        }
        #endregion GenericMethods
        #region Numeric Boxes
        private void OnNumericButtonClick(object parameter)
        {
            if (SelectedProtocolItem == null)
                return;
            if (SelectedProtocolItem.Equals("TextBox"))
                KeysGeneric(0, 20, TextBoxModel, parameter, "Lines");
            if (SelectedProtocolItem.Equals("TextBlock"))
                KeysGeneric(0, 2000, TextBlockModel, parameter);
            if (SelectedProtocolItem.Equals("CheckBox"))
                KeysGeneric(0, 2000, CheckBoxModel, parameter);
            if (SelectedProtocolItem.Equals("ComboBox"))
                KeysGeneric(0, 2000, ComboBoxModel, parameter);
        }
        private void KeysGeneric(int minimum, int maximum, GenericModel model, object parameter, string key="MinWidth")
        {
            if (key.Equals("Lines"))
            {
                model.Lines += parameter.Equals("UP") ? 1 : -1;
                if (model.Lines <= minimum) model.Lines = minimum;
                if (model.Lines >= maximum) model.Lines = maximum;
                return;
            }
            model.MinWidth += parameter.Equals("UP") ? 1 : -1;
            if (model.MinWidth <= minimum) model.MinWidth = minimum;
            if (model.MinWidth >= maximum) model.MinWidth = maximum;
            return;
        }
        #endregion Numeric Boxes
        #region GenerateCodeMethods
        private void OnGenerateButtonClick()
        {
            RaisePropertyChanged(nameof(PreviewResult));
        }
        public string PreviewResult { get => OnPreviewGenerate(); }
        private string OnPreviewGenerate()
        {
            if (SelectedProtocolItem == null)
                return "Для предпросмотра необходимо выбрать элемент";
            string buffer = string.Empty;
            switch (SelectedProtocolItem)
            {
                case "TextBox":
                    {
                        buffer += CreateXMLElement("StartBlock");
                        buffer += CreateXMLElement("CreateType", SelectedProtocolItem);
                        buffer += CreateXMLElement("Id", TextBoxModel.ID);
                        buffer += CreateXMLElement("Name", TextBoxModel.Name, false);
                        buffer += CreateXMLElement("Value", TextBoxModel.Value);
                        buffer += CreateXMLElement("IsEnabled", TextBoxModel.IsEnabled);
                        buffer += CreateXMLElement("IsStretch", TextBoxModel.IsStretch);
                        buffer += CreateXMLElement("IsVisible", TextBoxModel.IsVisible);
                        buffer += CreateXMLElement("IsLabelVisible", TextBoxModel.IsLabelVisible);
                        buffer += CreateXMLElement("IsBoldLabel", TextBoxModel.IsBoldLabel);
                        buffer += CreateXMLElement("IsConclusion", TextBoxModel.IsConclusion);
                        buffer += CreateXMLElement("Lines", TextBoxModel.Lines, !TextBoxModel.Lines.Equals(0));
                        buffer += CreateXMLElement("EndBlock");
                    }
                    break;
                case "TextBlock":
                    {
                        buffer += CreateXMLElement("StartBlock");
                        buffer += CreateXMLElement("CreateType", SelectedProtocolItem);
                        buffer += CreateXMLElement("Id", TextBlockModel.ID);
                        buffer += CreateXMLElement("Name", TextBlockModel.Name, false);
                        buffer += CreateXMLElement("Value", TextBlockModel.Value);
                        buffer += CreateXMLElement("IsEnabled", TextBlockModel.IsEnabled);
                        buffer += CreateXMLElement("IsStretch", TextBlockModel.IsStretch);
                        buffer += CreateXMLElement("IsVisible", TextBlockModel.IsVisible);
                        buffer += CreateXMLElement("IsBold", TextBlockModel.IsBold);
                        buffer += CreateXMLElement("MinWidth", TextBlockModel.MinWidth, !TextBlockModel.MinWidth.Equals(0));
                        buffer += CreateXMLElement("EndBlock");
                    }
                    break;
                case "Date":
                    {
                        buffer += CreateXMLElement("StartBlock");
                        buffer += CreateXMLElement("CreateType", SelectedProtocolItem);
                        buffer += CreateXMLElement("Id", DateModel.ID);
                        buffer += CreateXMLElement("Name", DateModel.Name, false);
                        buffer += CreateXMLElement("IsEnabled", DateModel.IsEnabled);
                        buffer += CreateXMLElement("IsVisible", DateModel.IsVisible);
                        buffer += CreateXMLElement("IsLabelVisible", DateModel.IsLabelVisible);
                        buffer += CreateXMLElement("EndBlock");
                    }
                    break;
                case "CheckBox":
                    {
                        buffer += CreateXMLElement("StartBlock");
                        buffer += CreateXMLElement("CreateType", SelectedProtocolItem);
                        buffer += CreateXMLElement("Id", CheckBoxModel.ID);
                        buffer += CreateXMLElement("Name", CheckBoxModel.Name, false);
                        buffer += CreateXMLElement("TextTrue", CheckBoxModel.TextTrue);
                        buffer += CreateXMLElement("TextFalse", CheckBoxModel.TextFalse);
                        buffer += CreateXMLElement("IsEnabled", CheckBoxModel.IsEnabled);
                        buffer += CreateXMLElement("IsVisible", CheckBoxModel.IsVisible);
                        buffer += CreateXMLElement("IsLabelVisible", CheckBoxModel.IsLabelVisible);
                        buffer += CreateXMLElement("MinWidth", CheckBoxModel.MinWidth, !CheckBoxModel.MinWidth.Equals(0));
                        buffer += CreateXMLElement("EndBlock");
                    }
                    break;
                case "ComboBox":
                    {
                        buffer += CreateXMLElement("StartBlock");
                        buffer += CreateXMLElement("CreateType", SelectedProtocolItem);
                        buffer += CreateXMLElement("Id", ComboBoxModel.ID);
                        buffer += CreateXMLElement("Name", ComboBoxModel.Name, false);
                        buffer += CreateXMLElement("MinWidth", ComboBoxModel.MinWidth, !CheckBoxModel.MinWidth.Equals(0));
                        buffer += CreateXMLElement("IsEnabled", ComboBoxModel.IsEnabled);
                        buffer += CreateXMLElement("IsVisible", ComboBoxModel.IsVisible);
                        buffer += CreateXMLElement("IsLabelVisible", ComboBoxModel.IsLabelVisible);
                        buffer += CreateXMLElement("IsTextEditable", ComboBoxModel.IsTextEditable);
                        buffer += CreateXMLElement("IsConclusionTemplate", ComboBoxModel.IsConclusionTemplate);
                        buffer += CreateXMLElement("IsSelectedFromNetrika", ComboBoxModel.IsSelectedFromNetrika);
                        buffer += CreateXMLElement("IsUseNetrika", ComboBoxModel.IsUseNetrika);
                        buffer += CreateXMLElement("Value", ComboBoxModel.Value);
                        string tmpCollection = ComboBoxModel.Value;
                        foreach (string item in ComboBoxModel.Values)
                        {
                            tmpCollection += $"|{item}";
                        }
                        buffer += CreateXMLElement("Values", tmpCollection);
                        buffer += CreateXMLElement("EndBlock");
                    }
                    break;
            }
            return buffer;
        }
        private string CreateXMLElement(string key, object value=null, bool ifNullAddValue=true)
        {
            if (key.Equals("StartBlock"))
                return "<";
            if (key.Equals("EndBlock"))
                return " />";
            if (key.Equals("CreateType"))
                return value + $" itemType=\"{value}\"";

            string temp = string.Empty;
            temp = $" {key}=\"";

            if (value is bool)
                return temp += value.ToString().ToLower();
            if (value is string)
            {
                if (string.IsNullOrEmpty((string)value))
                    if (ifNullAddValue)
                        return temp += value.ToString() + "\"";
                    else
                        return string.Empty;
                value = value.ToString().Replace("\r\n", "\\r\\n");
                while (value.ToString().Contains("\""))
                {
                    value = value.ToString().Replace("\"", "'");
                }
                while (value.ToString().Contains(">"))
                {
                    value = value.ToString().Replace(">", "&#707;");
                }
                while (value.ToString().Contains("<"))
                {
                    value = value.ToString().Replace("<", "&#706;");
                }
                return temp += value + "\"";
            }
            if (value is int)
            {
                if (ifNullAddValue)
                    return $" {key}=\"{value}\"";
                else
                    return string.Empty;
            }

            return "Ошибка";
        }
        #endregion GenerateCodeMethods
        #region ComboBox - ListBox items
        private void OnAddListBoxItemCB()
        {
            ComboBoxModel.Values.Add(CBListBoxTemplateItem);
            CBListBoxTemplateItem = null;
        }
        private void OnEditListBoxItemCB()
        {
            var currentIndex = ComboBoxModel.Values.IndexOf(CBListBoxSelectedItem);
            ComboBoxModel.Values[currentIndex] = CBListBoxTemplateItem;
            CBListBoxSelectedItem = ComboBoxModel.Values[currentIndex];
        }
        private void OnDeleteListBoxItemCB()
        {
            ComboBoxModel.Values.Remove(CBListBoxSelectedItem);
        }
        #endregion ComboBox - ListBox items
        #endregion Methods
    }
}
