using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace MobileShop.Models
{
    public partial class Sale
    {
        public int Id { get; set; }
        [DisplayName("Date")]
        [Required]
        [DataType(DataType.Date)]
        public DateTime? Tdate { get; set; }

        [DisplayName("Product")]
        [Required]
        public int? ProductCode { get; set; }

        [Required]
        public int? Quantity { get; set; }

        [Required]
        public int? UnitPrice { get; set; }

        public int? LineTotal { get; set; }

        [DisplayName("Customer")]
        [Required]
        public int? CustomerCode { get; set; }

        public Customers CustomerCodeNavigation { get; set; }
        public Products ProductCodeNavigation { get; set; }
    }
}
