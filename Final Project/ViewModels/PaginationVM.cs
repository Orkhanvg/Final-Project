using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Final_Project.ViewModels
{
    public class PaginationVM<T>
    {
        public List<T> Items { get; set; }
        public int PageCount { get; set; }
        public int CurrentPage { get; set; }

        public PaginationVM(List<T> items, int pagecount, int currentpage)
        {
            Items = items;
            PageCount = pagecount;
            CurrentPage = currentpage;
        }
    }
}
