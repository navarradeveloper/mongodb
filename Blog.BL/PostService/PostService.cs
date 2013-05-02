using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Blog.DA;
using Blog.Entities.Entities;
using MongoDB.Bson;

namespace Blog.BL
{
    public class PostService : BaseService, IPostService
    {

        public PostService(IDAContext da)
            : base(da)
        {
        }

        public void Save(Post post) {
            Context.Post.Update(post);
        }

        public void Delete(Post post){
            Context.Post.Delete(post.PostId);
        }

        public IList<Post> GetAllPosts() {
            return Context.Post.All().ToList<Post>();
        }

        public Post GetOnePost(String urlName) { 
            return Context.Post.Find(p=> p.Url.Equals(urlName.ToLower()));
        }

        public Post GetOnePost(ObjectId postId){
            return Context.Post.Find(postId);
        }

        public void SaveComment(ObjectId postId,Comment comment){

            Context.Post.SaveComment(postId,comment);
           
            
        }

    }
}
