using System;
using System.Collections.Generic;

namespace WMS_new.Models
{
    public partial class DeliveryRequest
    {
        public DeliveryRequest()
        {
            HistoryOfDeliveryRequests = new HashSet<HistoryOfDeliveryRequest>();
            Verifies = new HashSet<Verify>();
        }

        public long DeliveryId { get; set; }
        public string DeliveryType { get; set; } = null!;
        public bool IsComplete { get; set; }
        public string? DeliveryNote { get; set; }
        public string DetailedAddress { get; set; } = null!;
        public int WarehouseIdDes { get; set; }
        public string? PhoneNumberCustomer { get; set; }
        public int WardId { get; set; }
        public long Imei { get; set; }
        public long CommitmentTimeId { get; set; }

        public virtual CommitmentTime CommitmentTime { get; set; } = null!;
        public virtual ImeiProduct ImeiNavigation { get; set; } = null!;
        public virtual Customer? PhoneNumberCustomerNavigation { get; set; }
        public virtual Ward Ward { get; set; } = null!;
        public virtual Warehouse WarehouseIdDesNavigation { get; set; } = null!;
        public virtual ICollection<HistoryOfDeliveryRequest> HistoryOfDeliveryRequests { get; set; }
        public virtual ICollection<Verify> Verifies { get; set; }
    }
}
