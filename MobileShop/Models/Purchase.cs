﻿using System;
using System.Collections.Generic;

namespace MobileShop.Models
{
    public partial class Purchase
    {
        public int Id { get; set; }
        public DateTime? Tdate { get; set; }
        public int? ProductCode { get; set; }
        public int? Quantity { get; set; }
        public int? UnitPrice { get; set; }
        public int? LineTotal { get; set; }
        public int? VendorCode { get; set; }

        public Products ProductCodeNavigation { get; set; }
        public Vendors VendorCodeNavigation { get; set; }
    }
}
