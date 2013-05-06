using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Blog.DA;
using Blog.Entities.Entities;
using MongoDB.Bson;

namespace Blog.Web.Security
{
    public class UserBBDD : IUserBBDD,IDisposable
    {
         private IDAContext _context;

         public UserBBDD(IDAContext da){
             _context = da;
        }

         public void RegisterUser(User user) {
             _context.User.Update(user);
         }

         public User GetUser(String userName) {
             return _context.User.Filter(u => u.NameNormalize.Equals(userName.ToUrl())).FirstOrDefault();
         }

         public User GetUser(ObjectId userID) {
             return _context.User.Find(userID);
         }

         public User GetUserByEmail(String email) {
             return _context.User.Filter(u => u.Email.Equals(email.ToLower())).FirstOrDefault();
         }

         public User GetUserByNameAndPassword(String username, String md5Pswd) { 
            return _context.User.Filter(u => u.NameNormalize.Equals(username.ToUrl()) && u.Password.Equals(md5Pswd)).FirstOrDefault();
         }

         public void Dispose() {
             if (_context != null)
                 _context.Dispose();
         }


    }
}
