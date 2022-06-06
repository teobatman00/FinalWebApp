using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalWebApp.Models
{
    public class ValidationResultResponse
    {
        public string Message { get; set; }
        public string Fields { get; set; }
        public List<ValidationResultResponse> Errors { get; set; }

        public ValidationResultResponse() { }

        public ValidationResultResponse(ModelStateDictionary modelState)
        {
            Message = "Validation failed";
            Errors = modelState.Keys
                .SelectMany(key => modelState[key].Errors.Select(x => new ValidationResultResponse
                {
                    Fields = key,
                    Message = x.ErrorMessage
                })).ToList();
        }
    }
}
