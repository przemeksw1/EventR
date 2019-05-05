using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using EventR.ViewModels;
using EventR.Services;

namespace EventR.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IEmailService _emailService;

        public AccountController(IUserService userService, IEmailService emailService)
        {
            _userService = userService;
            _emailService = emailService;
        }


        [HttpPost]
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
        public async Task<IActionResult> Signup([FromBody] SignupViewModel viewModel)
        {
            try
            {
                await _userService.AddUser(viewModel);
                //_emailService.SendConfirmationEmail(viewModel.Email);
                return Ok();
            }
            catch (ArgumentException ex)
            {
                return BadRequest();
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
    }
}