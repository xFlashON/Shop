using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using Servises.Interfaces;
using Shop.Models;
using DAL.Model;
using System.IO;

namespace Shop.Areas.Admin.Controllers
{
    //[Authorize(Roles = "admin")]
    public class ManageController : Controller
    {
        private IService blService;

        public ManageController(IService service)
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
        public ActionResult Products()
        {
            return View(Mapper.Map<IEnumerable<ProductViewModel>>(blService.DatabaseService.ProductRepository.GetAll().OrderBy(p=>p.ProductType.Id)));
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


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SaveProductType (ProductTypeViewModel model)
        {
            if(ModelState.IsValid)
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
        public ActionResult EditProduct (int? productId)
        {
            if (productId == null)
            {
                return RedirectToAction("Index");
            }

            var model = blService.DatabaseService.ProductRepository.Get((int)productId);

            if (model == null)
                return HttpNotFound();

            ViewBag.ProductTypesList = new SelectList(Mapper.Map<IEnumerable<ProductTypeViewModel>>(blService.GetProductTypes().ToList()),"Id","Name");

            return View(Mapper.Map<ProductViewModel>(model));
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

            blService.DatabaseService.ProductRepository.Update(Mapper.Map<Product>(model));
            blService.DatabaseService.Save();

            return RedirectToAction("Products");
        }

        [HttpGet]
        public ActionResult LoadImage(int? productId)
        {
            if (productId == null)
                return RedirectToAction("Products");

            var product = blService.GetProduct((int)productId);

            return View(new ProductImageViewModel() { Id = product.ProductImageId??0, ProductId = product.Id});
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SaveImage (int ProductId, HttpPostedFileBase file)
        {

            if (file != null)
            {

                using(BinaryReader reader = new BinaryReader(file.InputStream))
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

            model.NewsList = Mapper.Map<IEnumerable<NewsViewModel>>( blService.GetNews(page));
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
            return RedirectToAction("News");
        }

        [HttpGet]
        public ActionResult AddNews(int id)
        {
            return View(new NewsViewModel());
        }

    }
}