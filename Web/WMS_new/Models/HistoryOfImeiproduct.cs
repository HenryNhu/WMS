using System;
using System.Collections.Generic;

namespace WMS_new.Models
{
    public partial class HistoryOfImeiproduct
    {
        public long HistoryOfImeiproductId { get; set; }
        public DateTime CreateAt { get; set; }
        public string Action { get; set; } = null!;
        public int? WarehouseIdUpdate { get; set; }
        public long Imei { get; set; }
        public long UserId { get; set; }

        public virtual ImeiProduct ImeiNavigation { get; set; } = null!;
        public virtual User User { get; set; } = null!;
    }
}
