using System;
using System.Collections.Generic;

namespace ECommerce_App.Models
{
    public partial class Products
    {
        public Products()
        {
            Carts = new HashSet<Carts>();
            Orders = new HashSet<Orders>();
        }

        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public string ProductDescription { get; set; }
        public int? ProductCategoryId { get; set; }
        public int? ProductColorId { get; set; }
        public int? ProductSupplierId { get; set; }
        public string ProductImage { get; set; }
        public int? ProductPrice { get; set; }
        public int? UnitsInStock { get; set; }
        public bool? Discount { get; set; }
        public string DiscountDescription { get; set; }
        public string Reviews { get; set; }
        public bool? Isactive { get; set; }

        public virtual Categories ProductCategory { get; set; }
        public virtual Colors ProductColor { get; set; }
        public virtual Suppliers ProductSupplier { get; set; }
        public virtual ICollection<Carts> Carts { get; set; }
        public virtual ICollection<Orders> Orders { get; set; }
    }
}
