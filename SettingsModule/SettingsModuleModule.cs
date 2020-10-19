using Prism.Ioc;
using Prism.Modularity;
using Prism.Mvvm;
using Prism.Regions;
using SettingsModule.ViewModels;
using SettingsModule.Views;
using Unity;

namespace SettingsModule
{
    public class SettingsModuleModule : IModule
    {
        private readonly IRegionManager regionManager;
        private readonly IUnityContainer container;
        public SettingsModuleModule(IRegionManager regionManager, IUnityContainer container)
        {
            this.regionManager = regionManager;
            this.container = container;
        }
        public void OnInitialized(IContainerProvider containerProvider)
        {
            container.RegisterType<object, SettingsView>(nameof(SettingsView));
        }

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            ViewModelLocationProvider.Register(typeof(SettingsView).ToString(), typeof(SettingsViewVM));
        }
    }
}