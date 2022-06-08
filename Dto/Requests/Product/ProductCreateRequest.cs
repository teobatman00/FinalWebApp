using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalWebApp.Dto.Requests.Product
{
    public record ProductCreateRequest
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string Slugs { get; set; }
        public int Discount { get; set; }
        public string CategoryId { get; set; }
        public List<string> OrdersId { get; set; }
        
    }
}
