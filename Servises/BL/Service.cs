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
        public IUnitOfWork DatabaseService => databaseService;

        public ValidationException CreateOrder(Order order)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Prices> GetProductPrices()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Product> GetProducts()
        {
            return DatabaseService.ProductRepository.GetAll();
        }

        public IEnumerable<ProductType> GetProductTypes()
        {
            throw new NotImplementedException();
        }
    }
}
