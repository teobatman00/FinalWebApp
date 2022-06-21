using System.Security.Claims;
using AutoMapper;
using FinalWebApp.Constants;
using FinalWebApp.Dto.Requests.Auth;
using FinalWebApp.Dto.Responses.Auth;
using FinalWebApp.Entities.Identities;
using FinalWebApp.Exceptions;
using FinalWebApp.Models;
using FinalWebApp.Repositories.Interfaces;
using FinalWebApp.Securities;
using FinalWebApp.Services.Interfaces;
using Microsoft.AspNetCore.Identity;

namespace FinalWebApp.Services;

public class AuthService: BaseService<AuthService>, IAuthService
{
    private ITokenManager _tokenManager;
    private IUserRepository _userRepository;
    private UserManager<AppUser> _userManager;
    private SignInManager<AppUser> _signInManager;

    public AuthService(IMapper mapper, ILogger<AuthService> logger, ITokenManager tokenManager, IUserRepository userRepository, UserManager<AppUser> userManager, SignInManager<AppUser> signInManager) : base(mapper, logger)
    {
        _tokenManager = tokenManager;
        _userRepository = userRepository;
        _userManager = userManager;
        _signInManager = signInManager;
    }

    public async Task<ApiResponse<LoginResponse>> LoginAsync(LoginRequest request)
    {
        var checkUserName = await ExistUsername(request.Username);
        if (! checkUserName)
            throw new UnauthorizedException("Username is not valid");
        var checkPassword = await _signInManager.CheckPasswordSignInAsync(
            await _userManager.FindByNameAsync(request.Username),
            request.Password,
            false
        );
        if (!checkPassword.Succeeded)
            throw new UnauthorizedException("Password is not valid");
        IEnumerable<Claim> claims = new[]
        {
            new Claim("Role", UserRole.User)
        };
        return new ApiResponse<LoginResponse>().Success(await _tokenManager.MapLoginResponse(claims));
    }

    public Task<ApiResponse<bool>> LogoutAsync()
    {
        throw new NotImplementedException();
    }

    public async Task<bool> ExistUsername(string username) =>
        await _userRepository.ExistsByAsync(s => s.Username.Equals(username))
        && _userManager.FindByNameAsync(username) != null;
}