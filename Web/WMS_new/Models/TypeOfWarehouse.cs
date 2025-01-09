using System;
using System.Collections.Generic;

namespace WMS_new.Models
{
    public partial class TypeOfWarehouse
    {
        public TypeOfWarehouse()
        {
            Warehouses = new HashSet<Warehouse>();
        }

        public int TypeOfWarehouseId { get; set; }
        public string TypeOfWarehouseName { get; set; } = null!;

        public virtual ICollection<Warehouse> Warehouses { get; set; }
    }
}
