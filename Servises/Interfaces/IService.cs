using System.Collections;
using System.Collections.Generic;
using DataAccsess.Interfaces;
using DataAccsess.Model;
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
        IEnumerable<Prices> GetProductPrices();
        ValidationException CreateOrder(Order order);

    }
}