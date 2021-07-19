using System;
using System.Collections.Generic;

#nullable disable

namespace CarRental.Api.Database
{
    public partial class Car
    {
        public Car()
        {
            Rentals = new HashSet<Rental>();
        }

        public int Id { get; set; }
        public int CategoryId { get; set; }
        public string Manufacturer { get; set; }
        public string CarName { get; set; }
        public decimal PricePerDay { get; set; }

        public virtual Category Category { get; set; }
        public virtual ICollection<Rental> Rentals { get; set; }
    }
}
