using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servises.Models
{
    public class PriceListDTO
    {
        public int Records { get; set; }

        public int PageSize { get; set; }

        public int Total { get; set; }

        public IEnumerable<PriceDTO> rows { get; set; }

    }
}
