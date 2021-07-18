using CarRental.Api.Database;
using CarRental.Api.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Security.Claims;
using System.Security.Principal;

namespace CarRental.Api.Controllers
{
    public class RentController : Controller
    {
        private readonly IPrincipal principal;
        public RentController(IPrincipal principal)
        {
            this.principal = principal;
        }

        public string Post(RentalModel rental)
        {
            try
            {
                if (rental.numberOfDays < 1 || rental.numberOfDays > 7)
                    return "Rental allowed from 1 day to maximum of 7 days";

                var userId = ((ClaimsIdentity)principal.Identity)?.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier)?.Value;

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
    }
}
