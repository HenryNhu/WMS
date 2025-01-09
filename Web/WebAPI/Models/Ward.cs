using System;
using System.Collections.Generic;

namespace WMS_new.Models
{
    public partial class Ward
    {
        public Ward()
        {
            DeliveryRequests = new HashSet<DeliveryRequest>();
            Warehouses = new HashSet<Warehouse>();
        }

        public int WardId { get; set; }
        public string WardName { get; set; } = null!;
        public int DistrictId { get; set; }

        public virtual District District { get; set; } = null!;
        public virtual ICollection<DeliveryRequest> DeliveryRequests { get; set; }
        public virtual ICollection<Warehouse> Warehouses { get; set; }
    }
}
