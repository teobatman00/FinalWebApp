using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalWebApp.Entities
{
    public class ProductEntity : BaseEntity<string>
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string Slugs { get; set; }
        public int Discount { get; set; }
        public CategoryEntity Category { get; set; }
        public List<OrderEntity> Orders { get; set; }
    }
}
