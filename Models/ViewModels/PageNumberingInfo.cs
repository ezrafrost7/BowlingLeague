using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BowlingLeague.Models.ViewModels
{
    public class PageNumberingInfo
    {
        public int ItemsPerPage { get; set; }
        public int CurrentPage { get; set; }
        public int TotalItems { get; set; }
        //calculate total number of pages
        public int NumPages => (int) Math.Ceiling( (decimal) TotalItems / ItemsPerPage);
    }
}
