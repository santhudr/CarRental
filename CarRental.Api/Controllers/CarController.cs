using CarRental.Api.Database;
using CarRental.Api.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CarRental.Api.Controllers
{
    [ApiController]
    [AllowAnonymous]
    public class CarController : ControllerBase
    {
        [HttpGet]
        [Route("Car/Categories")]
        public List<string> Categories()
        {
            using (var db = new CarRentalContext())
            {
                return db.Categories.Select(x => x.CategoryName).ToList();
            }
        }

        [HttpGet]
        [Route("Car/Find")]
        public List<CarModel> Find(string manufacturer)
        {
            if (!string.IsNullOrWhiteSpace(manufacturer))
            {
                using (var db = new CarRentalContext())
                {
                    return db.Cars.Where(x => x.Manufacturer.ToLower() == manufacturer.ToLower())
                        .Select(x => new CarModel
                        {
                            Id = x.Id,
                            Name = x.CarName,
                            Availability = db.Rentals.All(r => r.CarId != x.Id)
                        }).ToList();
                };
            }

            return new List<CarModel>();
        }

        [HttpGet]
        [Route("Car")]
        public List<CarModel> Get(int pageId = 1, bool ascending = true)
        {
            using (var db = new CarRentalContext())
            {
                var sortedList = ascending ? db.Cars.OrderBy(x => x.PricePerDay) : db.Cars.OrderByDescending(x => x.PricePerDay);
                return sortedList.ToList().Skip(5 * (pageId - 1)).TakeLast(5)
                    .Select(x => new CarModel
                    {
                        Id = x.Id,
                        Name = x.CarName,
                        Availability = db.Rentals.All(r => r.CarId != x.Id)
                    }).ToList();
            }
        }

        [HttpGet]
        [Route("Car/Search")]
        public List<CarModel> Search(string name)
        {
            using (var db = new CarRentalContext())
            {
                return db.Cars.Where(x => x.CarName.ToLower().Contains((name ?? string.Empty).ToLower()))
                    .Select(x => new CarModel
                    {
                        Id = x.Id,
                        Name = x.CarName,
                        Availability = db.Rentals.All(r => r.CarId != x.Id)
                    }).ToList();
            };
        }
    }
}
