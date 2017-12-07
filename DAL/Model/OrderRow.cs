using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DAL.Model
{
    public class OrderRow : IEntity
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public int OrderId { get; set; }
        public decimal Qty { get; set; }
        public decimal Price { get; set; }
        public decimal Sum { get; set; }
        [Required]
        public int ProductId { get; set; }
        [ForeignKey("ProductId")]
        public virtual Product Product { get; set; }
    }
}
