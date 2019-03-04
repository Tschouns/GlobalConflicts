using System.Collections.Generic;

namespace Services.ConflictStructureModels
{
    public class Side
    {
        private readonly IList<Actor> actors = new List<Actor>();

        public IList<Actor> Actors => this.actors;
    }
}
