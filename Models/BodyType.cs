using System;
using System.Collections.Generic;

#nullable disable

namespace ST10083941_CLDV6211_POE.Models
{
    public partial class BodyType
    {
        public BodyType()
        {
            Cars = new HashSet<Car>();
        }

        public int BodyTypeId { get; set; }
        public string BodyDescription { get; set; }

        public virtual ICollection<Car> Cars { get; set; }
    }
}
