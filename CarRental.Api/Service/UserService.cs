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
            using (var db = new CarRentalContext())
            {
                var user = db.Users.Where(x => x.UserName.ToLower() == username.ToLower()
                && x.Password.ToLower() == password.ToLower()).FirstOrDefault();

                if (user != null)
                {
                    response = new UserModel { Id = user.Id, UserName = user.UserName, Password = user.Password };
                }
            }

            return Task.FromResult(response);
        }

        public bool UserAlreadyExist(string name)
        {
            using (var db = new CarRentalContext())
            {
                return db.Users.Any(x => x.UserName.ToLower() == name);
            }
        }

        public bool Register(UserModel user)
        {
            try
            {
                var userEntity = new User
                {
                    UserName = user.UserName,
                    Password = user.Password
                };

                using (var db = new CarRentalContext())
                {
                    db.Users.Add(userEntity);
                    db.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                return false;
            }

            return true;
        }
    }
}
