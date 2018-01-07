using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace MobileShop.Models
{
    public partial class Purchase
    {
        public int Id { get; set; }
        public DateTime? Tdate { get; set; }

        [DisplayName("Product")]
        [Required]
        public int? ProductCode { get; set; }

        [Required]
        public int? Quantity { get; set; }

        [Required]
        public int? UnitPrice { get; set; }
        public int? LineTotal { get; set; }

        [Required]
        public int? VendorCode { get; set; }

        public Products ProductCodeNavigation { get; set; }
        public Vendors VendorCodeNavigation { get; set; }
    }
}
