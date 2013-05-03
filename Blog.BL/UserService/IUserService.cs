using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Blog.Entities.Entities;

namespace Blog.BL
{
    public interface IUserService
    {
        void RegisterUser(User user);
        User GetUser(String userName);
    }
}
