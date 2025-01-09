using System;
using System.Collections.Generic;

namespace WMS_new.Models
{
    public partial class HistoryOfDeliveryRequest
    {
        public long HistoryOfDeliveryRequest1 { get; set; }
        public DateTime CreateAt { get; set; }
        public string Action { get; set; } = null!;
        public long DeliveryId { get; set; }
        public long UserIdUpdate { get; set; }
        public long? UserIdAutherized { get; set; }

        public virtual DeliveryRequest Delivery { get; set; } = null!;
        public virtual User? UserIdAutherizedNavigation { get; set; }
        public virtual User UserIdUpdateNavigation { get; set; } = null!;
    }
}
