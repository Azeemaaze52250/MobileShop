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

        public int ItemCount()
        {
            return dbContext.Products.Count();
            
        }

        public int SaleCount()
        {
            return dbContext.Sale.Count();

        }

        public int PurchaseCount()
        {
            return dbContext.Purchase.Count();

        }
//*********************************************************
        public int UserAdded()
        {
            try
            {
                int? dNumber = dbContext.Users.Where(db => db.Tdate >= DateTime.Now.AddDays(-3)).Count();
                return (int)dNumber;
            }
            catch
            {
                return 0;
            }

        }

        public int AdminAdded()
        {
            try
            {
                int? dNumber = dbContext.Users.Where(db =>db.UserRole=="Admin" && db.Tdate >= DateTime.Now.AddDays(-3)).Count();
                return (int)dNumber;
            }
            catch
            {
                return 0;
            }

        }

        public int StaffAdded()
        {
            try
            {
                int? dNumber = dbContext.Users.Where(db => db.UserRole == "Staff" && db.Tdate >= DateTime.Now.AddDays(-3)).Count();
                return (int)dNumber;
            }
            catch
            {
                return 0;
            }

        }

        public int CategoryAdded()
        {
            try
            {
                int? dNumber = dbContext.ProductCategory.Where(db => db.Tdate >= DateTime.Now.AddDays(-3)).Count();
                return (int)dNumber;
            }
            catch
            {
                return 0;
            }

        }

        public string LastAddedCategory()
        {
            try
            {
                int? dNumber = dbContext.ProductCategory.Where(db => db.Tdate >= DateTime.Now.AddDays(-3)).Max(u => (int?)u.CategoryCode);
                ProductCategory catName = dbContext.ProductCategory.Where(db => db.CategoryCode == (int)dNumber).SingleOrDefault();
                return catName.CategoryName;
            }
            catch
            {
                return "Nill";
            }

        }

        public int CategoryWithoutItem()
        {
            return dbContext.Purchase.Count();

        }

        public int ProductAdded()
        {
            return dbContext.Purchase.Count();

        }

        public int LastAddedProduct()
        {
            return dbContext.Purchase.Count();

        }

        public int MostExpensiveProduct()
        {
            return dbContext.Purchase.Count();

        }

        public int CustomerAdded()
        {
            return dbContext.Purchase.Count();

        }

        public int LastAddedCustomer()
        {
            return dbContext.Purchase.Count();

        }

        public int MostVisited()
        {
            return dbContext.Purchase.Count();

        }

        public int VendorsAdded()
        {
            return dbContext.Purchase.Count();

        }

        public int LastAddedVendor()
        {
            //***********
            return dbContext.Purchase.Count();

        }

        public int MostPurchasedForm()
        {
            //********
            return dbContext.Purchase.Count();

        }

        public int TotalNoOfSales()
        {
            try
            {
                int? dNumber = dbContext.Sale.Where(db => db.Tdate >= DateTime.Now.AddDays(-3)).Count();
                return (int)dNumber;
            }
            catch
            {
                return 0;
            }

        }

        public int MaximumSingleSale()
        {
            try
            {
                int? dNumber = dbContext.Sale.Where(db => db.Tdate >= DateTime.Now.AddDays(-3)).Max(u => (int?)u.LineTotal);
                return (int)dNumber;
            }
            catch
            {
                return 0;
            }

        }

        public int MinimumSingleSale()
        {
            try
            {
                int? dNumber = dbContext.Sale.Where(db => db.Tdate >= DateTime.Now.AddDays(-3)).Min(u => (int?)u.LineTotal);
                return (int)dNumber;
            }
            catch
            {
                return 0;
            }

        }

        public int TotalNoOfPurchases()
        {
            try
            {
                int? dNumber = dbContext.Purchase.Where(db => db.Tdate >= DateTime.Now.AddDays(-3)).Count();
                return (int)dNumber;
            }
            catch
            {
                return 0;
            }

        }

        public int MinimumSinglePurchase()
        {
            try
            {
                int? dNumber = dbContext.Purchase.Where(db => db.Tdate >= DateTime.Now.AddDays(-3)).Min(u => (int?)u.LineTotal);
                return (int)dNumber;
            }
            catch
            {
                return 0;
            }

        }

        public int MaximumSinglePurchase()
        {
            try
            {
                int? dNumber = dbContext.Purchase.Where(db => db.Tdate >= DateTime.Now.AddDays(-3)).Max(u => (int?)u.LineTotal);
                return (int)dNumber;
            }
            catch
            {
                return 0;
            }
         
        }
    }
}
