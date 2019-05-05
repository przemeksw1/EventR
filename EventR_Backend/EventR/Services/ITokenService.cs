using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EventR.Services
{
    public interface ITokenService
    {

        string GenerateConfirmationToken(string email);
    }
}
