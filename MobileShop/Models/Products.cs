using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

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
        [DisplayName("Product Name")]
        [Required]
        [MaxLength(50)]
        public string ProductName { get; set; }
        public string Description { get; set; }
        
        [Required]
        public int? Price { get; set; }
        public string Image { get; set; }
        public string ModelNo { get; set; }
        public string SerialNo { get; set; }

        [DisplayName("IEMI No")]        
        public string Iemino { get; set; }
        public string Color { get; set; }

        [Required]
        [DisplayName("Category")]
        public int? CategoryCode { get; set; }

        public DateTime? Tdate { get; set; }

        public ProductCategory CategoryCodeNavigation { get; set; }
        public ICollection<Purchase> Purchase { get; set; }
        public ICollection<Sale> Sale { get; set; }
    }
}
