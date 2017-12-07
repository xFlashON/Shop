﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using Servises.Interfaces;
using Shop.Models;
using DAL.Model;

namespace Shop.Areas.Admin.Controllers
{
    public class ManageController : Controller
    {
        private IService blService;

        public ManageController(IService service)
        {
            blService = service;
        }

        // GET: Admin/Manage
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult ProductTypes()
        {
            return View(Mapper.Map<IEnumerable<ProductTypeViewModel>>(blService.GetProductTypes()));
        }

        [HttpGet]
        public ActionResult Products(int? productId)
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

    }
}