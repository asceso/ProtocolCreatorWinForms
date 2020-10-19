using ProtocolViewer.Views;
using Prism.Ioc;
using Prism.Modularity;
using Prism.Regions;
using Unity;
using Prism.Mvvm;
using ProtocolViewer.ViewModels;

namespace ProtocolViewer
{
    public class ProtocolViewerModule : IModule
    {
        private readonly IRegionManager regionManager;
        private readonly IUnityContainer container;
        public ProtocolViewerModule(IRegionManager regionManager, IUnityContainer container)
        {
            this.regionManager = regionManager;
            this.container = container;
        }

        public void OnInitialized(IContainerProvider containerProvider)
        {
            container.RegisterType<object, ProtocolsView>(nameof(ProtocolsView));
        }

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            ViewModelLocationProvider.Register(typeof(ProtocolsView).ToString(), typeof(ProtocolsViewVM));
        }
    }
}