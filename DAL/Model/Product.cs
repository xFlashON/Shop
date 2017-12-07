using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DAL.Model
{
    public class Product : IEntity
    {
        public Product()
        {
            this.Name = string.Empty;
            this.Description = string.Empty;
            this.ShortDescription = string.Empty;
        }

        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }
        public string Description { get; set; }
        [Required]
        [MaxLength(250)]
        public string ShortDescription { get; set; }

        [Required]
        public int ProductTypeId { get; set; }
        [ForeignKey("ProductTypeId")]
        public virtual ProductType ProductType { get; set; }

        public int? ProductImageId { get; set; }
        [ForeignKey("ProductImageId")]
        public virtual ProductImage ProductImage { get; set; }

    }
}
