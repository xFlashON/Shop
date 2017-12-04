using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System;
using System.ComponentModel.DataAnnotations;


namespace Shop.Models
{
    public class ProductViewModel
    {
        public int Id { get; set; }
        [Display(Name = "Наименование")]
        [Required (ErrorMessage = "Не заполнено наименование")]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public string ShortDescription { get; set; }
        public decimal Price { get; set; }
        public ProductTypeViewModel ProductType { get; set; }

    }
}