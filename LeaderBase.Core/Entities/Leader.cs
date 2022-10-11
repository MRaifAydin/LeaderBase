using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace LeaderBase.Core.Entities
{
    public class Leader
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
