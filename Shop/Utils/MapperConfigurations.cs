using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using DataAccsess.Model;
using Shop.Models;

namespace Shop.Utils
{
    public class MapperConfigurations
    {
        public static void Configure()
        {
            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<Product, ProductViewModel>();
                cfg.CreateMap<ProductType, ProductTypeViewModel>();
            });
        }
    }
}