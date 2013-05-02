using System;
using System.ComponentModel.DataAnnotations;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Blog.Entities.Entities
{
    public class Comment
    {

        [BsonId]
        public ObjectId CommentId { get; set; }

        public DateTime Date { get; set; }

        public string Author { get; set; }

        [Required]
        public string Detail { get; set; }

    }
}
