using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace MobileShop.Models
{
    public partial class Vendors
    {
        

        public int VendorCode { get; set; }
        [Required]
        [MaxLength(50)]
        [DisplayName("Vendor Name")]
        public string VendorName { get; set; }
        public string Area { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string Mobile { get; set; }
        [DisplayName("CNIC")]
        public string Cnic { get; set; }
        public DateTime? Tdate { get; set; }


        //public Vendors VendorCodeNavigation { get; set; }
        //public Products ProductCodeNavigation { get; set; }
        //public IEnumerable<Purchase> Purchase { get; internal set; }

        public ICollection<Purchase> Purchase { get; set; }
    }
}
