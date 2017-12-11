using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Shop.Models
{
    public class NewsListViewModel
    {
        public IEnumerable<NewsViewModel> NewsList { get; set; }

        public int CurrentPage { get; set; }
    }
}