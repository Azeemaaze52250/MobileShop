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

        public IActionResult EditCustomer(Customers c)
        {
            dbContext.Customers.Update(c);
            dbContext.SaveChanges();

            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public IActionResult CustomerDetail(Customers c)
        {
          
            return View(dbContext.Customers.Where(abc => abc.CustomerCode == c.CustomerCode).FirstOrDefault<Customers>());
        }
    }
}