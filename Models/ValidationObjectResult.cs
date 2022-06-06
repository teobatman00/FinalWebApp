using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace FinalWebApp.Models
{
    public class ValidationObjectResult: ObjectResult
    {
        public ValidationObjectResult(ModelStateDictionary modelState):
            base(new ApiResponse<object>().BadRequest(new ValidationResultResponse(modelState)))
        {
            StatusCode = Convert.ToInt32(HttpStatusCode.BadRequest);
        }
    }
}
