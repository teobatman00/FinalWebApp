using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalWebApp.Dto.Requests.User
{
    public record UserUpdateRequest
    {
        [EmailAddress]
        public string Email { get; set; }
        [Required, Phone]
        public string Phone { get; set; }
    }
}
