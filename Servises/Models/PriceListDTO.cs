using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servises.Models
{
    public class PriceListDTO
    {
        public int records { get; set; }

        public int page { get; set; }

        public int total { get; set; }

        public IEnumerable<PriceDTO> rows { get; set; }

    }
}
