using Prism.Commands;
using Prism.Mvvm;
using Prism.Regions;
using ProtocolViewer.Models;
using ProtocolViewer.Views;
using System;
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
        private TextBoxModel textBoxModel;
        public string[] AvailableItems => new string[]
        {
            "TextBox", "TextBlock", "ComboBox", "StackPanel", "Date", "CheckBox"
        };
        #endregion Fields
        #region Properties
        public string SelectedProtocolItem
        {
            get => selectedProtocolItem;
            set
            {
                SetProperty(ref selectedProtocolItem, value);
                RaisePropertyChanged(nameof(PreviewResult));
                RaisePropertyChanged(nameof(TextBoxItemVisibility));
            }
        }
        public string PreviewResult
        {
            get => OnPreviewGenerate();
        }
        public bool TextBoxItemVisibility 
        {
            get
            {
                if (SelectedProtocolItem != null)
                    return SelectedProtocolItem.Equals("TextBox");
                else
                    return false;
            }
        }
        public TextBoxModel TextBoxModel
        {
            get => textBoxModel;
            set
            {
                SetProperty(ref textBoxModel, value);
            }
        }
        #endregion
        #region Commands
        public ICommand OpenSettingsCommand { get; private set; }
        public ICommand NumericClickCommand { get; private set; }
        public ICommand GenerateCodeCommand { get; private set; }
        #endregion Commands
        #region Ctor
        public ProtocolsViewVM(IRegionManager regionManager, IUnityContainer container)
        {
            TextBoxModel = new TextBoxModel();
            this.regionManager = regionManager;
            this.container = container;
            OpenSettingsCommand = new DelegateCommand(OnOpenSettings);
            NumericClickCommand = new DelegateCommand<string>(OnNumericButtonClick);
            GenerateCodeCommand = new DelegateCommand(OnGenerateButtonClick);
        }
        #endregion Ctor
        #region Methods
        private void OnOpenSettings()
        {
            NavigationParameters nav = new NavigationParameters();
            nav.Add("backUri", nameof(ProtocolsView));
            regionManager.RequestNavigate("MainRegion", "SettingsView",nav);
        }
        private void OnNumericButtonClick(object parameter)
        {
            TextBoxModel.Lines += parameter.Equals("UP") ? 1 : -1;
            if (TextBoxModel.Lines <= 0) TextBoxModel.Lines = 0;
            if (TextBoxModel.Lines >= 50) TextBoxModel.Lines = 50;
        }
        private void OnGenerateButtonClick()
        {
            RaisePropertyChanged(nameof(PreviewResult));
        }
        private string OnPreviewGenerate()
        {
            if (SelectedProtocolItem == null)
                return "Для предпросмотра необходимо выбрать элемент";
            string buffer = string.Empty;
            switch (SelectedProtocolItem)
            {
                case "TextBox": {
                    buffer = $"<TextBox Id=\"{TextBoxModel.ID}\" " +
                            $"Name=\"{TextBoxModel.Name}\" " +
                            $"Value =\"{TextBoxModel.Value}\" " +
                            $"ItemType =\"TextBox\" " +
                            $"IsEnabled =\"{TextBoxModel.IsEnabled.ToString().ToLower()}\" " +
                            $"IsStretch =\"{TextBoxModel.IsStretch.ToString().ToLower()}\" " +
                            $"IsVisible =\"{TextBoxModel.IsVisible.ToString().ToLower()}\" " +
                            $"IsLabelVisible =\"{TextBoxModel.IsLabelVisible.ToString().ToLower()}\" " +
                            $"IsBoldLabel =\"{TextBoxModel.IsBoldLabel.ToString().ToLower()}\" " +
                            $"IsConclusion =\"{TextBoxModel.IsConclusion.ToString().ToLower()}\" " +
                            $"Lines =\"{TextBoxModel.Lines}\" />";
                } break;
            }
            return buffer;
        }
        #endregion Methods
    }
}
