using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalWebApp.Dto.Responses.Product
{

    public record Category
    {
        public string Id { get; set; }
        public string Name { get; set; }
    }

    public record ProductGetListResponse
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int Discount { get; set; }
        public Category Category { get; set; }
    }
}
