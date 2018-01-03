using DAL.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Shop.Models
{
    public class UserViewModel
    {

        [Display(Name ="Пользователь")]
        [Required]
        public string Email { get; set; }

        [Display(Name = "Тип цен")]
        public int PriceTypeId { get; set; }

        [Display(Name = "Тип цен")]
        public PriceType PriceType { get; set; }

        public SelectList PriceTypes { get; set; }

        [Display(Name = "Администратор")]
        public bool IsAdmin { get; set; }

    }
}