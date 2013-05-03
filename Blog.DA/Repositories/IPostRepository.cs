using Blog.Entities.Entities;
using MongoDB.Bson;

namespace Blog.DA
{
    public interface IPostRepository : IRepository<Post>
    {
        void SaveComment(ObjectId postId,Comment comment);
        void DeleteComment(Post post, ObjectId commentID);
    }
}
