using Prism.Mvvm;

namespace CommonModels
{
    public class SettingsModel : BindableBase
    {
        private string defaultTheme;
        public string DefaultTheme
        {
            get => defaultTheme;
            set
            {
                SetProperty(ref defaultTheme, value);
            }
        }
    }
}
