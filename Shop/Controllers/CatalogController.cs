using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using DataAccsess.Model;
using Servises.Interfaces;
using Shop.Models;

namespace Shop.Controllers
{
    public class CatalogController : Controller
    {
        private IService blService;

        public CatalogController(IService service)
        {
            blService = service;
        }
        
        // GET: Catalog
        public ActionResult Catalog(int? groupId, int? page)
        {
            ViewBag.Title = "Каталог товаров";

            CatalogViewModel model = new CatalogViewModel();

            var productTypes = blService.GetProductTypes();

            IEnumerable<Product> products;

            if (groupId != null || page != null)
                products = blService.GetProducts(groupId, page);
            else
                products = blService.GetAllProducts();

            Mapper.Reset();

            Mapper.Initialize(cfg=>
            {
                cfg.CreateMap<Product, ProductViewModel>();
            });

            model.Products = Mapper.Map<IEnumerable<Product>, List<ProductViewModel>>(products);

            Mapper.Reset();

            Mapper.Initialize(cfg => cfg.CreateMap<ProductType, ProductTypeViewModel>());

            model.ProductTypes = Mapper.Map<IEnumerable<ProductType>, List<ProductTypeViewModel>>(productTypes);


            return View(model);
        }

    }
}