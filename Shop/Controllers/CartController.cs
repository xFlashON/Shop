using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Newtonsoft.Json;
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

        [HttpPost]
        public ActionResult SaveOrder (string orderData)
        {

            if (orderData == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            var data = JsonConvert.DeserializeAnonymousType(orderData, new { orderNumber = 0, comment = "", orderRows = new[] { new { rowId = 0, qty = 0m, sum = 0m} } });

            var order = blService.DatabaseService.OrderRepository.Get(o => o.Id == data.orderNumber && o.Payed == false).FirstOrDefault();

            if(order==null)
                new HttpStatusCodeResult(HttpStatusCode.NotFound);

            order.Payed = true;
            order.Comment = data.comment;
            order.Date = DateTime.Now;

            foreach(var dataRow in data.orderRows)
            {
                var orderRow = order.OrderRows.First(r => r.Id == dataRow.rowId);
                orderRow.Qty = dataRow.qty;
                orderRow.Sum = dataRow.sum;
            }

            order.Total = order.OrderRows.Sum(r => r.Sum);

            blService.DatabaseService.OrderRepository.Update(order);

            blService.DatabaseService.Save();

            return new HttpStatusCodeResult(HttpStatusCode.OK);

        }



    }
}