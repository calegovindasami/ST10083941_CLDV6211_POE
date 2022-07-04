using System;
using System.Collections.Generic;

#nullable disable

namespace ST10083941_CLDV6211_POE.Models
{
    public partial class Car
    {
        public Car()
        {
            Rentals = new HashSet<Rental>();
        }

        public string CarId { get; set; }
        public int MakeId { get; set; }
        public int BodyTypeId { get; set; }
        public int ModelId { get; set; }
        public int KilometersTraveled { get; set; }
        public int ServiceKilometers { get; set; }
        public string Available { get; set; }

        public virtual BodyType BodyType { get; set; }
        public virtual CarMake Make { get; set; }
        public virtual CarModel Model { get; set; }
        public virtual ICollection<Rental> Rentals { get; set; }
    }
}
