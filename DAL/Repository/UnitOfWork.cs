using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Interfaces;
using DAL.Model;

namespace DAL.Repository
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private IRepository<Product> productRepository;
        private IRepository<ProductType> productTypeRepository;
        private IRepository<Price> pricesRepository;
        private IRepository<PriceType> priceTypeRepository;
        private IRepository<Order> orderRepository;
        private IRepository<News> newsRepository;
        private IRepository<ProductImage> productImageRepository;

        private Container context;

        public UnitOfWork()
        {
            context = new Container();
        }

        public IRepository<Product> ProductRepository => productRepository ?? (productRepository = new ProductRepository(context));

        public IRepository<ProductType> ProductTypeRepository => productTypeRepository ?? (productTypeRepository = new ProductTypeRepository(context));

        public IRepository<PriceType> PriceTypeRepository => priceTypeRepository ?? (priceTypeRepository = new PriceTypeRepository(context));

        public IRepository<Price> PriceRepository => pricesRepository ?? (pricesRepository = new PricesRepository(context));

        public IRepository<Order> OrderRepository => orderRepository ?? (orderRepository = new OrderRepository(context));

        public IRepository<News> NewsRepository => newsRepository ?? (newsRepository = new NewsRepository(context));

        public IRepository<ProductImage> ProductImageRepository => productImageRepository ?? (productImageRepository = new ProductImageRepository(context));

        public void Save()
        {
            context.SaveChanges();
        }

        private bool disposed = false;

        public virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
                this.disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

    }
}
