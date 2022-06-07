using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace FinalWebApp.Dto.Responses.Category
{
    public record CategoryGetListResponse
    {
        public string Id { get; set; }
        public string Name { get; set; }
    }
}
