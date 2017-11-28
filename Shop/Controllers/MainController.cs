using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DataAccsess.Model;

namespace Shop.Controllers
{
    public class MainController : Controller
    {
        // GET: Main
        public ActionResult Index()
        {

            using (var db = new DataModelContainer())
            {

                var tmp = db.ProductTypeSet.Count();

                ;
            }

            return View();
        }
    }
}