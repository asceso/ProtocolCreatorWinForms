using Prism.Commands;
using Prism.Mvvm;
using Prism.Regions;
using ProtocolViewer.Views;
using System.Windows.Input;

namespace ProtocolViewer.ViewModels
{
    public class ProtocolsViewVM : BindableBase
    {
        #region Fields
        private readonly IRegionManager regionManager;
        #endregion Fields
        #region Properties
        #endregion
        #region Commands
        public ICommand OpenSettingsCommand { get; private set; }
        #endregion Commands
        #region Ctor
        public ProtocolsViewVM(IRegionManager regionManager)
        {
            this.regionManager = regionManager;
            OpenSettingsCommand = new DelegateCommand(OnOpenSettings);
        }
        #endregion Ctor
        #region Methods
        private void OnOpenSettings()
        {
            NavigationParameters nav = new NavigationParameters();
            nav.Add("backUri", nameof(ProtocolsView));
            regionManager.RequestNavigate("MainRegion", "SettingsView",nav);
        }
        #endregion Methods
    }
}
