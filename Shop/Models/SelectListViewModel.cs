using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Shop.Models
{
    public class SelectListViewModel
    {
        public SelectList ItemsList { get; set; }
        public int SelectedItemId { get; set; }
    }
}