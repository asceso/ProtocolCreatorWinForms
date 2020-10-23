using CommonMethods;
using CommonModels.ProtocolElementsModels.InheritModels;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Regions;
using System;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows.Input;

namespace ProtocolViewer.ViewModels
{
    class ProtocolGeneratedViewVM : BindableBase, IConfirmNavigationRequest
    {
        #region Fields
        private NavigationParameters parameters;
        private readonly IRegionManager regionManager;
        private string buffer;
        #endregion
        #region Properties
        private ObservableCollection<TreeItemModel> Model;
        public string Buffer { get => buffer; set => SetProperty(ref buffer, value); }
        #endregion
        public ICommand GoBackCommand { get; private set; }

        public ProtocolGeneratedViewVM(IRegionManager regionManager)
        {
            this.regionManager = regionManager;
            GoBackCommand = new DelegateCommand(OnBackwardNavigation);
        }
        private void DoGeneratingModel()
        {
            Buffer = string.Empty;
            StringBuilder builder = new StringBuilder();

            int tempLevel = 0;
            int stackNumber = 1;

            foreach (var item in Model)
            {
                if (item.Level > tempLevel)
                {
                    builder.AppendLine(GeneratingMethods.CreateStackPanelStart(stackNumber++, item.Orientation, tempLevel));
                    builder.AppendLine(CreateItem(item.ModelType, item.Model, item.Level));
                    tempLevel = item.Level;
                    continue;
                }
                if (item.Level < tempLevel)
                {
                    builder.AppendLine(GeneratingMethods.CreateStackPanelEnd(item.Level));
                    tempLevel = item.Level;
                    builder.AppendLine(CreateItem(item.ModelType, item.Model, item.Level));
                    continue;
                }

                string tmp = string.Empty;
                tmp = CreateItem(item.ModelType, item.Model, item.Level);
                tempLevel = item.Level;
                builder.AppendLine(tmp);
            }
            Buffer = builder.ToString();
        }
        public static string CreateItem(string modelType, object model,int level)
        {
            switch (modelType)
            {
                case "TextBox": return GeneratingMethods.CreateTextBox(model as TextBoxModel, level);
                case "TextBlock": return GeneratingMethods.CreateTextBlock(model as TextBlockModel, level);
                case "Date": return GeneratingMethods.CreateDateBlock(model as DateModel, level);
                case "CheckBox": return GeneratingMethods.CreateCheckBoxModel(model as CheckBoxModel, level);
                case "ComboBox": return GeneratingMethods.CreateComboBoxModel(model as ComboBoxModel, level);
                case "NumericBox": return GeneratingMethods.CreateNumericModel(model as NumericModel, level);
                default : return "Ошибка";
            }
        }
        private void OnBackwardNavigation()
        {
            regionManager.RequestNavigate("MainRegion", parameters["backUri"].ToString());
        }
        #region Navigation
        public void OnNavigatedTo(NavigationContext navigationContext)
        {
            parameters = navigationContext.Parameters;
            Model = parameters["model"] as ObservableCollection<TreeItemModel>;
            DoGeneratingModel();
        }
        public void OnNavigatedFrom(NavigationContext navigationContext)
        {
            return;
        }
        public void ConfirmNavigationRequest(NavigationContext navigationContext, Action<bool> continuationCallback)
        {
            continuationCallback(true);
        }
        public bool IsNavigationTarget(NavigationContext navigationContext)
        {
            return false;
        }
        #endregion Navigation
    }
}
