using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CalorieCounter.Model
{
    public class PagingInfo
    {
        public int TotalItems { get; set; } // to jest total items
        public int ItemsPerPage { get; set; }
        public int CurrentPage { get; set; }
        public int TotalPages => (int)Math.Ceiling((decimal)TotalItems / ItemsPerPage);

        public string UrlParam { get; set; }
    }
}
