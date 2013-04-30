using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Blog.DA;
using Blog.Entities.Entities;

namespace Blog.BL
{
    public class PostService : BaseService, IPostService
    {

        public PostService(IDAContext da)
            : base(da)
        {
          
        }

        public void Save(Post post) { 

        }

        public IList<Post> GetAllPosts() {
            return Context.Post.All().ToList<Post>();
        }

        public Post GetOnePost(String urlName) { 
            return Context.Post.Find(p=> p.Url.Equals(urlName.ToLower()));
        }

    }
}
