using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DataAccsess.Interfaces;
using DataAccsess.Model;
using DataAccsess.Repository;
using Servises.Interfaces;

namespace Shop.Controllers
{
    public class MainController : Controller
    {
        IService service;

        public MainController(IService service)
        {
            this.service = service;
        }
        
        // GET: Main
        public ActionResult Index()
        {

            var products = service.DatabaseService.ProductRepository.GetAll();

            return View();
        }
    }
}