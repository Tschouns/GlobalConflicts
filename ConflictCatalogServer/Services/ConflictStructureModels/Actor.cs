using System.Runtime.Serialization;

namespace Services.ConflictStructureModels
{
    [DataContract]
    public class Actor
    {
        [DataMember]
        public string FullName { get; set; }

        [DataMember]
        public string Location { get; set; }
    }
}
