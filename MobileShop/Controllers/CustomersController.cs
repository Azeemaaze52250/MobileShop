using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MobileShop.Models;

namespace MobileShop.Controllers
{
    public class CustomersController : Controller
    {
        MobileShopContext dbContext = null;

        public CustomersController(MobileShopContext _deContext)
        {
            dbContext = _deContext;
        }

        public IActionResult Index()
        {
            return View(dbContext.Customers.ToList<Customers>());
        }

        [HttpGet]
        public IActionResult AddNewCustomer()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddNewCustomer(Customers c)
        {
            c.Tdate = DateTime.Now.Date;
            dbContext.Customers.Add(c);
            dbContext.SaveChanges();

            return RedirectToAction(nameof(Index));
        }

        public IActionResult DeleteCustomer(Customers c)
        {
            dbContext.Customers.Remove(c);
            dbContext.SaveChanges();

            return RedirectToAction(nameof(Index));
        }

        public IActionResult EditCustomer(int CustomerCode)
        {
           
            Customers c = dbContext.Customers.Where(db => db.CustomerCode == CustomerCode).FirstOrDefault();
            return View(c);
        }
        [HttpPost]
        public IActionResult EditCustomer(Customers c)
        {
            Customers cE = dbContext.Customers.Where(db => db.CustomerCode == c.CustomerCode).FirstOrDefault();
            cE.CustomerName = c.CustomerName;
            cE.City = c.City;
            cE.Area = c.Area;
            cE.Cnic = c.Cnic;
            cE.Street = c.Street;
            cE.Mobile = c.Mobile;

            dbContext.Customers.Update(cE);
            dbContext.SaveChanges();

            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public IActionResult CustomerDetail(Customers c)
        {
          
            return View(dbContext.Customers.Where(abc => abc.CustomerCode == c.CustomerCode).FirstOrDefault());
        }
    }
}