using DataAccsess.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccsess.Interfaces
{
    public interface IRepository <T>
    {
        IEnumerable<T> GetAll(Expression<Func<T,bool>> func = null);

        T Get(int id);

        void Create(T item);

        void Update(T item);

        void Delete(T item);

    }
}
