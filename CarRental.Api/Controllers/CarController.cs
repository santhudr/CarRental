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
            using (var db = new CarRentalContext())
            {
                return db.Cars.Where(x => string.Equals(x.Manufacturer, manufacturer, StringComparison.InvariantCultureIgnoreCase))
                    .Select(x => new CarModel
                    {
                        Id = x.Id,
                        Name = x.CarName,
                        Availability = db.Rentals.All(r => r.CarId != x.Id)
                    }).ToList();
            };
        }

        public List<CarModel> Get(int pageId = 1, bool ascending = true)
        {
            using (var db = new CarRentalContext())
            {
                var sortedList = ascending ? db.Cars.OrderBy(x => x.PricePerDay) : db.Cars.OrderByDescending(x => x.PricePerDay);
                return sortedList.Skip(5 * (pageId - 1)).TakeLast(5)
                    .Select(x => new CarModel
                    {
                        Id = x.Id,
                        Name = x.CarName,
                        Availability = db.Rentals.All(r => r.CarId != x.Id)
                    }).ToList();
            }
        }

        public List<CarModel> Get(string name)
        {
            return new List<CarModel>();
        }
    }
}
