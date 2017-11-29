using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using DataAccsess.Model;

namespace DataAccsess.Repository
{
    public class ProductTypeRepository:BaseRepository, IRepository<ProductType>
    {
        public IEnumerable<ProductType> GetAll(Expression<Func<ProductType, bool>> func = null)
        {
            throw new NotImplementedException();
        }

        public ProductType Get(int id)
        {
            throw new NotImplementedException();
        }

        public void Create(ProductType item)
        {
            throw new NotImplementedException();
        }

        public void Update(ProductType item)
        {
            throw new NotImplementedException();
        }

        public void Delete(ProductType item)
        {
            throw new NotImplementedException();
        }
    }
}
