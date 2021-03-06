using System;
using System.Collections.Generic;

namespace ECommerce_App.Models
{
    public partial class Carts
    {
        public int CartId { get; set; }
        public int? ProductId { get; set; }
        public int? CustomerId { get; set; }
        public decimal? TotalPrice { get; set; }

        public virtual Customers Customer { get; set; }
        public virtual Products Product { get; set; }
    }
}
