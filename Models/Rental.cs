using System;
using System.Collections.Generic;

#nullable disable

namespace ST10083941_CLDV6211_POE.Models
{
    public partial class Rental
    {
        public Rental()
        {
            RentalReturns = new HashSet<RentalReturn>();
        }

        public string RentalId { get; set; }
        public string CarId { get; set; }
        public string InspectorId { get; set; }
        public string DriverId { get; set; }
        public decimal RentalFee { get; set; }
        public DateTime RentalStartDate { get; set; }
        public DateTime RentalEndDate { get; set; }

        public virtual Car Car { get; set; }
        public virtual Driver Driver { get; set; }
        public virtual Inspector Inspector { get; set; }
        public virtual ICollection<RentalReturn> RentalReturns { get; set; }
    }
}
