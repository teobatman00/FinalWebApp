using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalWebApp.Models
{
    public class ApiResponse<TData>
    {
        public string Code { get; set; }
        public string Message { get; set; }
        public DateTime Date { get; set; }
        public TData Data { get; set; }
    }
}
