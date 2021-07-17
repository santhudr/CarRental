namespace CarRental.Api.Models
{
    public class UserModel
    {
        public string UserName { get; set; }

        public string Password { get; set; }
        public int Id { get; internal set; }
    }
}
