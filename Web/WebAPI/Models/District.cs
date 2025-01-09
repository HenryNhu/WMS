using System;
using System.Collections.Generic;

namespace WMS_new.Models
{
    public partial class District
    {
        public District()
        {
            Wards = new HashSet<Ward>();
        }

        public int DistrictId { get; set; }
        public string DistrictName { get; set; } = null!;
        public int ProvinceId { get; set; }

        public virtual Province Province { get; set; } = null!;
        public virtual ICollection<Ward> Wards { get; set; }
    }
}
