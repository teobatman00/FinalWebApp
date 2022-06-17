using FinalWebApp.Controllers.Interfaces;
using FinalWebApp.Dto.Requests.Auth;
using FinalWebApp.Dto.Responses.Auth;
using FinalWebApp.Filters;
using FinalWebApp.Models;
using FinalWebApp.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace FinalWebApp.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AuthController: ControllerBase, IAuthController
{
    private IAuthService _authService;

    public AuthController(IAuthService authService)
    {
        _authService = authService;
    }

    [HttpPost("login"), ValidatedModel]
    public async Task<ActionResult<ApiResponse<LoginResponse>>> LoginAsync([FromBody] LoginRequest request)
    {
        var result = await _authService.LoginAsync(request);
        return Ok(result);
    }
}