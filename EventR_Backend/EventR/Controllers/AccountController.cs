using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using EventR.ViewModels;
using EventR.Services;
using EventRApi.Models;

namespace EventR.Controllers
{

    public class AccountController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IEmailService _emailService;
        private readonly Context _context;
        public AccountController(IUserService userService, IEmailService emailService, Context context)
        {
            _userService = userService;
            _emailService = emailService;
            _context = context;
        }


        [HttpPost]
        [Route("api/Account/Login")]
        public async Task<IActionResult> Login([FromBody] LoginViewModel viewModel)
        {
            try
            {
                var result = await _userService.Login(viewModel);
                return result;
            }
            catch (ArgumentException)
            {
                return BadRequest();
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
        
        [HttpPost]
        [Route("api/Account/Signup")]
        public async Task<IActionResult> Signup([FromBody]SignupViewModel viewModel)
        {
           
            try
            {
                await _userService.AddUser(viewModel);
                _emailService.SendConfirmationEmail(viewModel.Email);
                return Ok();
            }
            catch (ArgumentException)
            {
                return BadRequest("Cos nie dziala");
            }

        }


        [HttpPost]
        [Route("account/ConfirmEmail/{token}")]
        public async Task<IActionResult> ConfirmEmail(string token)
        {
            try
            {
                await _userService.ConfirmEmail(token);
                return Ok();
            }
            catch (ArgumentException)
            {
                return BadRequest();
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        // Zmiana hasla
        [HttpPost]
        [Route("api/Account/ChangePassword")]
        public async Task<IActionResult> ChangePassword([FromBody] ChangePasswordViewModel viewModel)
        {
            try
            {
                var userId = _userService.GetCurrentUserId(HttpContext);
                await _userService.ChangePassword(userId, viewModel.OldPassword, viewModel.NewPassword);
                return Ok();
            }
            catch (ArgumentException)
            {
                return BadRequest();
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpPost]
        [Route("api/Account/ResetPassword")]
        public IActionResult ResetPassword([FromBody] RequestResetPasswordViewModel viewModel)
        {
            try
            {
                var user = _userService.GetUser(viewModel.Email);
                _emailService.SendResetPassword(user.Email);
                return Ok();
            }
            catch(ArgumentException)
            {
                return BadRequest();
            }
            catch(Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }


    }
}