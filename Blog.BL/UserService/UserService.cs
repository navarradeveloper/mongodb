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
    public class UserService : BaseService, IUserService
    {
        public UserService(IDAContext da)
            : base(da)
        {
        }

        public void RegisterUser(User user) { 
            String a = "";
        }

        public User GetUser(String userName) {
            User user = new User();
            user.UserId = ObjectId.GenerateNewId();
            user.Name = "Mikel";
            user.Email = "loquesea@sdfd.es";
            return user;
        }


    }
}
