using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.Builders;
using MongoDB.Driver.Linq;

namespace Blog.DA
{
    public class Repository<TObject> : IRepository<TObject> where TObject : class
    {

        protected MyContext Context = null;
        private bool shareContext = false;

        public Repository(MyContext context) {
            Context = context;
            shareContext = true;
        }
        public void Dispose() {
            if (shareContext && (Context != null))
                Context.Dispose();
        }


        protected MongoCollection<TObject> DbSet {
            get {
                return Context.DB.GetCollection<TObject>(typeof(TObject).Name.ToLower());
            }
        }
        
        public virtual IEnumerable<TObject> All() {
            try {
                return DbSet.FindAll().SetSortOrder(SortBy.Descending("Date")).ToList<TObject>();
            } catch (Exception ex) {
                return null;
            }
        }


        public virtual IEnumerable<TObject> Filter(Expression<Func<TObject, bool>> filter) {
            try {
                return DbSet.AsQueryable<TObject>().Where(filter);
            } catch (Exception ex) {
                return null;
            }
        }

        
        public virtual IQueryable<TObject> Filter(Expression<Func<TObject, bool>> filter, out int total, int index = 0, int size = 50) {
            total = 0;
            try {
                int skipCount = index * size;
                var _resetSet = filter != null ? DbSet.AsQueryable<TObject>().Where(filter).AsQueryable() : DbSet.AsQueryable();
                _resetSet = skipCount == 0 ? _resetSet.Take(size) : _resetSet.Skip(skipCount).Take(size);
                total = _resetSet.Count();
                return _resetSet.AsQueryable();
            } catch (Exception ex) {
                return null;
            }
        }

        
        public bool Contains(Expression<Func<TObject, bool>> predicate) {
            try {
                return DbSet.AsQueryable<TObject>().Count(predicate) > 0;
            } catch (Exception ex) {
                return false;
            }
        }

        public TObject Find(BsonValue key) {
            try {
                return DbSet.FindOneById(key);
            } catch (Exception ex) {
                return null;
            }
        }

        
        public virtual TObject Find(Expression<Func<TObject, bool>> predicate) {
            try {
                return DbSet.AsQueryable<TObject>().FirstOrDefault(predicate);
            } catch (Exception ex) {
                return null;
            }
        }

        
        public virtual bool Create(TObject TObject) {
            try {
                var result =  DbSet.Save(TObject);
                return result.Ok;
            } catch (Exception ex) {
                return false;
            }
        }

        
        public virtual int Count {
            get {
                return DbSet.AsQueryable<TObject>().Count();
            }
        }

        public virtual bool Delete(BsonValue key) {
            try {
                var result = DbSet.Remove(Query.EQ("_id", key));
                return result.Ok;
            } catch (Exception ex) {
                return false;
            }
        }

        public virtual bool Update(TObject TObject) {
            try {
                var result = DbSet.Save(TObject);
                return result.Ok;
            } catch (Exception ex) {
                return false;
            }
        }
        

    }
}
