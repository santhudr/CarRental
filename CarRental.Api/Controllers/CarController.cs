using CarRental.Api.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarRental.Api.Controllers
{
    [AllowAnonymous]
    public class CarController : Controller
    {
        [HttpGet]
        public List<string> Categories()
        {
            return new List<string>();
        }

        [HttpGet]
        public List<Car> Find(string manufacturer)
        {
            return new List<Car>();
        }

        public List<Car> Get(int pageId = 1, bool ascending = true)
        {
            return new List<Car>();
        }

        public List<Car> Get(string name)
        {
            return new List<Car>();
        }
    }
}
