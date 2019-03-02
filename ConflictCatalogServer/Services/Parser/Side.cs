using System.Collections.Generic;

namespace Services.Parser
{
    public class Side
    {
        private readonly IList<Actor> actors = new List<Actor>();

        public IList<Actor> Actors => this.actors;
    }
}
