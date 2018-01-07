using System;
using System.Collections.Generic;

namespace MobileShop.Models
{
    public partial class Products
    {
        public Products()
        {
            Purchase = new HashSet<Purchase>();
            Sale = new HashSet<Sale>();
        }

        public int ProductCode { get; set; }
        public string ProductName { get; set; }
        public string Description { get; set; }
        public int? Price { get; set; }
        public string Image { get; set; }
        public string ModelNo { get; set; }
        public string SerialNo { get; set; }
        public string Iemino { get; set; }
        public string Color { get; set; }
        public int? CategoryCode { get; set; }

        public ProductCategory CategoryCodeNavigation { get; set; }
        public ICollection<Purchase> Purchase { get; set; }
        public ICollection<Sale> Sale { get; set; }
    }
}
