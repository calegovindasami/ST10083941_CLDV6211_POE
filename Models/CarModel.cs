using System;
using System.Collections.Generic;

#nullable disable

namespace ST10083941_CLDV6211_POE.Models
{
    public partial class CarModel
    {
        public CarModel()
        {
            Cars = new HashSet<Car>();
        }

        public int ModelId { get; set; }
        public string ModelDescription { get; set; }

        public virtual ICollection<Car> Cars { get; set; }
    }
}
