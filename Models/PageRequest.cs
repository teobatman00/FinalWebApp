using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalWebApp.Models
{
    public class PageRequest
    {
        [Range(minimum: 1, maximum: int.MaxValue)]
        public int Size { get; set; } = 1;
        [Range(minimum: 1, maximum: int.MaxValue)]
        public int Page { get; set; } = 1;

        public static PageRequest of(int page, int size) => new PageRequest
        {
            Size = size,
            Page = page
        };

    }
}
