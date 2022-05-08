using System;
using System.Collections.Generic;

namespace ECommerce_App.Models
{
    public partial class Suppliers
    {
        public Suppliers()
        {
            Products = new HashSet<Products>();
        }

        public int SupplierId { get; set; }
        public string SupplierName { get; set; }
        public string SupplierAddress { get; set; }
        public string Country { get; set; }
        public decimal? Contact { get; set; }

        public virtual ICollection<Products> Products { get; set; }
    }
}
