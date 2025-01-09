using System;
using System.Collections.Generic;

namespace WMS_new.Models
{
    public partial class TypeOfProduct
    {
        public TypeOfProduct()
        {
            Products = new HashSet<Product>();
        }

        public int TypeOfProductId { get; set; }
        public string ProductName { get; set; } = null!;
        public int CurrentStock { get; set; }

        public virtual ICollection<Product> Products { get; set; }
    }
}
