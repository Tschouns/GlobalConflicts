using System.Collections.Generic;

namespace Services.Parser
{
    public class Side
    {
        private readonly IList<string> actors = new List<string>();

        public IList<string> Actors => this.actors;
    }
}
