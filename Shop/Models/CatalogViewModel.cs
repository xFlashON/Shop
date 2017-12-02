using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Shop.Models
{
    public class CatalogViewModel
    {
        public IEnumerable<ProductTypeViewModel> ProductTypes;
        public IEnumerable<ProductViewModel> Products;
        public int CurrentPage { get; set; }
        public int ProductsPageSize { get; set; }
        public ProductTypeViewModel CurrentProductType { get; set; }

    }
}