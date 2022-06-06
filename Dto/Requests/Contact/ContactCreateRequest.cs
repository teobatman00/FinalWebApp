using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalWebApp.Dto.Requests.Contact
{
    public class ContactCreateRequest
    {
        [Required]
        public string FullName { get; set; }
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        [Phone]
        public string Phone { get; set; }
        public string Address { get; set; }
        [Required]
        public string Subject { get; set; }
        public string Message { get; set; }

    }
}
