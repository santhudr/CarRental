using CarRental.Api.Models;
using CarRental.Api.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CarRental.Api.Controllers
{
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IUserService userService;

        public AccountController(IUserService userService)
        {
            this.userService = userService;
        }

        [HttpPost]
        [AllowAnonymous]
        [Route("Account/Register")]
        public string Register(UserModel user)
        {
            if (string.IsNullOrWhiteSpace(user.UserName) || string.IsNullOrWhiteSpace(user.Password))
                return "Enter valid username or password";

            if (!this.userService.UserAlreadyExist(user.UserName))
            {
                var success = this.userService.Register(user);
                return success ? "Registration Successful" : "Registration Failed";
            }

            return "User already exist";
        }
    }
}
