using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using DAL.Model;
using DAL.Interfaces;

namespace DAL.Repository
{
    public class ProductTypeRepository:BaseRepository<ProductType>, IRepository<ProductType>
    {
        public ProductTypeRepository(Container context) : base(context) { }

    }
}
