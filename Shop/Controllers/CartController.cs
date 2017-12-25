using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;

namespace Shop.Controllers
{
    [Authorize]
    public class CartController : Controller
    {
        [HttpGet]
        public ActionResult Cart()
        {
            return View();
        }

        [HttpGet]
        public JsonResult GetOrder()
        {
            var userName = User.Identity.GetUserName();



            return null;
        }


    }
}