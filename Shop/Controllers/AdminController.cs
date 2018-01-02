using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using Servises.Interfaces;
using Shop.Models;
using DAL.Model;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Web.Helpers;
using Microsoft.Ajax.Utilities;
using Newtonsoft.Json;
using Shop.Areas.Admin.Models;
using DAL.Models;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity;
using System.Data.Entity.SqlServer;

namespace Shop.Areas.Admin.Controllers
{
    //[Authorize(Roles = "Admin")]
    [Authorize]
    public class AdminController : Controller
    {
        private IService blService;

        public AdminController(IService service)
        {
            blService = service;
        }

        [HttpGet]
        public ActionResult References()
        {
            return View();
        }

        [HttpGet]
        public ActionResult ProductTypes()
        {
            return View(Mapper.Map<IEnumerable<ProductTypeViewModel>>(blService.GetProductTypes()));
        }

        [HttpGet]
        public ActionResult PriceTypes()
        {
            return View(Mapper.Map<IEnumerable<PriceTypeViewModel>>(blService.GetPriceTypes()));
        }

        [HttpGet]
        public ActionResult Products()
        {
            return View(Mapper.Map<IEnumerable<ProductViewModel>>(blService.DatabaseService.ProductRepository.GetAll().OrderBy(p => p.ProductType.Id)));
        }

        [HttpGet]
        public ActionResult ProductType(int? groupId)
        {
            if (groupId == null)
            {
                return RedirectToAction("Index");
            }

            var model = blService.DatabaseService.ProductTypeRepository.Get((int)groupId);

            if (model == null)
                return HttpNotFound();

            return View(Mapper.Map<ProductTypeViewModel>(model));
        }


        [HttpGet]
        public ActionResult AddProductType()
        {

            return View("ProductType", new ProductTypeViewModel());
        }

        [HttpGet]
        public ActionResult AddPriceType()
        {

            return View("PriceType", new PriceTypeViewModel());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SaveProductType(ProductTypeViewModel model)
        {
            if (ModelState.IsValid)
            {
                if (model.Id != 0)
                    blService.DatabaseService.ProductTypeRepository.Update(Mapper.Map<ProductType>(model));
                else
                    blService.DatabaseService.ProductTypeRepository.Create(Mapper.Map<ProductType>(model));

                blService.DatabaseService.Save();

                return RedirectToAction("ProductTypes");
            }
            else
            {
                return View("ProductType", model);
            }
        }

        [HttpGet]
        public ActionResult PriceType(int? Id)
        {
            if (Id == null)
            {
                return RedirectToAction("PriceTypes");
            }

            var model = blService.DatabaseService.PriceTypeRepository.Get((int)Id);

            if (model == null)
                return HttpNotFound();

            return View(Mapper.Map<PriceTypeViewModel>(model));
        }


        [HttpGet]
        public ActionResult EditProduct(int? productId)
        {
            if (productId == null)
            {
                return RedirectToAction("Index");
            }

            var model = blService.DatabaseService.ProductRepository.Get((int)productId);

            if (model == null)
                return HttpNotFound();

            ViewBag.ProductTypesList = new SelectList(Mapper.Map<IEnumerable<ProductTypeViewModel>>(blService.GetProductTypes().ToList()), "Id", "Name");

            return View(Mapper.Map<ProductViewModel>(model));
        }

        [HttpGet]
        public ActionResult AddProduct()
        {

            ViewBag.ProductTypesList = new SelectList(Mapper.Map<IEnumerable<ProductTypeViewModel>>(blService.GetProductTypes().ToList()), "Id", "Name");

            return View("EditProduct", new ProductViewModel());

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SavePriceType(PriceTypeViewModel model)
        {
            if (ModelState.IsValid)
            {
                if (model.Id != 0)
                    blService.DatabaseService.PriceTypeRepository.Update(Mapper.Map<PriceType>(model));
                else
                    blService.DatabaseService.PriceTypeRepository.Create(Mapper.Map<PriceType>(model));

                blService.DatabaseService.Save();

                return RedirectToAction("PriceTypes");
            }
            else
            {
                return View("PriceType", model);
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SaveProduct(ProductViewModel model)
        {
            if (!ModelState.IsValid)
            {

                ViewBag.ProductTypesList = new SelectList(Mapper.Map<IEnumerable<ProductTypeViewModel>>(blService.GetProductTypes().ToList()), "Id", "Name");

                return View("EditProduct", model);

            }

            var product = Mapper.Map<Product>(model);

            if (product.Id == 0)
                blService.DatabaseService.ProductRepository.Create(product);
            else
                blService.DatabaseService.ProductRepository.Update(product);

            blService.DatabaseService.Save();

            return RedirectToAction("Products");
        }

        [HttpGet]
        public ActionResult LoadImage(int? productId)
        {
            if (productId == null)
                return RedirectToAction("Products");

            var product = blService.GetProduct((int)productId);

            return View(new ProductImageViewModel() { Id = product.ProductImageId ?? 0, ProductId = product.Id });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SaveImage(int ProductId, HttpPostedFileBase file)
        {

            if (file != null)
            {

                using (BinaryReader reader = new BinaryReader(file.InputStream))
                {
                    byte[] imageData = reader.ReadBytes(file.ContentLength);

                    blService.SaveImage(ProductId, imageData, file.ContentType);
                }

            }

            return RedirectToAction("Products");
        }

        [HttpGet]
        public ActionResult News(int? page)
        {

            var model = new NewsListViewModel();

            model.NewsList = Mapper.Map<IEnumerable<NewsViewModel>>(blService.GetNews(page));
            model.CurrentPage = page ?? 0;

            return View(model);
        }

        [HttpGet]
        public ActionResult EditNews(int id)
        {
            return View(Mapper.Map<NewsViewModel>(blService.GetNews(id)));
        }

        [HttpGet]
        public ActionResult DeleteNews(int id)
        {
            return View("DeleteElement", new DeleteConfirmationViewModel() { DeletedId = id, ActionName = "DeleteNews", Alert = "Подтвердите удаление новости" });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteNews(DeleteConfirmationViewModel model)
        {
            if (model.DeletedId != 0)

            {
                var deletedItem = blService.DatabaseService.NewsRepository.Get(model.DeletedId);
                if (deletedItem != null)
                {
                    blService.DatabaseService.NewsRepository.Delete(deletedItem);
                    blService.DatabaseService.Save();
                }
            }


            return RedirectToAction("News");
        }

        [HttpGet]
        public ActionResult AddNews()
        {
            return View(new NewsViewModel() { Date = DateTime.Now });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SaveNews(NewsViewModel model)
        {

            if (!ModelState.IsValid)
            {
                return View("AddNews", model);
            }

            blService.SaveNews(Mapper.Map<News>(model));

            return RedirectToAction("News");
        }

        [HttpGet]
        public ActionResult Prices()
        {
            return View();
        }

        [HttpGet]
        public JsonResult GetPrices(int page, int rows)
        {

            var priceList = blService.GetProductPrices(page, rows);

            return Json(priceList, JsonRequestBehavior.AllowGet);
        }

        public ActionResult EditPrice(string oper, int? Id, int? ProductName, int? PriceTypeName, string Price)
        {

            switch (oper)
            {
                case "add":
                    {
                        if (ProductName.HasValue && PriceTypeName.HasValue && Price != null)
                        {
                            var product = blService.GetProduct((int)ProductName);
                            var priceType = blService.DatabaseService.PriceTypeRepository.Get((int)PriceTypeName);

                            if (product == null || priceType == null)
                            {
                                return new HttpStatusCodeResult(HttpStatusCode.NotFound);
                            }

                            if (blService.DatabaseService.PriceRepository
                                    .Get(p => p.Product.Id == product.Id && p.PriceType.Id == priceType.Id).FirstOrDefault() != null)
                            {
                                return new HttpStatusCodeResult(HttpStatusCode.Conflict, "Price alredy exist");
                            }

                            var newPrice = new Price()
                            {
                                PriceTypeId = priceType.Id,
                                ProductId = product.Id,
                                CurrentPrice = Decimal.Parse(Price.Replace(".", ","))
                            };

                            blService.DatabaseService.PriceRepository.Create(newPrice);
                            blService.DatabaseService.Save();

                            return new HttpStatusCodeResult(HttpStatusCode.OK, newPrice.Id.ToString());

                        }
                        else
                        {
                            return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                        }

                        break;
                    }
                case "edit":
                    {

                        if (Id.HasValue && ProductName.HasValue && PriceTypeName.HasValue && Price != null)
                        {

                            var product = blService.GetProduct((int)ProductName);
                            var priceType = blService.DatabaseService.PriceTypeRepository.Get((int)PriceTypeName);

                            if (product == null || priceType == null)
                            {
                                return new HttpStatusCodeResult(HttpStatusCode.NotFound);
                            }

                            if (blService.DatabaseService.PriceRepository
                                    .Get(p => p.Product.Id == product.Id && p.PriceType.Id == priceType.Id && p.Id != Id).FirstOrDefault() != null)
                            {
                                return new HttpStatusCodeResult(HttpStatusCode.Conflict, "Price alredy exist");
                            }

                            var price = blService.DatabaseService.PriceRepository.Get((int)Id);

                            if (price == null)
                            {
                                return new HttpStatusCodeResult(HttpStatusCode.NotFound);
                            }

                            price.CurrentPrice = Decimal.Parse(Price.Replace(".", ","));

                            blService.DatabaseService.PriceRepository.Update(price);
                            blService.DatabaseService.Save();

                            return new HttpStatusCodeResult(HttpStatusCode.OK);

                        }
                        else
                        {
                            return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                        }

                        break;
                    }
                case "del":
                    {

                        if (Id.HasValue)
                        {


                            var price = blService.DatabaseService.PriceRepository.Get((int)Id);

                            if (price == null)
                            {
                                return new HttpStatusCodeResult(HttpStatusCode.NotFound);
                            }

                            blService.DatabaseService.PriceRepository.Delete(price);
                            blService.DatabaseService.Save();

                            return new HttpStatusCodeResult(HttpStatusCode.OK);

                        }
                        else
                        {
                            return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                        }

                        break;
                    }
            }

            return new HttpStatusCodeResult(HttpStatusCode.MethodNotAllowed, "Bad command");
        }

        [HttpGet]
        public ActionResult Users()
        {

            var context = new ApplicationDbContext();

            var userManager = new ApplicationUserManager(new UserStore<ApplicationUser>(context));

            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));

            var adminRole = roleManager.FindByName("Admin");

            var userPriceTypes = userManager.Users.AsEnumerable().Select(u => new
            {
                user = u,
                PriceTypeId = u.Claims.FirstOrDefault(c => c.ClaimType == "PriceTypeId") != null ? u.Claims.FirstOrDefault(c => c.ClaimType == "PriceTypeId").ClaimValue : "1"
            }).Join(blService.DatabaseService.PriceTypeRepository.GetAll().Select(p=>new {PriceTypeId = p.Id.ToString(), PriceType = p}),
            c=>c.PriceTypeId,
            p=>p.PriceTypeId,
            (c,p)=>new { user = c.user, priceType = p.PriceType});

            var usersList = userManager.Users.AsEnumerable().Join(userPriceTypes,u=>u.Id,pt=>pt.user.Id,(u,pt) => new UserViewModel()
            {
                Email = u.Email,
                PriceType = pt.priceType,
                IsAdmin = u.Roles.FirstOrDefault(r => r.RoleId == adminRole.Id) != null
            });

            return View(usersList);

        }

        private int parseString (string id)
        {
            int result = 0;

            Int32.TryParse(id, out result);

            return result;

        }

    }
}