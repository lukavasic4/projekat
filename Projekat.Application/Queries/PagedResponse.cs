using System;
using System.Collections.Generic;
using System.Text;

namespace Projekat.Application.Queries
{
    public class PagedResponse<T> where T : class
    {
        public int TotalCount { get; set; }
        public int CurrentPage { get; set; }
        public int ItemsPerPage { get; set; }
        public IEnumerable<T> Items { get; set; }
        public int PagedCount => (int)Math.Ceiling((float)TotalCount / ItemsPerPage);
    }
}
