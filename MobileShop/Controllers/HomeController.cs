using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MobileShop.Models;

namespace MobileShop.Controllers
{
    public class HomeController : Controller
    {
        MobileShopContext dbContext = null;
        public HomeController(MobileShopContext _dbContext)
        {
            dbContext = _dbContext;
        }

        public IActionResult Index()
        {
            return View();
        }

        public int UserCount()
        {            
              return dbContext.Users.Count();
                   }

        public int CustomerCount()
        {
           
                return dbContext.Customers.Count();
           
        }

        public int VendorCount()
        {
            return dbContext.Vendors.Count();
        }

        public int CategoryCount()
        {
            return dbContext.ProductCategory.Count();
           
        }

        public int ItemCountCount()
        {
            return dbContext.Products.Count();
            
        }

    }
}
