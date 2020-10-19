using Prism.Commands;
using Prism.Modularity;
using Prism.Mvvm;
using Prism.Regions;
using ProtocolerWPF.Views;
using ProtocolViewer.Views;
using System.Linq;
using System.Windows;
using System.Windows.Input;
using Unity;

namespace ProtocolerWPF.ViewModels
{
    public class MainWindowViewModel : BindableBase
    {
        #region Fields
        private readonly IRegionManager regionManager;
        private readonly IUnityContainer container;
        private string title = "Конструктор протоколов";
        private ResourceDictionary[] themes;
        private string currentTheme;
        #endregion Fields

        #region Commands
        public ICommand ChangeThemeCommand { get; private set; }
        public ICommand CloseApplicationCommand { get; private set; }
        public ICommand MinimizeApplicationCommand { get; private set; }
        public ICommand MaximizeApplicationCommand { get; private set; }
        #endregion Commands

        #region Properties
        public string Title
        {
            get => title;
            set
            {
                SetProperty(ref title, value);
            }
        }
        public string CurrentTheme 
        {
            get => currentTheme;
            set
            {
                SetProperty(ref currentTheme, value);
            }
        }
        #endregion Properties

        #region Ctor
        public MainWindowViewModel(IRegionManager regionManager, IUnityContainer container)
        {
            themes = Application.Current.Resources.MergedDictionaries.ToArray();
            CurrentTheme = Properties.Resources.DarkThemeIconPath;
            OnChangeTheme();

            this.regionManager = regionManager;
            this.container = container;

            ChangeThemeCommand = new DelegateCommand(OnChangeTheme);
            CloseApplicationCommand = new DelegateCommand(()=> Application.Current.Shutdown());
            MinimizeApplicationCommand = new DelegateCommand(OnMinimizeApplication);
            MaximizeApplicationCommand = new DelegateCommand(OnMaximizeApplication);

            //container.RegisterType<object, Test>(nameof(Test));
        }
        public void AfterInit()
        {
            //var moduleManager = container.Resolve<IModuleManager>();
            //moduleManager.LoadModule(nameof(ProtocolViewer.ProtocolViewerModule));
            //regionManager.RequestNavigate("MainRegion", nameof(Test));

            regionManager.RequestNavigate("MainRegion", nameof(ProtocolsView));
        }
        #endregion Ctor

        #region Methods
        private void OnChangeTheme()
        {
            Application.Current.Resources.MergedDictionaries.Clear();
            if (CurrentTheme.Equals(Properties.Resources.DarkThemeIconPath))
            {
                Application.Current.Resources.MergedDictionaries.Add(themes[1]);
                CurrentTheme = Properties.Resources.LightThemeIconPath;
            }
            else
            {
                Application.Current.Resources.MergedDictionaries.Add(themes[0]);
                CurrentTheme = Properties.Resources.DarkThemeIconPath;
            }
        }
        private void OnMinimizeApplication()
        {
            Application.Current.MainWindow.WindowState = WindowState.Minimized;
        }
        private void OnMaximizeApplication()
        {
            Application.Current.MainWindow.WindowState = Application.Current.MainWindow.WindowState == WindowState.Maximized
                ? WindowState.Normal
                : WindowState.Maximized;
        }
        #endregion Methods
    }
}
