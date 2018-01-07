using System;
using System.Collections.Generic;

namespace MobileShop.Models
{
    public partial class ProductCategory
    {
        public ProductCategory()
        {
            Products = new HashSet<Products>();
        }

        public int CategoryCode { get; set; }
        public string CategoryName { get; set; }

        public ICollection<Products> Products { get; set; }
    }
}
