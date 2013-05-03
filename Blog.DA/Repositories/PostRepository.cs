using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Blog.Entities.Entities;
using MongoDB.Bson;
using MongoDB.Driver.Builders;

namespace Blog.DA
{
    public class PostRepository : Repository<Post>, IPostRepository
    {
        public PostRepository(MyContext context)
            : base(context)
        { }

        public void SaveComment(ObjectId postId, Comment comment) {
            Context.DB.GetCollection<Post>("post").Update(Query.EQ("_id", postId), MongoDB.Driver.Builders.Update.PushWrapped("Comments", comment).Inc("TotalComments", 1));
        }

        public void DeleteComment(Post post, ObjectId commentID) {
            var update = MongoDB.Driver.Builders.Update.Pull("Comments", Query.EQ("_id", commentID));
            Context.DB.GetCollection<Post>("post").Update(Query.EQ("_id", post.PostId),update);
        }
      
    }
}
