using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using FinalWebApp.Dto.Responses.Auth;
using Microsoft.IdentityModel.Tokens;

namespace FinalWebApp.Securities
{
    public class TokenManager : ITokenManager
    {
        private readonly IConfiguration _configuration;
        private readonly ILogger<TokenManager> _logger;

        private const double TokenExpiredMinutes = 120;
        private const string TokenType = "Bearer";

        public TokenManager(IConfiguration configuration, ILogger<TokenManager> logger)
        {
            _configuration = configuration;
            _logger = logger;
        }

        public async Task<string> CreateToken(IEnumerable<Claim> claims)
        {
            try
            {
                var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration[TokenConfig.JwtKey]));
                var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
                var token = new JwtSecurityToken(
                    issuer: _configuration[TokenConfig.JwtIssuer],
                    audience: _configuration[TokenConfig.JwtIssuer],
                    claims: claims,
                    notBefore: DateTime.Now,
                    expires: DateTime.Now.AddMinutes(TokenExpiredMinutes),
                    signingCredentials: credentials
                    );
                return await Task.Run(() => new JwtSecurityTokenHandler().WriteToken(token));
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
                throw;
            }
        }

        public async Task<LoginResponse> MapLoginResponse(IEnumerable<Claim> claims)
        {
            var resultToken = await CreateToken(claims);
            return new LoginResponse
            {
                AccessToken = resultToken,
                ExpiresIn = Convert.ToInt32(TokenExpiredMinutes),
                TokenType = TokenType
            };
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
