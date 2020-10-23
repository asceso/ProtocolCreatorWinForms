using Prism.Mvvm;
using static CommonModels.ProtocolElementsModels.BasicEnabledModel;

namespace CommonModels.ProtocolElementsModels.InheritModels
{
    public class HeaderAndFooterModel : BindableBase
    {
        private const string PatientDefault = "Пациент";
        private const string BirthdayDefault = "Дата рождения";
        private const string SurveyDefault = "Дата исследования";
        private const string RecomendationDefault = "Рекомендовано";
        private const string CommentDefault = "Комментарий (не печатается)";
        private const string DoctorDefault = "Врач";
        private const string PatientToolTipDefault = "Ф.И.О. пациента";
        private const string BirtdayToolTipDefault = "Дата рождения";
        private const string SurveyToolTipDefault = "Дата исследования";
        private const string ProtocolHeaderNameField = "Заголовок";

        private string _protocolId;
        private string _protocolName;
        private TextBoxModel _protocolHeader;
        private BasicEnabledModel _patientFullName;
        private BasicEnabledModel _patientBirtday;
        private BasicEnabledModel _dateSurvey;
        private BasicEnabledModel _recommendations;
        private BasicEnabledModel _comments;
        private BasicEnabledModel _doctorInitials;

        public string ProtocolID { get => _protocolId; set => SetProperty(ref _protocolId, value); }
        public string ProtocolName { get => _protocolName; set => SetProperty(ref _protocolName, value); }
        public TextBoxModel ProtocolHeader { get => _protocolHeader; set => SetProperty(ref _protocolHeader, value); }

        public BasicEnabledModel PatientFullName { get => _patientFullName; set => SetProperty(ref _patientFullName, value); }
        public BasicEnabledModel PatientBirthday { get => _patientBirtday; set => SetProperty(ref _patientBirtday, value); }
        public BasicEnabledModel DateSurvey { get => _dateSurvey; set => SetProperty(ref _dateSurvey, value); }
        public BasicEnabledModel Recommendations { get => _recommendations; set => SetProperty(ref _recommendations, value); }
        public BasicEnabledModel Comments { get => _comments; set => SetProperty(ref _comments, value); }
        public BasicEnabledModel DoctorInitials { get => _doctorInitials; set => SetProperty(ref _doctorInitials, value); }

        public HeaderAndFooterModel()
        {
            ProtocolID = string.Empty;
            ProtocolName = string.Empty;

            ProtocolHeader = new TextBoxModel()
            {
                ID = nameof(ProtocolName),
                Name = ProtocolHeaderNameField,
                MinWidth = 60,
                IsEnabled = true,
                IsVisible = true,
                Lines = 2
            };

            PatientFullName = new BasicEnabledModel()
            {
                EnableState = (int)EnabledState.Disabled,
                ModelId = nameof(PatientFullName),
                ModelName = PatientDefault,
                ModelToolTip = PatientToolTipDefault
            };
            PatientBirthday = new BasicEnabledModel()
            {
                EnableState = (int)EnabledState.Disabled,
                ModelId = nameof(PatientBirthday),
                ModelName = BirthdayDefault,
                ModelToolTip = BirtdayToolTipDefault
            };
            DateSurvey = new BasicEnabledModel()
            {
                EnableState = (int)EnabledState.Enabled,
                ModelId = nameof(DateSurvey),
                ModelName = SurveyDefault,
                ModelToolTip = SurveyToolTipDefault
            };
            Recommendations = new BasicEnabledModel()
            {
                EnableState = (int)EnabledState.Enabled,
                ModelId = nameof(Recommendations),
                ModelName = RecomendationDefault
            };
            Comments = new BasicEnabledModel()
            {
                EnableState = (int)EnabledState.Enabled,
                ModelId = nameof(Comments),
                ModelName = CommentDefault
            };
            DoctorInitials = new BasicEnabledModel()
            {
                EnableState = (int)EnabledState.Disabled,
                ModelId = nameof(DoctorInitials),
                ModelName = DoctorDefault
            };
        }
    }
}
