using Prism.Mvvm;
using System;
using static CommonModels.CommonEnums;

namespace CommonModels.ProtocolElementsModels.InheritModels
{
    public class TreeItemModel : BindableBase
    {
        private string _header;
        private string _modelType;
        private GenericModel _model;
        private int _level;
        private int _orientation;

        public string Header { get => _header; set => SetProperty(ref _header, value); }
        public string ModelType { get => _modelType; set => SetProperty(ref _modelType, value); }
        public GenericModel Model { get => _model; set => SetProperty(ref _model, value); }
        public int Level { get => _level; set => SetProperty(ref _level, value); }
        public int Orientation { get => _orientation; set => SetProperty(ref _orientation, value); }

        public TreeItemModel()
        {
            Header = string.Empty;
            ModelType = string.Empty;
            Level = 0;
            Orientation = 0;
        }

        public string GetHeader()
        {
            return $"Уровень: {Enum.GetName(typeof(LevelDescriptionRus), Level)} " +
                   $"Название: {Header} " +
                   $"Тип элемента: {ModelType} ";
        }
    }
}
