using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalWebApp.Dto.Responses.Product
{

    public record Order
    {
        public string Id { get; set; }
        public int  Quantity { get; set; }
    }

    public record ProductGetDetailResponse
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string Slugs { get; set; }
        public int Discount { get; set; }
        public Category Category { get; set; }
        public List<Order> Orders { get; set; }
    }
}
