using DataAccsess.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;

namespace DataAccsess.Repository
{
    class ProductRepository : BaseRepository, IRepository<Product>
    {
        public Product Get(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Product> GetAll(Expression<Func<Product, bool>> func = null)
        {
            throw new NotImplementedException();
        }

        public void Create(Product item)
        {
            throw new NotImplementedException();
        }

        public void Delete(Product item)
        {
            throw new NotImplementedException();
        }

         public void Update(Product item)
        {
            throw new NotImplementedException();
        }
    }
}
