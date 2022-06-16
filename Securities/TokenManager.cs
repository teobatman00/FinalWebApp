using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace FinalWebApp.Securities
{
    public class TokenManager : TTokenManager
    {


        public Task<string> GenerateToken(IEnumerable<Claim> claims)
        {
            throw new NotImplementedException();
        }
    }
}
