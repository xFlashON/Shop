using Servises.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

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

            var image = blService.getImage((int)imageId);

            if (image == null)
                return null;

            return File(image.ImageData, image.ImageMimeType);

        }
    }
}