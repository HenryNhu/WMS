using System;
using System.Collections.Generic;

namespace WMS_new.Models
{
    public partial class Customer
    {
        public Customer()
        {
            DeliveryRequests = new HashSet<DeliveryRequest>();
        }

        public string PhoneNumber { get; set; } = null!;
        public string FullName { get; set; } = null!;
        public bool Sex { get; set; }
        public DateTime? Birthday { get; set; }
        public string DetailedAddress { get; set; } = null!;
        public int WardId { get; set; }

        public virtual ICollection<DeliveryRequest> DeliveryRequests { get; set; }
    }
}
