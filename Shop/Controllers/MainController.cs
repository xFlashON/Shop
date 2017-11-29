using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DataAccsess.Model;
using DataAccsess.Repository;

namespace Shop.Controllers
{
    public class MainController : Controller
    {
        IRepository<Product> _productRepository;

        public MainController(IRepository<Product> productRepository)
        {
            _productRepository = productRepository;
        }
        
        // GET: Main
        public ActionResult Index()
        {

            var products = _productRepository.GetAll();

            return View();
        }
    }
}