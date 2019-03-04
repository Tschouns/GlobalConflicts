using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Services.ConflictModels
{
    [DataContract]
    public class Actor
    {
        [DataMember]
        public string FullName { get; set; }

        [DataMember]
        public string Location { get; set; }
    }
}
