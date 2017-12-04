using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using DataAccsess.Model;
using DataAccsess.Interfaces;

namespace DataAccsess.Repository
{
    public class ProductTypeRepository:BaseRepository, IRepository<ProductType>
    {
        public ProductTypeRepository(DataModelContainer context) : base(context) { }

        public ProductType Get(int id)
        {
            return context.ProductTypeSet.AsNoTracking().FirstOrDefault(x => x.Id == id);
        }

        public IEnumerable<ProductType> GetAll(Expression<Func<ProductType, bool>> func = null)
        {
            if (func is null)
                return context.ProductTypeSet.AsNoTracking();

            return context.ProductTypeSet.AsNoTracking().Where(func);
        }

        public void Create(ProductType item)
        {
            context.ProductTypeSet.Add(item);
        }

        public void Delete(ProductType item)
        {
            context.ProductTypeSet.Remove(item);
        }

        public void Update(ProductType item)
        {
            context.Entry(item).State = EntityState.Modified;
        }
    }
}
