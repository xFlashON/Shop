using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Model;

namespace DAL.Interfaces
{
    public interface IUnitOfWork
    {
        IRepository<Product> ProductRepository { get; }
        IRepository<ProductType> ProductTypeRepository { get; }
        IRepository<PriceType> PriceTypeRepository { get; }
        IRepository<Price> PriceRepository { get; }
        IRepository<Order> OrderRepository{ get; }
        IRepository<News> NewsRepository { get; }
        IRepository<ProductImage> ProductImageRepository { get; }
        void Save();

    }
}
