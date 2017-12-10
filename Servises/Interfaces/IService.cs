using System.Collections;
using System.Collections.Generic;
using DAL.Interfaces;
using DAL.Model;
using System.ComponentModel.DataAnnotations;

namespace Servises.Interfaces
{
    public interface IService
    {

        IUnitOfWork DatabaseService { get; }
        IEnumerable<Product> GetAllProducts();
        IEnumerable<Product> GetProducts(int? groupId, int? page);
        Product GetProduct(int id);
        IEnumerable<ProductType> GetProductTypes();
        IEnumerable<Price> GetProductPrices();
        ValidationException CreateOrder(Order order);
        void SaveImage(int productId, byte[] imageData, string mimoType);
        ProductImage GetImage(int imageId);
        IEnumerable<News> GetNews(int? page);

    }
}