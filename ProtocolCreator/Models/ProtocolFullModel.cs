using System.Collections.Generic;

namespace ProtocolCreator.Models
{
    class ProtocolFullModel
    {
        public string ID { get; set; }
        public string Name { get; set; }
        public string ProtocolHeader { get; set; }
        public string Conclusion { get; set; }
        public List<ProtocolElementModel> Elements { get; set; }
        public ProtocolFullModel()
        {
            Elements = new List<ProtocolElementModel>();
        }
    }
}
