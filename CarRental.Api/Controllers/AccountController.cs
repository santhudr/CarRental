using CarRental.Api.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CarRental.Api.Controllers
{
    [Authorize]
    [ApiController]
    public class AccountController : ControllerBase
    {
        [HttpPost]
        [AllowAnonymous]
        public string Register(UserModel user)
        {
            return "SUCCESS";
        }

        [HttpPost]
        [AllowAnonymous]
        public string Login(UserModel user)
        {
            return "SUCCESS";
        }
    }
}
