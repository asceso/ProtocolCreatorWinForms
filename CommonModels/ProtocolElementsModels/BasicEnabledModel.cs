using Prism.Mvvm;

namespace CommonModels.ProtocolElementsModels
{
    public class BasicEnabledModel : BindableBase
    {
        public enum EnabledState
        {
            NotUsed, Disabled, Enabled
        }

        private int _enableState; 
        private string _modelId; 
        private string _modelName;
        private string _modelToolTip;
        public int EnableState { get => _enableState; set => SetProperty(ref _enableState, value); }
        public string ModelId { get => _modelId; set => SetProperty(ref _modelId, value); }
        public string ModelName { get => _modelName; set => SetProperty(ref _modelName, value); }
        public string ModelToolTip { get => _modelToolTip; set => SetProperty(ref _modelToolTip, value); }
    }
}
