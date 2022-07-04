using System;
using System.Collections.Generic;

#nullable disable

namespace ST10083941_CLDV6211_POE.Models
{
    public partial class CarMake
    {
        public CarMake()
        {
            Cars = new HashSet<Car>();
        }

        public int MakeId { get; set; }
        public string MakeDescription { get; set; }

        public virtual ICollection<Car> Cars { get; set; }
    }
}
