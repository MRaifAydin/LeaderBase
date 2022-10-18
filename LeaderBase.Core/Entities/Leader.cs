using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LeaderBase.Core.Common;
using MongoDB.Bson.Serialization.Attributes;

namespace LeaderBase.Core.Entities
{
    public class Leader : BaseEntity
    {
        [BsonElement("name")]
        public string Name { get; set; }

        [BsonElement("dateOfBirth")]
        public DateTime DateOfBirth { get; set; }

        [BsonElement("dateOfDeath")]
        public DateTime DateOfDeath { get; set; }

        [BsonElement("placeOfBirth")]
        public string PlaceOfBirth { get; set; }

        [BsonElement("placeOfDeath")]
        public string PlaceOfDeath { get; set; }

        [BsonElement("spouseIds")]
        public string[] SpousesIds { get; set; }

        [BsonElement("kidsIds")]
        public string[] KidsIds { get; set; }

        [BsonElement("fatherId")]
        public string FatherId { get; set; }

        [BsonElement("motherId")]
        public string MotherId { get; set; }

    }
}
