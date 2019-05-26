using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using EventR.ViewModels;
using EventRApi.Models;

namespace EventR.Services
{
    public interface IUserService 
    {

        Task<ObjectResult> Login(LoginViewModel viewModel);

        Task AddUser(SignupViewModel viewModel);

        Task ConfirmEmail(string token);

        int GetCurrentUserId(HttpContext httpContext);

        Task ChangePassword(int userId, string oldPassword, string newPassword);

        User GetUser(string email);
    }
}
