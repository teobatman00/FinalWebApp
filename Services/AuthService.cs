using System.Security.Claims;
using AutoMapper;
using FinalWebApp.Constants;
using FinalWebApp.Dto.Requests.Auth;
using FinalWebApp.Dto.Responses.Auth;
using FinalWebApp.Exceptions;
using FinalWebApp.Models;
using FinalWebApp.Repositories.Interfaces;
using FinalWebApp.Securities;
using FinalWebApp.Services.Interfaces;

namespace FinalWebApp.Services;

public class AuthService: BaseService<AuthService>, IAuthService
{
    private ITokenManager _tokenManager;
    private IUserRepository _userRepository;

    public AuthService(IMapper mapper, ILogger<AuthService> logger, ITokenManager tokenManager, IUserRepository userRepository) : base(mapper, logger)
    {
        _tokenManager = tokenManager;
        _userRepository = userRepository;
    }

    public async Task<ApiResponse<LoginResponse>> LoginAsync(LoginRequest request)
    {
        var userEntity = await _userRepository.GetOneByAsync(s =>
            s.Username.Equals(request.Username) && s.Password.Equals(request.Password));
        if (userEntity is null)
            throw new NotFoundDataException("Username or password is not valid");
        IEnumerable<Claim> claims = new[]
        {
            new Claim("Role", UserRole.User)
        };
        return new ApiResponse<LoginResponse>().Success(new LoginResponse());
    }
}