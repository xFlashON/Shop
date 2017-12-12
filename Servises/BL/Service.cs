using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Servises.Interfaces;
using DAL.Interfaces;
using DAL.Model;

namespace Servises.BL
{
    public class Service : IService
    {
        private IUnitOfWork databaseService;
        public Service(IUnitOfWork unitOfWork)
        {
            databaseService = unitOfWork;
        }

        public ValidationException CreateOrder(Order order)
        {
            throw new NotImplementedException();
        }

        public IUnitOfWork DatabaseService
        {
            get => databaseService;
        }

        public IEnumerable<Product> GetAllProducts()
        {
            return databaseService.ProductRepository.GetAll();
        }

        public Product GetProduct(int id)
        {
            return databaseService.ProductRepository.Get(id);
        }

        public IEnumerable<Price> GetProductPrices()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Product> GetProducts()
        {
            return databaseService.ProductRepository.GetAll();
        }

        public IEnumerable<Product> GetProducts(int? groupId, int? page)
        {
            if (page == null)
                page = 0;

            page = Math.Max(0, (int)page);

            int pageSize = 6;

            return databaseService.ProductRepository.Get(x => (groupId == null || x.ProductType == null) || x.ProductType.Id == groupId).Skip((int)page * pageSize).Take(pageSize);
        }

        public IEnumerable<ProductType> GetProductTypes()
        {
            return databaseService.ProductTypeRepository.GetAll();
        }

        IEnumerable<Price> IService.GetProductPrices()
        {
            return databaseService.PriceRepository.GetAll();
        }

        public void SaveImage(int productId, byte[] imageData, string mimoType)
        {

            var product = databaseService.ProductRepository.Get(productId);

            if(product != null)
            {
                ProductImage image = product.ProductImage ?? new ProductImage();

                image.ImageData = imageData;
                image.ImageMimeType = mimoType;

                if (image.Id == 0)
                {
                    DatabaseService.ProductImageRepository.Create(image);
                    DatabaseService.Save();                    
                }
                else
                {
                    DatabaseService.ProductImageRepository.Update(image);
                }

                product.ProductImageId = image.Id;
                product.ProductImage = image;

                DatabaseService.ProductRepository.Update(product);

                DatabaseService.Save();

            }

        }

        public ProductImage GetImage(int imageId)
        {
            return DatabaseService.ProductImageRepository.Get(imageId);
        }

        public IEnumerable<News> GetNews(int? page)
        {
            int pageSize = 5;

            if (page == null)
                page = 0;

            return databaseService.NewsRepository.GetAll().OrderByDescending (x=>x.Date).Skip((int)page * pageSize).Take(pageSize);
        }

        public News GetNews(int newsId)
        {
            return databaseService.NewsRepository.Get(newsId);
        }

        public void SaveNews(News news)
        {
            if (news.Id == 0)
                databaseService.NewsRepository.Create(news);
            else
                databaseService.NewsRepository.Update(news);

            databaseService.Save();
        }
    }
}
