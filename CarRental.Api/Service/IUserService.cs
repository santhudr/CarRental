using CarRental.Api.Models;
using System.Threading.Tasks;

namespace CarRental.Api.Service
{
    public interface IUserService
    {
        Task<UserModel> Authenticate(string username, string password);
        bool Register(UserModel user);
    }
}
