using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Blog.Entities.Entities
{
    public class Role
    {
        [ScaffoldColumn(false)]
        [BsonId]
        public ObjectId RoleId { get; set; }

        [Required]
        public string Name { get; set; }
    }
}
