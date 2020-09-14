namespace ProtocolCreator
{
    internal class ProtocolElementModel
    {
        public string ID { get; set; }
        public string Name { get; set; }
        public string Value { get; set; }
        public string Type { get; set; }
        public ProtocolElementModel()
        {
            ID = nameof(ID);
            Value = nameof(Value);
        }
    }
}
