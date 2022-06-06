using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalWebApp.Models
{
    public class BaseQueryFilter
    {
        [Range(1, int.MaxValue)]
        public int Size { get; set; }
        [Range(1, int.MaxValue)]
        public int Page { get; set; }
    }
}
