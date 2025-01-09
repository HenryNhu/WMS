using System;
using System.Collections.Generic;

namespace WMS_new.Models
{
    public partial class User
    {
        public User()
        {
            HistoryOfDeliveryRequestUserIdAutherizedNavigations = new HashSet<HistoryOfDeliveryRequest>();
            HistoryOfDeliveryRequestUserIdUpdateNavigations = new HashSet<HistoryOfDeliveryRequest>();
            HistoryOfImeiproducts = new HashSet<HistoryOfImeiproduct>();
            HistoryOfWarehouses = new HashSet<HistoryOfWarehouse>();
            Verifies = new HashSet<Verify>();
        }

        public long UserId { get; set; }
        public string? Password { get; set; }
        public string FullName { get; set; } = null!;
        public DateTime DateOfBirth { get; set; }
        public string PhoneNumber { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string? Avatar { get; set; }
        public bool IsActive { get; set; }
        public int? WarehouseIdWork { get; set; }

        public virtual Warehouse? WarehouseIdWorkNavigation { get; set; }
        public virtual ICollection<HistoryOfDeliveryRequest> HistoryOfDeliveryRequestUserIdAutherizedNavigations { get; set; }
        public virtual ICollection<HistoryOfDeliveryRequest> HistoryOfDeliveryRequestUserIdUpdateNavigations { get; set; }
        public virtual ICollection<HistoryOfImeiproduct> HistoryOfImeiproducts { get; set; }
        public virtual ICollection<HistoryOfWarehouse> HistoryOfWarehouses { get; set; }
        public virtual ICollection<Verify> Verifies { get; set; }
    }
}
