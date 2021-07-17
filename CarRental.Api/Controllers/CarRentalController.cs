using CarRental.Api.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarRental.Api.Controllers
{
    [Authorize]
    [ApiController]
    public class CarRentalController : ControllerBase
    {
        [HttpPost]
        [AllowAnonymous]
        public string Register(User user)
        {
            return "SUCCESS";
        }

        [HttpPost]
        [AllowAnonymous]
        public string Login(User user)
        {
            return "SUCCESS";
        }

        [AllowAnonymous]
        public List<string> Categories()
        {
            return new List<string>();
        }

        public List<>
    }
}
