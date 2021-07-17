using System;
using System.Collections.Generic;

#nullable disable

namespace CarRental.Api.Database
{
    public partial class Category
    {
        public Category()
        {
            Cars = new HashSet<Car>();
        }

        public int Id { get; set; }
        public string CategoryName { get; set; }

        public virtual ICollection<Car> Cars { get; set; }
    }
}
