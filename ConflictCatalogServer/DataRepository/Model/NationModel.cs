using System;
using System.Collections.Generic;
using System.Text;

namespace DataRepository.Model
{
    public class NationModel : IIdentifiedModel
    {
        public int? Id { get; set; }

        public string UniqueName { get; set; }
        public int NumberOfOccurrences { get; set; }
        public int MapXCoord { get; set; }
        public int MapYCoord { get; set; }
    }
}
