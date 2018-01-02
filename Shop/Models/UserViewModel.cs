using DAL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Shop.Models
{
    public class UserViewModel
    {

        public string Email { get; set; }
        public PriceType PriceType { get; set; }
        public bool IsAdmin { get; set; }

    }
}