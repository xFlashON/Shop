using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Shop.Models
{
    public class ProductTypeViewModel
    {
        [HiddenInput(DisplayValue = true)]
        [Display(Name = "Код")]
        public int Id { get; set; }

        [Display (Name = "Наименование")]
        public string Name { get; set; }
    }
}