using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
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

        public ApiResponse<TData> Success(TData? data)
        {
            Code = HttpStatusCode.OK.ToString();
            Message = "Success";
            Date = DateTime.Now;
            Data = data;
            return this;
        }

        public ApiResponse<TData> BadRequest(TData? data)
        {
            Code = HttpStatusCode.BadRequest.ToString();
            Message = "Bad Request";
            Date = DateTime.Now;
            Data = data;
            return this;
        }

        public ApiResponse<TData> NotFound(TData? data)
        {
            Code = HttpStatusCode.NotFound.ToString();
            Message = "Not Found";
            Date = DateTime.Now;
            Data = data;
            return this;
        }

        public ApiResponse<TData> ServerError(TData? data)
        {
            Code = HttpStatusCode.InternalServerError.ToString();
            Message = "Server Internal Error";
            Date = DateTime.Now;
            Data = data;
            return this;
        }
    }
}
