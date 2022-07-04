using System;
using System.Collections.Generic;

#nullable disable

namespace ST10083941_CLDV6211_POE.Models
{
    public partial class RentalReturn
    {
        public string ReturnId { get; set; }
        public string InspectorId { get; set; }
        public string RentalId { get; set; }
        public DateTime ReturnDate { get; set; }
        public decimal DailyFine { get; set; }

        public virtual Inspector Inspector { get; set; }
        public virtual Rental Rental { get; set; }
    }
}
