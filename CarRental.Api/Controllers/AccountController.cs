using CarRental.Api.Models;
using CarRental.Api.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CarRental.Api.Controllers
{
    [Authorize]
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
        public string Register(UserModel user)
        {
           var success = this.userService.Register(user);
            return success ? "Registration Successful": "Registration Failed";
        }

        [HttpPost]
        [AllowAnonymous]
        public string Login(UserModel user)
        {
            return "SUCCESS";
        }
    }
}
