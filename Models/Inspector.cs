using System;
using System.Collections.Generic;

#nullable disable

namespace ST10083941_CLDV6211_POE.Models
{
    public partial class Inspector
    {
        public Inspector()
        {
            RentalReturns = new HashSet<RentalReturn>();
            Rentals = new HashSet<Rental>();
        }

        public string InspectorId { get; set; }
        public string InspectorName { get; set; }
        public string Email { get; set; }
        public string MobileNumber { get; set; }

        public virtual ICollection<RentalReturn> RentalReturns { get; set; }
        public virtual ICollection<Rental> Rentals { get; set; }
    }
}
