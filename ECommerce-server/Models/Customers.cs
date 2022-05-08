using System;
using System.Collections.Generic;

namespace ECommerce_App.Models
{
    public partial class Customers
    {
        public Customers()
        {
            Carts = new HashSet<Carts>();
            Orders = new HashSet<Orders>();
        }

        public int CustomerId { get; set; }
        public string CustomerName { get; set; }
        public string CustomerAddress { get; set; }
        public decimal? CustomerContact { get; set; }
        public int? CustomerPostalcode { get; set; }
        public string CustomerUsername { get; set; }
        public string CustomerPassword { get; set; }
        public bool? CustomerRole { get; set; }
        public bool? Isactive { get; set; }

        public virtual ICollection<Carts> Carts { get; set; }
        public virtual ICollection<Orders> Orders { get; set; }
    }
}
