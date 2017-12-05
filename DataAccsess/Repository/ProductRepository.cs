using DataAccsess.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;
using DataAccsess.Interfaces;

namespace DataAccsess.Repository
{
    public class ProductRepository : BaseRepository, IRepository<Product>
    {
        public ProductRepository(DataModelContainer context) : base(context) { }

        public Product Get(int id)
        {
            return context.ProductSet.AsNoTracking().Include("ProductType").FirstOrDefault(x=>x.Id==id);
        }

        public IEnumerable<Product> GetAll(Expression<Func<Product, bool>> func = null)
        {
            if (func is null)
                return context.ProductSet.AsNoTracking().Include("ProductType").ToList();

            return context.ProductSet.AsNoTracking().Include("ProductType").Where(func);
        }

        public void Create(Product item)
        {
            context.ProductSet.Add(item);
        }

        public void Delete(Product item)
        {
            context.ProductSet.Remove(item);
        }

         public void Update(Product item)
        {
            context.Entry(item).State = EntityState.Modified;
        }
    }
}
