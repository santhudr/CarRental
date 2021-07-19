using CarRental.Api.Database;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using SendGrid;
using SendGrid.Helpers.Mail;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace CarRental.Api.Service
{
    public class SendEmailService : ISendEmailService
    {
        public async Task<List<(string, DateTime, bool)>> SendAlert()
        {
            var alertList = new List<(string, DateTime, bool)>();
            var expiryDateTime = DateTime.Now.AddHours(6);

            using (var db = new CarRentalContext())
            {
                var expiringContracts = db.Rentals.Where(x => x.RentalDateTime.AddDays(x.NumberOfDays) <= expiryDateTime).Include(x => x.User).ToList();

                var client = new SendGridClient("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");
                var from = new EmailAddress("development@youralcove.com", "Your Alcove");
                var subject = "Your car rental contract is expiring soon";
                var to = new EmailAddress("santhudr@gmail.com", "Darryn Hart");
                var htmlContent = "Hi {0},<br/>Your contract is expiring at {1}. Please return the car before the expiry time.<br/>Your Alcove.";

                foreach (var rental in expiringContracts)
                {
                    var rentalExpiryDateTime = rental.RentalDateTime.AddDays(rental.NumberOfDays);
                    var msg = MailHelper.CreateSingleEmail(from, to, subject, string.Empty, string.Format(htmlContent, rental.User.UserName, rentalExpiryDateTime));
                    var response = await client.SendEmailAsync(msg).ConfigureAwait(false);

                    alertList.Add((rental.User.UserName, rentalExpiryDateTime, response.IsSuccessStatusCode));
                }
            }

            return alertList;
        }
    }
}
