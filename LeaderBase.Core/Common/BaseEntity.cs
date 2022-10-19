using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeaderBase.Core.Common
{
    public class BaseEntity
    {
        [BsonRepresentation(BsonType.ObjectId)]
        [BsonId]
        public string? Id { get; set; }

        [BsonRepresentation(BsonType.DateTime)]
        [BsonDateTimeOptions(Kind = DateTimeKind.Utc)]
        public DateTime? CreatedAt { get; set; }

        [BsonRepresentation(BsonType.DateTime)]
        [BsonDateTimeOptions(Kind = DateTimeKind.Utc)]
        public DateTime? LastModifiedAt { get; set; }

        public string? CreatedBy { get; set; }

        public string? LastModifiedBy { get; set; }

        [BsonRepresentation(BsonType.Boolean)]
        public bool? IsDeleted { get; set; }
    }
}
