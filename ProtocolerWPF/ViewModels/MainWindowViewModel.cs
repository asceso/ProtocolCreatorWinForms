using CommonMethods;
using CommonModels;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Regions;
using ProtocolerWPF.Properties;
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
        private bool themeInit = false;
        private SettingsModel settings;
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
        public SettingsModel Settings
        {
            get => settings;
            set
            {
                SetProperty(ref settings, value);
            }
        }
        #endregion Properties

        #region Ctor
        public MainWindowViewModel(IRegionManager regionManager, IUnityContainer container)
        {
            themes = Application.Current.Resources.MergedDictionaries.ToArray();
            Settings = SettingsMethods.ReadSettingsFromJson();
            CurrentTheme = Settings.DefaultTheme.Equals("Темная") ? Resources.DarkThemeIconPath : Resources.LightThemeIconPath;
            OnChangeTheme();

            this.regionManager = regionManager;
            this.container = container;

            ChangeThemeCommand = new DelegateCommand(OnChangeTheme);
            CloseApplicationCommand = new DelegateCommand(()=> Application.Current.Shutdown());
            MinimizeApplicationCommand = new DelegateCommand(OnMinimizeApplication);
            MaximizeApplicationCommand = new DelegateCommand(OnMaximizeApplication);
        }
        public void AfterInit()
        {
            regionManager.RequestNavigate("MainRegion", "ProtocolsView");
        }
        #endregion Ctor

        #region Methods
        private void OnChangeTheme()
        {
            Application.Current.Resources.MergedDictionaries.Clear();
            if (themeInit)
            {
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
            else
            {
                Application.Current.Resources.MergedDictionaries.Add(
                    CurrentTheme.Equals(Properties.Resources.DarkThemeIconPath) ? themes[0] : themes[1]);
                themeInit = true;
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
