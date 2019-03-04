using System.Collections.Generic;

namespace Services.ConflictStructureModels
{
    public class Conflict
    {
        private readonly IList<Side> sides = new List<Side>();
        
        public string Summary { get; set; }
        public string CommonName { get; set; }
        public int StartYear { get; set; }
        public int EndYear { get; set; }
        public int NumberOfFatalities { get; set; }

        public IList<Side> Sides => this.sides;
    }
}
