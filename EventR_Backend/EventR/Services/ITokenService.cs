using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace EventR.Services
{
    public interface ITokenService
    {

        string GenerateAccessToken(IEnumerable<Claim> claims);

        string GenerateRefreshToken();

        string GenerateConfirmationToken(string email);

        string GenerateResetToken(string email);

        ClaimsPrincipal GetPrincipalFromToken(string token, bool validateLifetime);
    }
}
