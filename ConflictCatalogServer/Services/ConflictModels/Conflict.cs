using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Services.ConflictModels
{
    [DataContract]
    public class Conflict
    {
        private readonly IList<Side> sides = new List<Side>();

        [DataMember]
        public string Summary { get; set; }

        [DataMember]
        public IList<Side> Sides => this.sides;
    }
}
