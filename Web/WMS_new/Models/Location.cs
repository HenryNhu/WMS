using System;
using System.Collections.Generic;

namespace WMS_new.Models
{
    public partial class Location
    {
        public Location()
        {
            Provinces = new HashSet<Province>();
        }

        public int LocationId { get; set; }
        public string LocationName { get; set; } = null!;
        public int NationId { get; set; }

        public virtual Nation Nation { get; set; } = null!;
        public virtual ICollection<Province> Provinces { get; set; }
    }
}
