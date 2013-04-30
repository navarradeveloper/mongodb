using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Blog.Entities.Entities;


namespace Blog.BL
{
    public interface IPostService
    {

        void Save(Post post);
        IList<Post> GetAllPosts();
        Post GetOnePost(String urlName);
    }
}
