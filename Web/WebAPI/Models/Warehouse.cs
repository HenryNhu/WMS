using System;
using System.Collections.Generic;

namespace WMS_new.Models
{
    public partial class Warehouse
    {
        public Warehouse()
        {
            CommitmentTimes = new HashSet<CommitmentTime>();
            DeliveryRequests = new HashSet<DeliveryRequest>();
            HistoryOfWarehouses = new HashSet<HistoryOfWarehouse>();
            Users = new HashSet<User>();
        }

        public int WarehouseId { get; set; }
        public string WarehouseName { get; set; } = null!;
        public string DetailedAddress { get; set; } = null!;
        public int Capacity { get; set; }
        public int CurrentStock { get; set; }
        public int WardId { get; set; }
        public int TypeOfWarehouseId { get; set; }
        public bool? IsActive { get; set; }

        public virtual TypeOfWarehouse TypeOfWarehouse { get; set; } = null!;
        public virtual Ward Ward { get; set; } = null!;
        public virtual ICollection<CommitmentTime> CommitmentTimes { get; set; }
        public virtual ICollection<DeliveryRequest> DeliveryRequests { get; set; }
        public virtual ICollection<HistoryOfWarehouse> HistoryOfWarehouses { get; set; }
        public virtual ICollection<User> Users { get; set; }
    }
}
