using CarRental.Api.Database;
using CarRental.Api.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CarRental.Api.Controllers
{
    [AllowAnonymous]
    public class CarController : Controller
    {
        [HttpGet]
        public List<string> Categories()
        {
            using (var db = new CarRentalContext())
            {
                return db.Categories.Select(x => x.CategoryName).ToList();
            }
        }

        [HttpGet]
        public List<CarModel> Find(string manufacturer)
        {
            return new List<CarModel>();
        }

        public List<CarModel> Get(int pageId = 1, bool ascending = true)
        {
            return new List<CarModel>();
        }

        public List<CarModel> Get(string name)
        {
            return new List<CarModel>();
        }
    }
}
