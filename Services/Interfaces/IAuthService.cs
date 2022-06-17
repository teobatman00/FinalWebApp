using FinalWebApp.Dto.Requests.Auth;
using FinalWebApp.Dto.Responses.Auth;
using FinalWebApp.Models;

namespace FinalWebApp.Services.Interfaces;

public interface IAuthService
{
    Task<ApiResponse<LoginResponse>> LoginAsync(LoginRequest request);
}