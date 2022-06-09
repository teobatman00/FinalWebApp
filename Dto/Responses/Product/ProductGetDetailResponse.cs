using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalWebApp.Dto.Responses.Product
{
    public record ProductGetDetailResponse
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string Slugs { get; set; }
        public int Discount { get; set; }
    }
}
