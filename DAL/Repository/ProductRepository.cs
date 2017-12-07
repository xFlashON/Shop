using DAL.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;
using DAL.Interfaces;

namespace DAL.Repository
{
    public class ProductRepository : BaseRepository<Product>, IRepository<Product>
    {
        public ProductRepository(Container context) : base(context) { }

        public override Product Get(int id)
        {
            return context.ProductSet.AsNoTracking().Include("ProductType").FirstOrDefault(x=>x.Id==id);
        }

        public override IEnumerable<Product> Get(Expression<Func<Product, bool>> func)
        {
            return context.ProductSet.AsNoTracking().Include("ProductType").Where(func).ToList();
        }

    }
}
