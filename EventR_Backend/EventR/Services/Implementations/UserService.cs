﻿using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;
using EventR.ViewModels;
using EventRApi.Models;
using EventR.Helpers;
using System.Security.Claims;

namespace EventR.Services.Implementations
{
    public class UserService : IUserService
    {
        private readonly Context _context;
        private readonly ITokenService _tokenService;

        public UserService(Context context, ITokenService tokenService)
        {
            _context = context;
            _tokenService = tokenService;
        }

        public async Task<ObjectResult> Login(LoginViewModel viewModel)
        {
            var user = AuthHelper.Authenticate(viewModel.NickName, viewModel.Password, _context);
            if (user == null)
                throw new ArgumentException();

            var userClaims = new[]
            {
                new Claim(ClaimTypes.Name, user.Nickname),
                new Claim(ClaimTypes.NameIdentifier, user.UserId.ToString()),
                new Claim(ClaimTypes.Role, user.AccessLevel.ToString()),
                new Claim("Confirmed", user.EmailConfirmed.ToString()),
            };
            var jwtToken = _tokenService.GenerateAccessToken(userClaims);
            var refreshToken = _tokenService.GenerateRefreshToken();
            user.RefreshToken = refreshToken;
            await _context.SaveChangesAsync();

            return new ObjectResult(new
            {
                token = jwtToken,
                refreshToken
              
            });
        }

        public async Task AddUser(SignupViewModel viewModel)
        {
            
            var user = _context.users.SingleOrDefault(u => u.Email == viewModel.Email);
            if (user != null)
                throw new ArgumentException();

          
            var newUser = new User(viewModel.NickName, viewModel.FirstName, viewModel.LastName, viewModel.Email, viewModel.Password, viewModel.AccessLevel);
            _context.users.Add(newUser);

            await _context.SaveChangesAsync();
        }
    }
}
