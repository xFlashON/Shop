using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Shop.Areas.Admin.Models
{
    public class DeleteConfirmationViewModel
    {
        public string Alert { get; set; }
        [Required]
        public string ActionName { get; set; }
        [Required]
        public int DeletedId { get; set; }

    }
}