using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EventR.Services;
using EventR.ViewModels;
using EventRApi.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EventR.Controllers
{

    public class TokenController : ControllerBase
    {
        private readonly ITokenService _tokenService;
        private readonly Context _context;

        public TokenController(ITokenService tokenService, Context usersDb)
        {
            _tokenService = tokenService;
            _context = usersDb;
        }
        [HttpPost]
        [Route("api/Token/Refresh")]
        public async Task<IActionResult> Refresh([FromBody] TokenViewModel tokenViewModel)
        {
            var principal = _tokenService.GetPrincipalFromToken(tokenViewModel.AccessToken, false);
            var email = principal.Identity.Name;

            var user = _context.users.SingleOrDefault(u => u.Email == email);
            if (user == null || user.RefreshToken != tokenViewModel.RefreshToken) return BadRequest();

            var newJwtToken = _tokenService.GenerateAccessToken(principal.Claims);
            var newRefreshToken = _tokenService.GenerateRefreshToken();

            user.RefreshToken = newRefreshToken;
            await _context.SaveChangesAsync();

            return new ObjectResult(new
            {
                token = newJwtToken,
                refreshToken = newRefreshToken
            });
        }
        [HttpPost, Authorize]
        [Route("api/Token/Revoke")]
        public async Task<IActionResult> Revoke()
        {
            var email = User.Identity.Name;

            var user = _context.users.SingleOrDefault(u => u.Email == email);
            if (user == null) return BadRequest();

            user.RefreshToken = null;

            await _context.SaveChangesAsync();

            return Ok();
        }
    }
}