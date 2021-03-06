﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.DA
{
    public class DAContext : IDAContext
    {

        #region Fields
        private MyContext dbContext;
        private IPostRepository _post;
        private IUserRepository _user;
        #endregion

        #region Constructors

        public DAContext(string connectionString) {
            dbContext = new MyContext(connectionString);
        }

        #endregion

        #region Properties

        public IPostRepository Post {
            get {
                if (_post == null)
                    _post = new PostRepository(dbContext);
                return _post;
            }
        }

        public IUserRepository User {
            get {
                if (_user == null)
                    _user = new UserRepository(dbContext);
                return _user;
            }
        }

        #endregion

        #region Methods
        
        /*
        public int SaveChanges() {
            return dbContext.SaveChanges();
        }
        */
        public void Dispose() {
            if (_post != null)
                _post.Dispose();
            if (dbContext != null)
                dbContext.Dispose();
            GC.SuppressFinalize(this);
        }
        
        #endregion


       
    }
}
