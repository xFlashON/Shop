using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DAL.Model
{
    public class Order: IEntity
    {
        public Order()
        {
            this.OrderRows = new HashSet<OrderRow>();
        }
        [Key]
        public int Id { get; set; }
        [Required]
        public System.DateTime Date { get; set; }
        public bool Payed { get; set; }
        public decimal Total { get; set; }
        public PaymentType PaymentType { get; set; }

        public virtual ICollection<OrderRow> OrderRows { get; set; }

    }
}
