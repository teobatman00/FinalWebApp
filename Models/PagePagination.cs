using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalWebApp.Models
{
    public class PagePagination<TData>
    {
        public int TotalElements { get; set; }
        public int First { get; set; }
        public int Last { get; set; }
        public IEnumerable<TData> Content { get; set; }
    }
}
