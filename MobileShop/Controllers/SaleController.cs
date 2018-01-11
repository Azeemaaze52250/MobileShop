using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MobileShop.Models;

namespace MobileShop.Controllers
{
    public class SaleController : Controller
    {
        MobileShopContext dbContext;

       public SaleController(MobileShopContext _dbContext)
        {
            dbContext = _dbContext;
        }

        public IActionResult Index()
        {

            return View(dbContext.Sale.ToList());
        }

        public IActionResult AddNewSale()
        {
            IList<Products> plist = dbContext.Products.ToList();
            ViewBag.pl = plist;

            IList<Customers> clist = dbContext.Customers.ToList();
            ViewBag.cl = clist;

            return View();
        }

        [HttpPost]
        public IActionResult AddNewSale(Sale s)
        {
            //IList<Products> plist = dbContext.Products.ToList();
            //ViewBag.pl = plist;

            //IList<Customers> clist = dbContext.Customers.ToList();
            //ViewBag.cl = clist;

            if (s!=null)
            {
                dbContext.Sale.Add(s);
                dbContext.SaveChanges();
            }
           
            return RedirectToAction(nameof(Index));
        }
    }
}