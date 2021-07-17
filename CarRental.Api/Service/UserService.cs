using CarRental.Api.Database;
using CarRental.Api.Models;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace CarRental.Api.Service
{
    public class UserService : IUserService
    {
        public Task<UserModel> Authenticate(string username, string password)
        {
            UserModel response = null;
            using (var context = new CarRentalContext())
            {
                var user = context.Users.Where(x => string.Equals(x.UserName, username, StringComparison.InvariantCultureIgnoreCase)
                && string.Equals(x.Password, password, StringComparison.InvariantCulture)).FirstOrDefault();

                if (user != null)
                {
                    response = new UserModel { Id = user.Id, UserName = user.UserName, Password = user.Password };
                }
            }

            return Task.FromResult(response);
        }
    }
}
