using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Blog.Entities.Entities
{
    public class Post
    {
        [ScaffoldColumn(false)]
        [BsonId]
        public ObjectId PostId { get; set; }
        
        [ScaffoldColumn(false)]
        public DateTime Date { get; set; }

        [Required]
        public string Title { get; set; }

        [ScaffoldColumn(false)]
        public string Url { get; set; }

        [Required]
        public string Summary { get; set; }

        [UIHint("WYSIWYG")]
        [AllowHtml]
        public string Details { get; set; }

        [ScaffoldColumn(false)]
        public string Author { get; set; }

        
        [ScaffoldColumn(false)]
        public int TotalComments { get; set; }

        [ScaffoldColumn(false)]
        public IList<Comment> Comments { get; set; }
         
    }
}
