using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalWebApp.Dto.Requests.Category
{
    public record CategoryUpdateRequest
    {
        [Required]
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
