using System;
using System.Collections.Generic;

namespace WMS_new.Models
{
    public partial class CommitmentTime
    {
        public CommitmentTime()
        {
            DeliveryRequests = new HashSet<DeliveryRequest>();
        }

        public long CommitmentTimeId { get; set; }
        public DateTime TimeSlot { get; set; }
        public int Maxslots { get; set; }
        public int RemainingSlots { get; set; }
        public bool IsActive { get; set; }
        public int WarehouseId { get; set; }

        public virtual Warehouse Warehouse { get; set; } = null!;
        public virtual ICollection<DeliveryRequest> DeliveryRequests { get; set; }
    }
}
