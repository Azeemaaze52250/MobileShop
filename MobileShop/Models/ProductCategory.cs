using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace MobileShop.Models
{
    public partial class ProductCategory
    {
        public ProductCategory()
        {
            Products = new HashSet<Products>();
        }

        public int CategoryCode { get; set; }
        [DisplayName("Category Name")]
        [Required]
        [MaxLength(50)]
        public string CategoryName { get; set; }

        public ICollection<Products> Products { get; set; }
    }
}
