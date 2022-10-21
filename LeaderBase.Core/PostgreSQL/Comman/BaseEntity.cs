using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeaderBase.Core.PostgreSQL.Common
{
    public class BaseEntity
    {
        public int Id { get; set; }

        public DateTime? CreatedAt { get; set; }

        public DateTime? LastModifiedAt { get; set; }

        public string? CreatedBy { get; set; }

        public string? LastModifiedBy { get; set; }

        public bool? IsDeleted { get; set; }
    }
}
