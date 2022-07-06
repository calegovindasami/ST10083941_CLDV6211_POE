using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
#nullable disable

namespace ST10083941_CLDV6211_POE.Models
{
    public partial class Car
    {
        public Car()
        {
            Rentals = new HashSet<Rental>();
        }
        
        [DisplayName("Car ID")]
        [RegularExpression(@"^[0-9A-Za-z]*$", ErrorMessage = "Use alphanumeric characters only please.")]
        [StringLength(6, ErrorMessage = "The Car ID cannot exceed 6 characters.")]
        [Key]
        [Required]
        public string CarId { get; set; }
        [Required]
        [DisplayName("Make")]
        public int MakeId { get; set; }
        [DisplayName("Body Type")]
        [Required]
        public int BodyTypeId { get; set; }
        [DisplayName("Model")]
        [Required]
        public int ModelId { get; set; }
        [DisplayName("Kilometers Traveled")]
        [Required]
        [Range(0, int.MaxValue,  ErrorMessage = "Value cannot be lower than 0.")]
        public int KilometersTraveled { get; set; }
        [DisplayName("Service Kilometers")]
        [Required]
        [Range(0, int.MaxValue, ErrorMessage = "Value cannot be lower than 0.")]
        public int ServiceKilometers { get; set; }
        [DisplayName("Available")]
        [StringLength(1, ErrorMessage = "The Available field cannot exceed 1 character.")]
        [Required]
        public string Available { get; set; }

        [DisplayName("Body Type")]
        public virtual BodyType BodyType { get; set; }
        public virtual CarMake Make { get; set; }
        public virtual CarModel Model { get; set; }
        public virtual ICollection<Rental> Rentals { get; set; }
    }
}
