using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Blog.Entities.Entities;

namespace Blog.DA
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        public UserRepository(MyContext context)
            : base(context)
        { }

    }
}
