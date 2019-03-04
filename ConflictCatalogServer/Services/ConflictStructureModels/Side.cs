using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Services.ConflictStructureModels
{
    [DataContract]
    public class Side
    {
        private readonly IList<Actor> actors = new List<Actor>();

        [DataMember]
        public IList<Actor> Actors => this.actors;
    }
}
