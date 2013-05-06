using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Blog.Entities.Entities;
using MongoDB.Bson;

namespace Blog.Web.Security
{
    public interface IUserBBDD
    {
        void RegisterUser(User user);
        User GetUser(String userName);
        User GetUserByEmail(String email);
        User GetUserByNameAndPassword(String username,String md5Pswd);
        User GetUser(ObjectId userID);
    }
}
