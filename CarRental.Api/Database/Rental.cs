using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace CarRental.Api.Database
{
    public partial class Rental
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int CarId { get; set; }
        public short NumberOfDays { get; set; }
        public DateTime RentalDateTime { get; set; }
        public int UserId { get; set; }

        public virtual Car Car { get; set; }
        public virtual User User { get; set; }
    }
}
