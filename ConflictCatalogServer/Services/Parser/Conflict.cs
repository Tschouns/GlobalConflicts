using System.Collections.Generic;

namespace Services.Parser
{
    public class Conflict
    {
        private readonly IList<Side> sides = new List<Side>();

        public string Summary { get; set; }
        public IList<Side> Sides => this.sides;
    }
}
