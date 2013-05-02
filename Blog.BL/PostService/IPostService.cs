using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Blog.Entities.Entities;
using MongoDB.Bson;


namespace Blog.BL
{
    public interface IPostService
    {

        void Save(Post post);
        void Delete(Post post);
        IList<Post> GetAllPosts();
        Post GetOnePost(String urlName);
        Post GetOnePost(ObjectId postId);
        void SaveComment(ObjectId postId,Comment comment);
    }
}
