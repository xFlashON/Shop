using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DataAccsess.Model;
using DataAccsess.Repository;
using Ninject.Modules;

namespace Shop.Utils
{
    public class NinjectRegistrations:NinjectModule
    {
        public override void Load()
        {
            Bind<IRepository<Product>>().To<ProductRepository> ();
            Bind<IRepository<ProductType>>().To<ProductTypeRepository>();
        }
    }
}