using System;
using System.Collections.Generic;

namespace WMS_new.Models
{
    public partial class Product
    {
        public Product()
        {
            ImeiProducts = new HashSet<ImeiProduct>();
        }

        public int ProductId { get; set; }
        public string ProductName { get; set; } = null!;
        public int CurrentStock { get; set; }
        public int TypeOfProductId { get; set; }

        public virtual TypeOfProduct TypeOfProduct { get; set; } = null!;
        public virtual ICollection<ImeiProduct> ImeiProducts { get; set; }
    }
}
