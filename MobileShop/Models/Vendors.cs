using System;
using System.Collections.Generic;

namespace MobileShop.Models
{
    public partial class Vendors
    {
        

        public int VendorCode { get; set; }
        public string VendorName { get; set; }
        public string Area { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string Mobile { get; set; }
        public string Cnic { get; set; }

        public Vendors VendorCodeNavigation { get; set; }
        public Products ProductCodeNavigation { get; set; }
        public IEnumerable<Purchase> Purchase { get; internal set; }
    }
}
