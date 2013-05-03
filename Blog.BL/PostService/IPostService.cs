using System;
using System.Collections.Generic;
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
        void DeleteComment(Post post, ObjectId commentID);
    }
}
