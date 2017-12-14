using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servises.Models
{
    public class PriceDTO
    {
        public int Id { get; set; }
        public int PriceTypeId { get; set; }
        public string PriceTypeName{ get; set; }
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public decimal Price { get; set; }
    }
}
