using System;
using System.Collections.Generic;

#nullable disable

namespace CarRental.Api.Database
{
    public partial class User
    {
        public User()
        {
            Rentals = new HashSet<Rental>();
        }

        public int Id { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }

        public virtual ICollection<Rental> Rentals { get; set; }
    }
}
