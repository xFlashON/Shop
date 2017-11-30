using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccsess.Model;
using DataAccsess.Repository;

namespace DataAccsess.Interfaces
{
    public interface IUnitOfWork
    {
        IRepository<Product> ProductRepository { get; }
        IRepository<ProductType> ProductTypeRepository { get; }
        IRepository<PriceType> PriceTypeRepository { get; }
        IRepository<Prices> PriceRepository { get; }
        IRepository<Order> OrderRepository{ get; }
        IRepository<News> NewsRepository { get; }
        IRepository<ProductImage> ProductImageRepository { get; }
        void Save();

    }
}
