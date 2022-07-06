using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace ST10083941_CLDV6211_POE.Models
{
    public partial class Rental
    {
        public Rental()
        {
            RentalReturns = new HashSet<RentalReturn>();
        }

        [Key]
        [StringLength(6, ErrorMessage = "Rental ID cannot exceed 6 characters.")]
        [RegularExpression(@"^[0-9A-Za-z\s]*$", ErrorMessage = "Use alphanumeric characters only please.")]
        [Required]
        [DisplayName("Rental ID")]
        public string RentalId { get; set; }

        [RegularExpression(@"^[0-9A-Za-z\s]*$", ErrorMessage = "Use alphanumeric characters only please.")]
        [StringLength(6, ErrorMessage = "Car ID cannot exceed 6 characters.")]
        [Required]
        public string CarId { get; set; }

        [RegularExpression(@"^[0-9A-Za-z\s]*$", ErrorMessage = "Use alphanumeric characters only please.")]
        [Required]
        [StringLength(4, ErrorMessage = "Inspector ID cannot exceed 4 characters.")]
        public string InspectorId { get; set; }

        [RegularExpression(@"^[0-9A-Za-z\s]*$", ErrorMessage = "Use alphanumeric characters only please.")]
        [Required]
        [StringLength(4, ErrorMessage = "Driver ID cannot exceed 4 characters.")]
        public string DriverId { get; set; }

        [DataType(DataType.Currency)]
        [Required]
        [Range(0, int.MaxValue, ErrorMessage = "Value cannot be lower than 0.")]
        public decimal RentalFee { get; set; }

        [DisplayName("Rental Start Date")]
        [DataType(DataType.Date)]
        [Required]
        public DateTime RentalStartDate { get; set; }

        [DisplayName("Rental End Date")]
        [DataType(DataType.Date)]
        [Required]
        public DateTime RentalEndDate { get; set; }

        public virtual Car Car { get; set; }
        public virtual Driver Driver { get; set; }
        public virtual Inspector Inspector { get; set; }
        public virtual ICollection<RentalReturn> RentalReturns { get; set; }
    }
}
