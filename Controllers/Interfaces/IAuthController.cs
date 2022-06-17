using FinalWebApp.Dto.Requests.Auth;
using FinalWebApp.Dto.Responses.Auth;
using FinalWebApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace FinalWebApp.Controllers.Interfaces;

public interface IAuthController
{
    Task<ActionResult<ApiResponse<LoginResponse>>> LoginAsync([FromBody] LoginRequest request);
}