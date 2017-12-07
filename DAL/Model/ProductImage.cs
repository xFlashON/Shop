using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DAL.Model
{
    public class ProductImage : IEntity
    {
        [Key]
        public int Id { get; set; }
        public byte[] Image { get; set; }
    }
}

