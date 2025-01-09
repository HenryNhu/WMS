using System;
using System.Collections.Generic;

namespace WMS_new.Models
{
    public partial class Verify
    {
        public int VerifyCode { get; set; }
        public long DeliveryId { get; set; }
        public long UserId { get; set; }

        public virtual DeliveryRequest Delivery { get; set; } = null!;
        public virtual User User { get; set; } = null!;
    }
}
