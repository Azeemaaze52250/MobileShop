using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace MobileShop.Models
{
    public partial class Customers
    {
        public Customers()
        {
            Sale = new HashSet<Sale>();
        }

        public int CustomerCode { get; set; }

        [Required]
        [StringLength(50)]
        [DisplayName("Customer Name")]    
        public string CustomerName { get; set; }
        public DateTime? Tdate { get; set; }
        public string Mobile { get; set; }
        public string Cnic { get; set; }
        public string Street { get; set; }
        public string Area { get; set; }
        public string City { get; set; }
        public string Country { get; set; }

        public ICollection<Sale> Sale { get; set; }
    }
}
