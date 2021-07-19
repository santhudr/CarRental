using CarRental.Api.Database;
using CarRental.Api.Models;
using CarRental.Api.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace CarRental.Api.Controllers
{
    [ApiController]
    public class RentController : ControllerBase
    {
        private readonly ISendEmailService sendEmailService;
        public RentController(ISendEmailService sendEmailService)
        {
            this.sendEmailService = sendEmailService;
        }

        [Route("Rent")]
        [HttpPost]
        [Authorize]
        public string Post(RentalModel rental)
        {
            try
            {
                if (rental.numberOfDays < 1 || rental.numberOfDays > 7)
                    return "Rental allowed from 1 day to maximum of 7 days";
                var userId = ((ClaimsIdentity)HttpContext.User?.Identity)?.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier)?.Value;

                if (userId == null)
                    return "Rental is not completed due to problem with Authentication";

                var rentalEntity = new Rental
                {
                    CarId = rental.CarId,
                    NumberOfDays = rental.numberOfDays,
                    UserId = Convert.ToInt32(userId),
                    RentalDateTime = DateTime.Now
                };
                using (var db = new CarRentalContext())
                {
                    if (db.Rentals.Any(r => r.CarId == rental.CarId))
                    {
                        return "Car is already rented";
                    }

                    db.Rentals.Add(rentalEntity);
                    db.SaveChanges();
                }

                return "Rental successfully completed";
            }
            catch
            {
                return "Unable to complete the Rental. Please try again";
            }
        }

        [AllowAnonymous]
        [Route("Rent/SendAlert")]
        [HttpGet]
        public async Task<List<(string, DateTime, bool)>> SendAlert()
        {
            return await this.sendEmailService.SendAlert();
        }
    }
}
