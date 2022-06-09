using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalWebApp.Dto.Requests.Product
{
    public record ProductCreateRequest
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public decimal Price { get; set; }
        [Required]
        public string Slugs { get; set; }
        public int Discount { get; set; }
        [Required]
        public string CategoryId { get; set; }
        public List<string> OrdersId { get; set; }
        
    }
}
