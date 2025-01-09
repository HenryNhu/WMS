using System;
using System.Collections.Generic;

namespace WMS_new.Models
{
    public partial class Province
    {
        public Province()
        {
            Districts = new HashSet<District>();
        }

        public int ProvinceId { get; set; }
        public string ProvinceName { get; set; } = null!;
        public int LocationId { get; set; }

        public virtual Location Location { get; set; } = null!;
        public virtual ICollection<District> Districts { get; set; }
    }
}
