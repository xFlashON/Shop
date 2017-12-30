﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using DAL.Model;
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
        
        public ActionResult Catalog(int? groupId, int? page)
        {
            ViewBag.Title = "Каталог товаров";

            CatalogViewModel model = new CatalogViewModel();

            var productTypes = blService.GetProductTypes();

            IEnumerable<Product> products;

            if (groupId != null || page != null)
                products = blService.GetProducts(groupId, page);
            else
            {
                var random = new Random();
                products = blService.GetAllProducts().OrderBy(p => random.Next()).Take(9);
            }

            model.Products = Mapper.Map<IEnumerable<Product>, List<ProductViewModel>>(products);

            model.ProductTypes = Mapper.Map<IEnumerable<ProductType>, List<ProductTypeViewModel>>(productTypes);

            if (groupId != null)
            {
                model.CurrentProductType = model.ProductTypes.FirstOrDefault(x=>x.Id==groupId);
            }

            if (page != null)
            {
                model.CurrentPage = (int) page;
            }

            return View(model);
        }

        public ActionResult ProductTypes()
        {

            return PartialView(Mapper.Map<IEnumerable<ProductTypeViewModel>>(blService.GetProductTypes()));

        }

        public ActionResult Product(int? productId)
        {

            if (!productId.HasValue)
                return RedirectToAction("Catalog", "Catalog");

            var product = Mapper.Map<ProductViewModel>(blService.GetProduct((int)productId)) ;

            if (product == null)
                return HttpNotFound();

            return PartialView(product);
        }

        [HttpPost]
        public ActionResult AddToCart(int productId)
        {
            if (User.Identity.IsAuthenticated) {

                blService.AddToCart(blService.GetProduct(productId),User.Identity.Name);

                return new HttpStatusCodeResult(200);

            }
            else
            {
                return new HttpStatusCodeResult(HttpStatusCode.NotModified);
            }
        }

        [HttpGet]
        public ActionResult News (int? page)
        {
            var newsList = blService.GetNewsList(page??0);

            return View(new NewsListViewModel() { NewsList=Mapper.Map<IEnumerable<NewsViewModel>>(newsList), CurrentPage=page??1});
        }

    }
}