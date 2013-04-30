using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Blog.Entities.Entities;

namespace Blog.DA
{
    public class PostRepository : Repository<Post>, IPostRepository
    {
        public PostRepository(MyContext context)
            : base(context)
        { }



        public new IQueryable<Post> All() {
            throw new NotImplementedException();
        }

        public void Dispose() {
            throw new NotImplementedException();
        }
    }
}
