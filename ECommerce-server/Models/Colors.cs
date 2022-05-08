using System;
using System.Collections.Generic;

namespace ECommerce_App.Models
{
    public partial class Colors
    {
        public Colors()
        {
            Products = new HashSet<Products>();
        }

        public int ColorId { get; set; }
        public string Color { get; set; }
        public bool? Isactive { get; set; }

        public virtual ICollection<Products> Products { get; set; }
    }
}
