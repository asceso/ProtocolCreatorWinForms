using CommonMethods;
using CommonModels.ProtocolElementsModels.InheritModels;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Regions;
using System;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows.Controls;
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
        private HeaderAndFooterModel HeaderAndFooterModel;
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

            builder.Append(GenerateHeader());

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

            Buffer = builder.Append(GenerateFooter()).ToString();
        }
        private string GenerateHeader()
        {
            StringBuilder builder = new StringBuilder();
            builder.AppendLine("<ProtocolTemplateModel xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instance\"" +
                               " xmlns:xsd=\"http://www.w3.org/2001/XMLSchema\">");
            builder.AppendLine($"  <Version>1</Version>");
            builder.AppendLine($"  <Id>{HeaderAndFooterModel.ProtocolID}</Id>");
            builder.AppendLine($"  <Name>{HeaderAndFooterModel.ProtocolName}</Name>");
            builder.AppendLine($"  <Created>2018-11-07T13:00:28.6044778+03:00</Created>");
            builder.AppendLine(GeneratingMethods.CreateStackPanelStart(-1, (int)Orientation.Horizontal,0));
            if (!HeaderAndFooterModel.PatientFullName.EnableState.Equals(0))
            {
                TextBoxModel patient = new TextBoxModel()
                {
                    ID = HeaderAndFooterModel.PatientFullName.ModelId,
                    Name = HeaderAndFooterModel.PatientFullName.ModelName,
                    IsVisible = true,
                    IsLabelVisible = true,
                    ToolTip = HeaderAndFooterModel.PatientFullName.ModelToolTip,
                    IsEnabled = !HeaderAndFooterModel.PatientFullName.EnableState.Equals(1)
                };
                builder.AppendLine(GeneratingMethods.CreateTextBox(patient, 1));
            }
            if (!HeaderAndFooterModel.PatientBirthday.EnableState.Equals(0))
            {
                DateModel birthday = new DateModel()
                {
                    ID = HeaderAndFooterModel.PatientBirthday.ModelId,
                    Name = HeaderAndFooterModel.PatientBirthday.ModelName,
                    IsVisible = true,
                    IsLabelVisible = true,
                    ToolTip = HeaderAndFooterModel.PatientBirthday.ModelToolTip,
                    IsEnabled = !HeaderAndFooterModel.PatientBirthday.EnableState.Equals(1)
                };
                builder.AppendLine(GeneratingMethods.CreateDateBlock(birthday, 1));
            }
            if (!HeaderAndFooterModel.DateSurvey.EnableState.Equals(0))
            {
                DateModel survey = new DateModel()
                {
                    ID = HeaderAndFooterModel.DateSurvey.ModelId,
                    Name = HeaderAndFooterModel.DateSurvey.ModelName,
                    IsVisible = true,
                    IsLabelVisible = true,
                    ToolTip = HeaderAndFooterModel.DateSurvey.ModelToolTip,
                    IsEnabled = !HeaderAndFooterModel.DateSurvey.EnableState.Equals(1)
                };
                builder.AppendLine(GeneratingMethods.CreateDateBlock(survey, 1));
            }
            builder.AppendLine(GeneratingMethods.CreateStackPanelEnd(0));
            builder.AppendLine(GeneratingMethods.CreateTextBox(HeaderAndFooterModel.ProtocolHeader, 0));
            return builder.ToString();
        }
        private string GenerateFooter()
        {
            StringBuilder builder = new StringBuilder();
            if (!HeaderAndFooterModel.Recommendations.EnableState.Equals(0))
            {
                TextBoxModel patient = new TextBoxModel()
                {
                    ID = HeaderAndFooterModel.Recommendations.ModelId,
                    Name = HeaderAndFooterModel.Recommendations.ModelName,
                    IsVisible = true,
                    IsLabelVisible = true,
                    ToolTip = HeaderAndFooterModel.Recommendations.ModelToolTip,
                    IsEnabled = !HeaderAndFooterModel.Recommendations.EnableState.Equals(1)
                };
                builder.AppendLine(GeneratingMethods.CreateTextBox(patient, 1));
            }
            if (!HeaderAndFooterModel.Comments.EnableState.Equals(0))
            {
                TextBoxModel patient = new TextBoxModel()
                {
                    ID = HeaderAndFooterModel.Comments.ModelId,
                    Name = HeaderAndFooterModel.Comments.ModelName,
                    IsVisible = true,
                    IsLabelVisible = true,
                    ToolTip = HeaderAndFooterModel.Comments.ModelToolTip,
                    IsEnabled = !HeaderAndFooterModel.Comments.EnableState.Equals(1)
                };
                builder.AppendLine(GeneratingMethods.CreateTextBox(patient, 1));
            }
            if (!HeaderAndFooterModel.DoctorInitials.EnableState.Equals(0))
            {
                TextBoxModel patient = new TextBoxModel()
                {
                    ID = HeaderAndFooterModel.DoctorInitials.ModelId,
                    Name = HeaderAndFooterModel.DoctorInitials.ModelName,
                    IsVisible = true,
                    IsLabelVisible = true,
                    ToolTip = HeaderAndFooterModel.DoctorInitials.ModelToolTip,
                    IsEnabled = !HeaderAndFooterModel.DoctorInitials.EnableState.Equals(1)
                };
                builder.AppendLine(GeneratingMethods.CreateTextBox(patient, 1));
            }
            builder.Append("</ProtocolTemplateModel>");
            return builder.ToString();
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

        #region Navigation
        private void OnBackwardNavigation()
        {
            regionManager.RequestNavigate("MainRegion", parameters["backUri"].ToString());
        }
        public void OnNavigatedTo(NavigationContext navigationContext)
        {
            parameters = navigationContext.Parameters;
            Model = parameters["model"] as ObservableCollection<TreeItemModel>;
            HeaderAndFooterModel = parameters["header"] as HeaderAndFooterModel;
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
