using System;
using System.Collections.Generic;

namespace WMS_new.Models
{
    public partial class HistoryOfWarehouse
    {
        public long HistoryOfWarehouseId { get; set; }
        public DateTime CreateAt { get; set; }
        public string Action { get; set; } = null!;
        public long UserId { get; set; }
        public int WarehouseId { get; set; }

        public virtual User User { get; set; } = null!;
        public virtual Warehouse Warehouse { get; set; } = null!;
    }
}
