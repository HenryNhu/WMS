using System;
using System.Collections.Generic;

namespace WMS_new.Models
{
    public partial class Nation
    {
        public Nation()
        {
            Locations = new HashSet<Location>();
        }

        public int NationId { get; set; }
        public string NationName { get; set; } = null!;

        public virtual ICollection<Location> Locations { get; set; }
    }
}
