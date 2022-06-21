using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using FinalWebApp.Exceptions;
using FinalWebApp.Models;

namespace FinalWebApp.Middlewares
{
    public class ExceptionHandlerMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger _logger;
        public ExceptionHandlerMiddleware(RequestDelegate next, ILogger logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception e)
            {
                var response = context.Response;
                response.ContentType = "application/json";
                var responseModel = new ApiResponse<object>();
                _logger.LogError(e.Message);
                switch (e)
                {
                    case NotFoundDataException:
                        response.StatusCode = Convert.ToInt32(HttpStatusCode.NotFound);
                        responseModel.NotFound(e.Message);
                        break;
                    case BadRequestException:
                        response.StatusCode = Convert.ToInt32(HttpStatusCode.BadRequest);
                        responseModel.BadRequest(e.Message);
                        break;
                    case UnauthorizedException:
                        response.StatusCode = Convert.ToInt32(HttpStatusCode.Unauthorized);
                        responseModel.Unauthorized(e.Message);
                        break;
                    default:
                        response.StatusCode = Convert.ToInt32(HttpStatusCode.InternalServerError);
                        responseModel.ServerError(null);
                        break;
                }

                await response.WriteAsync(JsonSerializer.Serialize(response));
            }
        }
        
        
    }
}
