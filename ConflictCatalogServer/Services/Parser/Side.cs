using System;
using System.Collections.Generic;
using System.Text;

namespace Services.Parser
{
    internal class Side
    {
        private readonly IList<string> actors = new List<string>();

        public IList<string> Actors => this.actors;
    }
}
