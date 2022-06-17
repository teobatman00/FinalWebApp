using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using FinalWebApp.Dto.Responses.Auth;

namespace FinalWebApp.Securities
{
    public class TokenManager : ITokenManager
    {
        private readonly IConfiguration _configuration;
        private readonly ILogger<TokenManager> _logger;

        public TokenManager(IConfiguration configuration, ILogger<TokenManager> logger)
        {
            _configuration = configuration;
            _logger = logger;
        }

        public Task<string> GenerateToken(IEnumerable<Claim> claims)
        {
            throw new NotImplementedException();
        }

        public Task<LoginResponse> MapLoginResponse(IEnumerable<Claim> claims)
        {
            throw new NotImplementedException();
        }

        public async Task<string> GenerateRandomToken()
        {
            var randomNumber = new byte[64];
            using var rng = RandomNumberGenerator.Create();
            await Task.Run(() => rng.GetBytes(randomNumber));
            return Convert.ToBase64String(randomNumber);
        }
    }
}
