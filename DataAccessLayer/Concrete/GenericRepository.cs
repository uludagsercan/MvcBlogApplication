using DataAccessLayer.Abstract;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Concrete
{
    public class GenericRepository<T> : IRepository<T> where T : class
    {
        private Context c;
        private DbSet<T> _object;
        public GenericRepository()
        {
            c = new Context();
            _object = c.Set<T>();
        }
        public void Delete(T p)
        {
            var deletedEntity = c.Entry(p);
            deletedEntity.State = EntityState.Deleted;
           // _object.Remove(p);
            c.SaveChanges();
        }

        public void Insert(T p)
        {
            var addedEntity = c.Entry(p);
            addedEntity.State = EntityState.Added;
            //_object.Add(p);
            c.SaveChanges();
        }

        public List<T> List()
        {
            return _object.ToList();
        }
        public T Get(Expression<Func<T,bool>>filter)
        {
            return _object.SingleOrDefault(filter);
        }
        public List<T> List(Expression<Func<T, bool>> filter)
        {
            return _object.Where(filter).ToList();
        }

        public void Update(T p)
        {
            
            var modifiedEntity = c.Entry(p);
            modifiedEntity.State = EntityState.Modified;
            c.SaveChanges();
        }
        
        public T Find(Expression<Func<T, bool>> filter)
        {
            return _object.Find(filter);
        }

    }
}
