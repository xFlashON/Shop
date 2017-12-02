using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccsess.Interfaces;
using DataAccsess.Model;
using Servises.Interfaces;

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

        public IEnumerable<Product> GetAllProducts()
        {
            return databaseService.ProductRepository.GetAll();
        }

        public Product GetProduct(int id)
        {
            return databaseService.ProductRepository.Get(id);
        }

        public IEnumerable<Prices> GetProductPrices()
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

            return databaseService.ProductRepository.GetAll(x => (groupId == null || x.ProductType == null) || x.ProductType.Id == groupId).Skip((int)page * pageSize).Take(pageSize);
        }

        public IEnumerable<ProductType> GetProductTypes()
        {
            return databaseService.ProductTypeRepository.GetAll();
        }
    }
}
