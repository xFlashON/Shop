using DAL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Interfaces;
using System.Linq.Expressions;
using System.Data.Entity;

namespace DAL.Repository
{
    public abstract class BaseRepository<T> : IRepository<T> where T:class, IEntity
    {
        protected Container context;

        protected BaseRepository(Container context)
        {
            this.context = context;
        }

        public virtual void Create(T item)
        {
            context.Set<T>().Add(item);
        }

        public virtual void Delete(T item)
        {
            context.Entry(item).State = EntityState.Deleted;
        }

        public virtual IEnumerable<T> Get(Expression<Func<T, bool>> func)
        {
            return context.Set<T>().AsNoTracking().Where(func).ToList();
        }

        public virtual T Get(int id)
        {
            return context.Set<T>().AsNoTracking().FirstOrDefault(i => i.Id == id);
        }

        public virtual IEnumerable<T> GetAll()
        {
            return context.Set<T>().AsNoTracking().ToList();
        }

        public virtual void Update(T item)
        {
            context.Entry<T>(item).State = EntityState.Modified;
        }
    }
}
