using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;
using EventR.ViewModels;
using EventRApi.Models;

namespace EventR.Services.Implementations
{
    public class UserService : IUserService
    {
        private readonly Context _context;

        public UserService(Context context)
        {
            _context = context;            
        }

        public async Task<ObjectResult> Login(LoginViewModel viewModel)
        {

            return new ObjectResult(new
            {
                token = "TMPtoken"
              
            });
        }

        public async Task AddUser(SignupViewModel viewModel)
        {
            
            var user = _context.users.SingleOrDefault(u => u.Email == viewModel.Email);
            if (user != null)
                throw new ArgumentException();

          
            var newUser = new User(viewModel.NickName, viewModel.FirstName, viewModel.LastName, viewModel.Email, viewModel.Password);
            _context.users.Add(newUser);

            await _context.SaveChangesAsync();
        }
    }
}
