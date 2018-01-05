using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Security.Claims;
using System.Threading;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using DAL.Model;
using Microsoft.AspNet.Identity;
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

            //Prices
            int defaultPriceTypeId = 1;

            var identity = (ClaimsPrincipal)Thread.CurrentPrincipal;
            var priceTypeIdStr =  identity.Claims.Where(c => c.Type == "PriceTypeId").FirstOrDefault()?.Value ?? "1";

            Int32.TryParse(priceTypeIdStr, out defaultPriceTypeId);
            //
            defaultPriceTypeId = Math.Max(1, defaultPriceTypeId);

            var prices = blService.DatabaseService.PriceRepository.Get(p => p.PriceTypeId == defaultPriceTypeId);

            var tuple = from pr in products join ps in prices on pr.Id equals ps.ProductId into outer from ps in outer.DefaultIfEmpty() select new {product = pr, price = ps };

            model.Products = tuple.Select(t=> {
                var productVM = Mapper.Map<ProductViewModel>(t.product);
                productVM.Price = t.price?.CurrentPrice??0;
                return productVM;
            });

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