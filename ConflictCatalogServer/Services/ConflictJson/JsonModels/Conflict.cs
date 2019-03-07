using System;
using System.Collections.Generic;
using System.Text;

namespace Services.ConflictJson.JsonModels
{
    public class Conflict
    {
        private readonly IList<Actor> actors = new List<Actor>();

        public string Summary { get; set; }
        public string CommonName { get; set; }
        public int StartYear { get; set; }
        public int EndYear { get; set; }
        public int NumberOfFatalities { get; set; }
        public int NumberOfMilitaryFatalities { get; set; }
        public int PosX { get; set; }
        public int PosY { get; set; }

        public IList<Actor> Actors => this.actors;
    }
}
