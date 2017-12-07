using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DAL.Model
{
    public class News: IEntity
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public System.DateTime Date { get; set; }
        [Required]
        [MaxLength(250)]
        public string Title { get; set; }
        [Required]
        public string Content { get; set; }
    }
}
