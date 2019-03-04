using System.Collections.Generic;

namespace Services.ConflictStructure
{
    public class SideData
    {
        private readonly IList<ActorData> actors = new List<ActorData>();

        public IList<ActorData> Actors => this.actors;
    }
}
