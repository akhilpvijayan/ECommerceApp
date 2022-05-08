using System;
using System.Collections.Generic;

namespace ECommerce_App.Models
{
    public partial class Categories
    {
        public Categories()
        {
            Products = new HashSet<Products>();
        }

        public int CategoryId { get; set; }
        public string Category { get; set; }
        public bool? Isactive { get; set; }

        public virtual ICollection<Products> Products { get; set; }
    }
}
