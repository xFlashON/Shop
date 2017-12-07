using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace Shop.Models
{
    public class ProductViewModel
    {
        [Display(Name = "Код")]
        [HiddenInput (DisplayValue = true)]
        public int Id { get; set; }
        [Display(Name = "Наименование")]
        [Required (ErrorMessage = "Не заполнено наименование")]
        public string Name { get; set; }

        [Display(Name = "Описание")]
        public string Description { get; set; }

        [Display(Name = "Короткое описание")]
        [Required(ErrorMessage = "Не заполнено короткое описание")]
        [MinLength(10, ErrorMessage = "Минимальная длинна 10 символов")]
        public string ShortDescription { get; set; }

        [Required (ErrorMessage = "Не указан тип номенклатуры")]
        public int ProductTypeId { get; set; }

        public ProductTypeViewModel ProductType { get; set; }


    }
}