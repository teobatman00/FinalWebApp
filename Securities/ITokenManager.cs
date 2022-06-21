using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using FinalWebApp.Dto.Responses.Auth;

namespace FinalWebApp.Securities
{
    public interface ITokenManager
    {
        Task<string> CreateToken(IEnumerable<Claim> claims);
        Task<LoginResponse> MapLoginResponse(IEnumerable<Claim> claims);
        Task<string> GenerateRandomToken();
    }
}
