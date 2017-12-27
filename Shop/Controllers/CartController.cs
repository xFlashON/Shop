using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Servises.Interfaces;

namespace Shop.Controllers
{
    [Authorize]
    public class CartController : Controller
    {
        private IService blService;

        public CartController(IService service)
        {
            blService = service;
        }

        [HttpGet]
        public ActionResult Cart()
        {
            return View();
        }

        [HttpGet]
        public JsonResult GetOrder()
        {
            var userName = User.Identity.GetUserName();

            var order = blService.GetOpenOrder(userName);

            var testObj = new {orderId = order.Id,
                total = order.Total,
                orderRows = order.OrderRows.Select(r => new
                {
                    rowId = r.Id,
                    productName = r.Product.Name,
                    qty = r.Qty,
                    price = r.Price,
                    sum = r.Sum
                }).ToArray()};

            return Json(testObj,JsonRequestBehavior.AllowGet);
        }


    }
}