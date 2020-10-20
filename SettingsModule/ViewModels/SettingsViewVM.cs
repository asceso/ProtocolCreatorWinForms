using CommonMethods;
using CommonModels;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Regions;
using System;
using System.IO;
using System.Windows.Input;

namespace SettingsModule.ViewModels
{
    public class SettingsViewVM : BindableBase, IConfirmNavigationRequest
    {
        #region Fields
        private NavigationParameters parameters;
        private readonly IRegionManager regionManager;
        private SettingsModel settings;
        #endregion Fields
        #region Properties
        public SettingsModel Settings
        {
            get => settings;
            set
            {
                SetProperty(ref settings, value);
            }
        }
        public string[] Themes
        {
            get => new string[] { "Светлая", "Темная" };
        }
        #endregion
        #region Commands
        public ICommand SaveAndExitCommand { get; private set; }
        #endregion Commands
        #region Ctor
        public SettingsViewVM(IRegionManager regionManager)
        {
            Settings = LoadingSettings();
            this.regionManager = regionManager;
            SaveAndExitCommand = new DelegateCommand(OnSaveAndExit);
        }
        #endregion Ctor
        #region Methods
        private SettingsModel LoadingSettings()
        {
            return SettingsMethods.ReadSettingsFromJson();
        }
        private void OnSaveAndExit()
        {
            SettingsMethods.SaveSettingsToJson(settings);
            regionManager.RequestNavigate("MainRegion", parameters["backUri"].ToString());
        }
        #endregion
        #region Navigation
        public void OnNavigatedTo(NavigationContext navigationContext)
        {
            parameters = navigationContext.Parameters;
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
