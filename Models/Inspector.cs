using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

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
        [RegularExpression(@"^[0-9A-Za-z]*$", ErrorMessage = "Use alphanumeric characters only please.")]
        [DisplayName("Inspector ID")]
        [Required]
        [StringLength(4, ErrorMessage = "Inspector ID cannot exceed 4 characters.")]
        [Key]
        public string InspectorId { get; set; }
        [RegularExpression(@"^[A-Za-z]*$", ErrorMessage = "Use letters only please.")]
        [DisplayName("Full Name")]
        [StringLength(100, ErrorMessage = "Inspector name cannot exceed 100 characters.")]
        [Required]
        public string InspectorName { get; set; }
        [StringLength(100, ErrorMessage = "Email cannot exceed 100 characters.")]
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Phone]
        [StringLength(10, ErrorMessage = "Phone number cannot exceed 10 characters")]
        [Required]
        [RegularExpression(@"^[0-9]*$", ErrorMessage = "Invalid phone number.")]
        [DisplayName("Phone Number")]
        public string MobileNumber { get; set; }

        public virtual ICollection<RentalReturn> RentalReturns { get; set; }
        public virtual ICollection<Rental> Rentals { get; set; }
    }
}
