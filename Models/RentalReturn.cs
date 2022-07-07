using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace ST10083941_CLDV6211_POE.Models
{
    public partial class RentalReturn
    {
        [Key]
        [StringLength(6, ErrorMessage = "Renturn ID cannot exceed 6 characters.")]
        [RegularExpression(@"^[0-9A-Za-z\s]*$", ErrorMessage = "Use alphanumeric characters only please.")]
        [Required]
        [DisplayName("Return ID")]
        public string ReturnId { get; set; }
        public string InspectorId { get; set; }
        public string RentalId { get; set; }

        [DisplayName("Return Date")]
        [DataType(DataType.Date)]
        [Required]
        public DateTime ReturnDate { get; set; }

        [DataType(DataType.Currency)]
        [Required]
        [DisplayName("Daily Fine")]
        [Range(0, int.MaxValue, ErrorMessage = "Value cannot be lower than 0.")]
        public decimal DailyFine { get; set; }
        [DisplayName("Inspector ID")]
        public virtual Inspector Inspector { get; set; }
        [DisplayName("Rental ID")]
        public virtual Rental Rental { get; set; }
    }
}
