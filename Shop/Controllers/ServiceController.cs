using Servises.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Shop.Models;

namespace Shop.Controllers
{
    public class ServiceController : Controller
    {
        private IService blService;

        public ServiceController(IService service)
        {
            blService = service;
        }

        [HttpGet]
        public ActionResult GetImage(int? imageId)
        {

            if ((imageId ?? 0) == 0)
                return File("~\\Resources\\product_image_placeholder.png", "image/png");

            var image = blService.GetImage((int)imageId);

            if (image == null)
                return File("~\\Resources\\product_image_placeholder.png", "image/png");

            return File(image.ImageData, image.ImageMimeType);

        }

        [HttpGet]
        public ActionResult GetProductsSelectList(int? groupId)
        {

            var model = new SelectListViewModel();

            if (groupId.HasValue)
            {
                model.ItemsList = new SelectList(blService.DatabaseService.ProductRepository.Get(p=>p.ProductTypeId==groupId).OrderBy(p => p.Name), "Id", "Name");
            }
            else
            {
                model.ItemsList = new SelectList(blService.DatabaseService.ProductRepository.GetAll().OrderBy(p => p.Name), "Id", "Name");
            }

            return PartialView("SelectList", model);

        }


        [HttpGet]
        public ActionResult GetProductTypesSelectList()
        {

            var model = new SelectListViewModel();

            model.ItemsList = new SelectList(blService.DatabaseService.ProductTypeRepository.GetAll().OrderBy(p => p.Name), "Id", "Name");

            return PartialView("SelectList", model);

        }

        [HttpGet]
        public ActionResult GetPriceTypesSelectList()
        {

            var model = new SelectListViewModel();

            model.ItemsList = new SelectList(blService.DatabaseService.PriceTypeRepository.GetAll().OrderBy(p => p.Name), "Id", "Name");

            return PartialView("SelectList", model);

        }

    }
}