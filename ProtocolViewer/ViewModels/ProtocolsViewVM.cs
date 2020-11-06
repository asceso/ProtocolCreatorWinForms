using CommonMethods;
using CommonModels.ProtocolElementsModels;
using CommonModels.ProtocolElementsModels.InheritModels;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Regions;
using ProtocolViewer.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Linq;
using System.Windows.Input;
using Unity;
using static CommonModels.CommonEnums;
using static CommonModels.ProtocolElementsModels.BasicEnabledModel;

namespace ProtocolViewer.ViewModels
{
    public class ProtocolsViewVM : BindableBase
    {
        #region Fields
        private readonly IRegionManager regionManager;
        private readonly IUnityContainer container;

        private string selectedProtocolItem;
        private string selectedLevel;
        private string selectedOrientation;

        private string cbListBoxSelectedItem;
        private string cbListBoxTemplateItem;

        private string newElementName;
        private int customSelectedIndex;

        private TextBoxModel textBoxModel;
        private TextBlockModel textBlockModel;
        private DateModel dateModel;
        private CheckBoxModel checkBoxModel;
        private ComboBoxModel comboBoxModel;
        private NumericModel numericModel;
        private HeaderAndFooterModel headerAndFooterModel;
        private ObservableCollection<TreeItemModel> customModel;
        private object CurrentModel;

        public string[] AvailableItems { get => Enum.GetNames(typeof(ItemTypes)); }
        public string[] AvailableLevels { get => Enum.GetNames(typeof(LevelDescriptionRus)); }
        public string[] AvailableOrientation { get => Enum.GetNames(typeof(OrientationsRus)); }

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
        private bool SelectedProtocolItemHasValue() => SelectedProtocolItem != null;

        #endregion SelectedProtocolType

        #region SelectedLevel

        public string SelectedLevel
        {
            get => selectedLevel;
            set
            {
                SetProperty(ref selectedLevel, value);
                RaisePropertyChanged(nameof(IsSelectedLevelRoot));
            }
        }
        private bool SelectedLevelHasValue => SelectedLevel != null;

        #endregion SelectedLevel

        #region SelectedOrientation

        public string SelectedOrientation
        {
            get => selectedOrientation;
            set => SetProperty(ref selectedOrientation, value);
        }

        private bool SelectedOrientationHasValue => SelectedOrientation != null;

        public bool IsSelectedLevelRoot { get => SelectedLevelHasValue && !SelectedLevel.Equals(AvailableLevels[0]); }

        #endregion SelectedLevel

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
        private bool CBListBoxSelectedItemHasValue => CBListBoxSelectedItem != null;

        public string CBListBoxTemplateItem
        {
            get => cbListBoxTemplateItem;
            set => SetProperty(ref cbListBoxTemplateItem, value);
        }
        private bool CBListBoxTemplateItemHasValue => CBListBoxTemplateItem != null;

        #endregion SelectedComboBoxListItem

        #region SelectedCustomModel

        #region index

        public int CustomSelectedIndex
        {
            get => customSelectedIndex;
            set
            {
                SetProperty(ref customSelectedIndex, value);
                if (customSelectedIndex.Equals(-1))
                {
                    OnResetCurrentModel();
                    return;
                }
                SelectedProtocolItem = CustomModel[CustomSelectedIndex].ModelType;
                MapModel(CustomModel[CustomSelectedIndex].Model, GetModelType());
                OnPreviewGenerate();
            }
        }

        public bool CustomSelectedIndexHasValue => !CustomSelectedIndex.Equals(-1);

        #endregion index

        #region item

        public TreeItemModel CustomModelSelectedItem => CustomSelectedIndexHasValue ? CustomModel[CustomSelectedIndex] : null;
        private bool CustomModelSelectedItemHasValue => CustomModelSelectedItem != null;

        #endregion item

        #region Model

        public bool CustomModelHasItems { get => CustomModel.Any(); }

        #endregion Model

        #region Model.NewElement
        public string NewElementName 
        { 
            get => newElementName;
            set => SetProperty(ref newElementName, value);
        }
        public bool NewElementNameHasValue => NewElementName != null;

        #endregion Model.NewElement

        #endregion SelectedCustomModel

        #region VisibilityBlocks

        public bool TextBoxItemVisibility => SelectedProtocolItemHasValue() && SelectedProtocolItem.Equals("TextBox");
        public bool TextBlockItemVisibility => SelectedProtocolItemHasValue() && SelectedProtocolItem.Equals("TextBlock");
        public bool DateItemVisibility => SelectedProtocolItemHasValue() && SelectedProtocolItem.Equals("Date");
        public bool CheckBoxItemVisibility => SelectedProtocolItemHasValue() && SelectedProtocolItem.Equals("CheckBox");
        public bool ComboBoxItemVisibility => SelectedProtocolItemHasValue() && SelectedProtocolItem.Equals("ComboBox");
        public bool NumericVisibility => SelectedProtocolItemHasValue() && SelectedProtocolItem.Equals("NumericBox");

        private void CheckAllVisibility()
        {
            RaisePropertyChanged(nameof(TextBoxItemVisibility));
            RaisePropertyChanged(nameof(TextBlockItemVisibility));
            RaisePropertyChanged(nameof(DateItemVisibility));
            RaisePropertyChanged(nameof(CheckBoxItemVisibility));
            RaisePropertyChanged(nameof(ComboBoxItemVisibility));
            RaisePropertyChanged(nameof(NumericVisibility));
        }

        #endregion VisibilityBlocks

        #region Models

        public TextBoxModel TextBoxModel { get => textBoxModel; set => SetProperty(ref textBoxModel, value); }
        public TextBlockModel TextBlockModel { get => textBlockModel; set => SetProperty(ref textBlockModel, value); }
        public DateModel DateModel { get => dateModel; set => SetProperty(ref dateModel, value); }
        public CheckBoxModel CheckBoxModel { get => checkBoxModel; set => SetProperty(ref checkBoxModel, value); }
        public ComboBoxModel ComboBoxModel { get => comboBoxModel; set => SetProperty(ref comboBoxModel, value); }
        public NumericModel NumericModel { get => numericModel; set => SetProperty(ref numericModel, value); }
        public HeaderAndFooterModel HeaderAndFooterModel { get => headerAndFooterModel; set => SetProperty(ref headerAndFooterModel, value); }
        public ObservableCollection<TreeItemModel> CustomModel { get => customModel; set => SetProperty(ref customModel, value); }

        #endregion models

        #region Header Collection

        public string[] CustomModelHeaders
        {
            get
            {
                List<string> temp = new List<string>();
                foreach (var item in CustomModel)
                    temp.Add(item.GetHeader());
                return temp.ToArray();
            }
        }

        #endregion Header Collection

        public string[] AvailableStates { get => Enum.GetNames(typeof(EnabledState)); }

        #endregion Properties

        #region Commands

        public ICommand OpenSettingsCommand { get; private set; }
        public ICommand OpenGeneratingViewCommand { get; private set; }
        public ICommand NumericClickCommand { get; private set; }
        public ICommand GenerateCodeCommand { get; private set; }
        public ICommand ResetCurrentModelCommand { get; private set; }
        public ICommand ResetHeaderAndFooteModel { get; private set; }
        public ICommand ResetProtocolCommand { get; private set; }
        public ICommand CBAddListBoxItem { get; private set; }
        public ICommand CBEditListBoxItem { get; private set; }
        public ICommand CBDeleteListBoxItem { get; private set; }
        public ICommand AddNewElementInCollection { get; private set; }
        public ICommand DeleteSelectedCustomItemCommand { get; private set; }
        public ICommand ClearCustomCollectionCommand { get; private set; }

        #endregion Commands

        #region Ctor

        public ProtocolsViewVM(IRegionManager regionManager, IUnityContainer container)
        {
            this.regionManager = regionManager;
            this.container = container;

            SelectedLevel = AvailableLevels
                .FirstOrDefault(x => x.Equals(Enum.GetName(typeof(LevelDescriptionRus), LevelDescriptionRus.Корень)));
            SelectedOrientation = AvailableOrientation
                .FirstOrDefault(x=> x.Equals(Enum.GetName(typeof(OrientationsRus), OrientationsRus.Горизонтально)));

            TextBoxModel = new TextBoxModel();
            TextBlockModel = new TextBlockModel();
            DateModel = new DateModel();
            CheckBoxModel = new CheckBoxModel();
            ComboBoxModel = new ComboBoxModel();
            NumericModel = new NumericModel();
            HeaderAndFooterModel = new HeaderAndFooterModel();

            CustomModel = new ObservableCollection<TreeItemModel>();
            CustomModel.CollectionChanged += CustomModelCollectionChanged;

            OpenSettingsCommand = new DelegateCommand(OnOpenSettings);
            OpenGeneratingViewCommand = new DelegateCommand(OnOpenGeneratingView, () => CustomModelHasItems)
                .ObservesProperty(() => CustomModelHasItems);

            NumericClickCommand = new DelegateCommand<string>(OnNumericButtonClick);
            GenerateCodeCommand = new DelegateCommand(OnGenerateButtonClick);

            ResetCurrentModelCommand = new DelegateCommand(OnResetCurrentModel);
            ResetHeaderAndFooteModel = new DelegateCommand(OnResetHeaderAndFooter);
            ResetProtocolCommand = new DelegateCommand(OnResetProtocol);

            CBAddListBoxItem = new DelegateCommand(OnAddListBoxItemCB, () => CBListBoxTemplateItemHasValue)
                .ObservesProperty(() => CBListBoxTemplateItem);
            CBEditListBoxItem = new DelegateCommand(OnEditListBoxItemCB, () => CBListBoxSelectedItemHasValue)
                .ObservesProperty(() => CBListBoxSelectedItem);
            CBDeleteListBoxItem = new DelegateCommand(OnDeleteListBoxItemCB, () => CBListBoxSelectedItemHasValue)
                .ObservesProperty(() => CBListBoxSelectedItem);

            DeleteSelectedCustomItemCommand = new DelegateCommand(OnDeleteSelectedCustomItem, () => CustomModelHasItems)
                .ObservesProperty(() => CustomSelectedIndexHasValue)
                .ObservesProperty(() => CustomModelHasItems);

            ClearCustomCollectionCommand = new DelegateCommand(()=> CustomModel.Clear(), () => CustomModelHasItems)
                .ObservesProperty(() => CustomModelHasItems);

            AddNewElementInCollection = new DelegateCommand(OnAddElemntInCollection);
        }

        #endregion Ctor

        #region Methods

        #region NavigationMethods
        private void OnOpenSettings()
        {
            NavigationParameters nav = new NavigationParameters();
            nav.Add("backUri", nameof(ProtocolsView));
            regionManager.RequestNavigate("MainRegion", "SettingsView",nav);
        }
        private void OnOpenGeneratingView()
        {
            NavigationParameters nav = new NavigationParameters();
            nav.Add("backUri", nameof(ProtocolsView));
            nav.Add("model", CustomModel);
            nav.Add("header", HeaderAndFooterModel);
            regionManager.RequestNavigate("MainRegion", "ProtocolGeneratedView", nav);
        }

        #endregion NavigationMethods

        #region Model methods

        #region Reset methods
        //todo: Спрашивать разрешение
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
                case "NumericBox":
                    NumericModel = new NumericModel();
                    break;
            }
            OnPreviewGenerate();
        }
        //todo: Спрашивать разрешение
        private void OnResetHeaderAndFooter()
        {
            HeaderAndFooterModel = new HeaderAndFooterModel();
        }
        //todo: Спрашивать разрешение
        private void OnResetProtocol()
        {
            HeaderAndFooterModel = new HeaderAndFooterModel();
            TextBoxModel = new TextBoxModel();
            TextBlockModel = new TextBlockModel();
            DateModel = new DateModel();
            CheckBoxModel = new CheckBoxModel();
            ComboBoxModel = new ComboBoxModel();
            NumericModel = new NumericModel();
            CustomModel.Clear();
        }

        #endregion Reset methods

        private GenericModel GetModelType()
        {
            if (!SelectedProtocolItemHasValue())
                return new GenericModel();
            return SelectedProtocolItem switch
            {
                "TextBox" => TextBoxModel,
                "TextBlock" => TextBlockModel,
                "Date" => DateModel,
                "CheckBox" => CheckBoxModel,
                "ComboBox" => ComboBoxModel,
                "NumericBox" => NumericModel,
                _ => new GenericModel(),
            };
        }

        private void MapModel(object source, object target)
        {
            if (target is TextBoxModel) { TextBoxModel = (TextBoxModel)source; }
            if (target is TextBlockModel) { TextBlockModel = (TextBlockModel)source; }
            if (target is DateModel) { DateModel = (DateModel)source; }
            if (target is CheckBoxModel) { CheckBoxModel = (CheckBoxModel)source; }
            if (target is ComboBoxModel) { ComboBoxModel = (ComboBoxModel)source; }
            if (target is NumericModel) { NumericModel = (NumericModel)source; }
        }

        #endregion Model methods

        #region Collection methods

        private void OnAddElemntInCollection()
        {
            if (!SelectedProtocolItemHasValue())
                return;

            var model = GetModelType();

            TreeItemModel item = new TreeItemModel()
            {
                Header = NewElementNameHasValue && !string.IsNullOrEmpty(NewElementName) ? NewElementName : "No name" ,
                ModelType = SelectedProtocolItem,
                Model = model
            };

            item.Level = Array.IndexOf(AvailableLevels, SelectedLevel);
            item.Orientation = item.Level.Equals(0) ? Array.IndexOf(AvailableOrientation, SelectedOrientation) : 0;

            CustomModel.Add(item);
            CustomSelectedIndex = -1;
        }
        private void OnDeleteSelectedCustomItem()
        {
            if (!CustomModelSelectedItemHasValue || !CustomSelectedIndexHasValue)
                return;
            CustomModel.RemoveAt(CustomSelectedIndex);
            OnPreviewGenerate();
        }

        #region CollectionEvents

        private void CustomModelCollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            switch (e.Action)
            {
                case NotifyCollectionChangedAction.Add:
                    {
                        OnResetCurrentModel();
                        RaisePropertyChanged(nameof(CustomModelHeaders));
                        RaisePropertyChanged(nameof(CustomModelHasItems));
                    }
                    break;
                case NotifyCollectionChangedAction.Remove:
                    {
                        CustomSelectedIndex = -1;
                        RaisePropertyChanged(nameof(CustomModelHeaders));
                        RaisePropertyChanged(nameof(CustomModelHasItems));
                    }
                    break;
                case NotifyCollectionChangedAction.Reset:
                    {
                        RaisePropertyChanged(nameof(CustomModelHeaders));
                        RaisePropertyChanged(nameof(CustomModelHasItems));
                    }
                    break;
            }
        }

        #endregion CollectionEvents

        #endregion Collection methods

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
            if (SelectedProtocolItem.Equals("NumericBox"))
                KeysGeneric(0, 2000, NumericModel, parameter);
            if (SelectedProtocolItem.Equals("NumericBox"))
                KeysGeneric(0, 300, NumericModel, parameter, "Value", 0.1f);
            if (SelectedProtocolItem.Equals("NumericBox"))
                KeysGeneric(0, 300, NumericModel, parameter, "Step", 0.1f);
        }
        private void KeysGeneric(int minimum, int maximum, GenericModel model, object parameter, string key="MinWidth", float step=1)
        {
            if (key.Equals("Lines"))
            {
                model.Lines += parameter.Equals("UP") ? (int)step : (int)-step;
                if (model.Lines <= minimum) model.Lines = minimum;
                if (model.Lines >= maximum) model.Lines = maximum;
                return;
            }
            if (key.Equals("MinWidth"))
            {
                if (parameter.Equals("UP")) model.MinWidth += (int)step;
                if (parameter.Equals("DOWN")) model.MinWidth -= (int)step;
                if (model.MinWidth <= minimum) model.MinWidth = minimum;
                if (model.MinWidth >= maximum) model.MinWidth = maximum;
                return;
            }
            if (key.Equals("Value") && (model is NumericModel))
            {
                if (parameter.Equals("UPValue")) (model as NumericModel).Value += step;
                if (parameter.Equals("DOWNValue")) (model as NumericModel).Value -= step;
                if ((model as NumericModel).Value <= minimum) (model as NumericModel).Value = minimum;
                if ((model as NumericModel).Value >= maximum) (model as NumericModel).Value = maximum;
                return;
            }
            if (key.Equals("Step") && (model is NumericModel))
            {
                if (parameter.Equals("UPStep")) (model as NumericModel).Step += step;
                if (parameter.Equals("DOWNStep")) (model as NumericModel).Step -= step;
                if ((model as NumericModel).Step <= minimum) (model as NumericModel).Step = minimum;
                if ((model as NumericModel).Step >= maximum) (model as NumericModel).Step = maximum;
                return;
            }
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
                case "TextBox" : { CurrentModel = TextBoxModel; buffer = GeneratingMethods.CreateTextBox(TextBoxModel); } break;
                case "TextBlock": { CurrentModel = TextBlockModel; buffer = GeneratingMethods.CreateTextBlock(TextBlockModel); } break;
                case "Date": { CurrentModel = DateModel; buffer = GeneratingMethods.CreateDateBlock(DateModel); } break;
                case "CheckBox": { CurrentModel = CheckBoxModel; buffer = GeneratingMethods.CreateCheckBoxModel(CheckBoxModel); } break;
                case "ComboBox": { CurrentModel = ComboBoxModel; buffer = GeneratingMethods.CreateComboBoxModel(ComboBoxModel); } break;
                case "NumericBox": { CurrentModel = NumericModel; buffer = GeneratingMethods.CreateNumericModel(NumericModel); } break;
            }
            return buffer;
        }

        #endregion GenerateCodeMethods

        #region ComboBox - ListBox items

        private void OnAddListBoxItemCB()
        {
            ComboBoxModel.Values.Add(CBListBoxTemplateItem);
            CBListBoxSelectedItem = ComboBoxModel.Values[ComboBoxModel.Values.Count - 1];
            CBListBoxSelectedItem = null;
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
