using System;
using System.Collections.Generic;

namespace WMS_new.Models
{
    public partial class ImeiProduct
    {
        public ImeiProduct()
        {
            DeliveryRequests = new HashSet<DeliveryRequest>();
            HistoryOfImeiproducts = new HashSet<HistoryOfImeiproduct>();
        }

        public long Imei { get; set; }
        public string? Status { get; set; }
        public int ProductId { get; set; }
        public int WarehouseIdNow { get; set; }

        public virtual Product Product { get; set; } = null!;
        public virtual ICollection<DeliveryRequest> DeliveryRequests { get; set; }
        public virtual ICollection<HistoryOfImeiproduct> HistoryOfImeiproducts { get; set; }
    }
}
