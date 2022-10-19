using LeaderBase.Core.Common;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeaderBase.Core.Entities.Person
{
    public class Person : BaseEntity
    {
        [BsonElement("name")]
        public string Name { get; set; }
        [BsonElement("dateOfBirth")]
        public DateTime DateOfBirth { get; set; }
        [BsonElement("placeOfBirth")]
        public string PlaceOfBirth { get; set; }
        [BsonElement("nationality")]
        public string Nationality { get; set; }
    }
}
