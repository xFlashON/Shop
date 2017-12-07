using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DAL.Interfaces;
using DAL.Model;
using DAL.Repository;
using Ninject.Modules;
using Servises.BL;
using Servises.Interfaces;

namespace Shop.Utils
{
    public class NinjectRegistrations:NinjectModule
    {
        public override void Load()
        {
            Bind<IUnitOfWork>().To<UnitOfWork> ();
            Bind<IService>().To<Service>();
        }
    }
}