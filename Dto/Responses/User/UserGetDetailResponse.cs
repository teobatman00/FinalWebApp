using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalWebApp.Dto.Responses.User
{
    public record UserGetDetailResponse
    {
        public string Username { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
    }
}
