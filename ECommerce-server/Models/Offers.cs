using System;
using System.Collections.Generic;

namespace ECommerce_App.Models
{
    public partial class Offers
    {
        public int Offerid { get; set; }
        public string Offerimage { get; set; }
        public bool? Isactive { get; set; }
    }
}
