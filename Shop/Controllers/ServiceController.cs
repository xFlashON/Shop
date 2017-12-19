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

            if (imageId == null)
                return HttpNotFound();

            var image = blService.GetImage((int)imageId);

            if (image == null)
                return HttpNotFound();

            return File(image.ImageData, image.ImageMimeType);

        }

        [HttpGet]
        public ActionResult GetProductsSelectList(int? selectedId)
        {

            var model = new SelectListViewModel();

            model.ItemsList = new SelectList(blService.GetAllProducts().OrderBy(p => p.Name), "Name", "Name");

            model.SelectedItemId = selectedId ?? 0;

            return PartialView("SelectList", model);
        }

    }
}