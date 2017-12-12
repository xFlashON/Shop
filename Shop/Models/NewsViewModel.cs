using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Shop.Models
{
    public class NewsViewModel
    {
        [HiddenInput(DisplayValue = false)]
        public int Id { get; set; }
        [Display(Name = "Дата")]
        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public System.DateTime Date { get; set; }
        [Display(Name = "Заголовок")]
        [Required]
        public string Title { get; set; }

        [Display(Name = "Содержание")]
        [AllowHtml]
        [UIHint("MultilineText")]
        [Required]
        public string Content { get; set; }

    }
}