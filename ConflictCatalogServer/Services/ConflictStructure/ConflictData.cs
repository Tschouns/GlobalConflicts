using System.Collections.Generic;

namespace Services.ConflictStructure
{
    public class ConflictData
    {
        private readonly IList<SideData> sides = new List<SideData>();
        
        public string Summary { get; set; }
        public string CommonName { get; set; }
        public int StartYear { get; set; }
        public int EndYear { get; set; }
        public int NumberOfFatalities { get; set; }

        public IList<SideData> Sides => this.sides;
    }
}
