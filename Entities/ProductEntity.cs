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
        public string Slugs { get; set; }
    }
}
