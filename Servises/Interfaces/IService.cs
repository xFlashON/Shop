using System;
using System.Collections;
using System.Collections.Generic;
using DAL.Interfaces;
using DAL.Model;
using System.ComponentModel.DataAnnotations;
using System.Data.Odbc;
using Servises.Models;

namespace Servises.Interfaces
{
    public interface IService
    {

        IUnitOfWork DatabaseService { get; }
        IEnumerable<Product> GetAllProducts();
        IEnumerable<Product> GetProducts(int? groupId, int? page);
        Product GetProduct(int id);
        IEnumerable<ProductType> GetProductTypes();
        IEnumerable<PriceType> GetPriceTypes();
        PriceListDTO GetProductPrices(int page, int pageSize);
        ValidationException CreateOrder(Order order);
        void SaveImage(int productId, byte[] imageData, string mimoType);
        ProductImage GetImage(int imageId);
        IEnumerable<News> GetNews(int? page);
        News GetNews(int newsId);
        void SaveNews(News news);

        Order GetOpenOrder(string userName);
        void SaveOrder(Order order);

        void AddToCart(Product product);
        void RemoveFromCart(Product product);


    }
}