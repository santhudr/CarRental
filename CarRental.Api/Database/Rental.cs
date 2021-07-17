using System;
using System.Collections.Generic;

#nullable disable

namespace CarRental.Api.Database
{
    public partial class Rental
    {
        public int Id { get; set; }
        public int CarId { get; set; }
        public short NumberOfDays { get; set; }
        public DateTime RentalDateTime { get; set; }
        public int UserId { get; set; }

        public virtual Car Car { get; set; }
        public virtual User User { get; set; }
    }
}
