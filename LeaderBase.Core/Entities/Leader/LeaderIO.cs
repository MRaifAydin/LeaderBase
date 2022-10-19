using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeaderBase.Core.Entities.Leader
{
    public class LeaderIO
    {
        public string Name { get; set; }
        public DateTime DateOfBirth { get; set; }
        public DateTime DateOfDeath { get; set; }
        public string PlaceOfBirth { get; set; }
        public string PlaceOfDeath { get; set; }
        public string[] SpousesIds { get; set; }
        public string[] KidsIds { get; set; }
        public string FatherId { get; set; }
        public string MotherId { get; set; }
    }
}
