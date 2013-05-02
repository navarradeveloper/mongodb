using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Blog.Entities.Entities;
using MongoDB.Bson;

namespace Blog.DA
{
    public interface IPostRepository : IRepository<Post>
    {
        void SaveComment(ObjectId postId,Comment comment);
    }
}
