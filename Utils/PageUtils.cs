using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalWebApp.Utils
{
    public static class PageUtils
    {

        public static int CalculateTotalPages(int count, int pageSize) => (int)Math.Ceiling(decimal.Divide(count, pageSize));
    }
}
