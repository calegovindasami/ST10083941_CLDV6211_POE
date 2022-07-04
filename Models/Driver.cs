using System;
using System.Collections.Generic;

#nullable disable

namespace ST10083941_CLDV6211_POE.Models
{
    public partial class Driver
    {
        public Driver()
        {
            Rentals = new HashSet<Rental>();
        }

        public string DriverId { get; set; }
        public string DriverName { get; set; }
        public string Email { get; set; }
        public string DriverAddress { get; set; }
        public string MobileNumber { get; set; }

        public virtual ICollection<Rental> Rentals { get; set; }
    }
}
