using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MobileShop.Models;

namespace MobileShop.Controllers
{
    public class VendorsController : Controller
    {
        MobileShopContext dbContext = null;

        public VendorsController(MobileShopContext _deContext)
        {
            dbContext = _deContext;
        }

        public IActionResult Index()
        {
            return View(dbContext.Vendors.ToList<Vendors>());
        }

        [HttpGet]
        public IActionResult AddNewVendor()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddNewVendor(Vendors c)
        {
            dbContext.Vendors.Add(c);
            dbContext.SaveChanges();

            return RedirectToAction(nameof(Index));
        }

        public IActionResult DeleteVendor(Vendors c)
        {
            dbContext.Vendors.Remove(c);
            dbContext.SaveChanges();

            return RedirectToAction(nameof(Index));
        }

        public IActionResult EditVendor(Vendors c)
        {
            dbContext.Vendors.Update(c);
            dbContext.SaveChanges();

            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public IActionResult VendorDetail(Vendors c)
        {
            // Vendors SingleVendor = dbContext.Vendors.Where(abc => abc.VendorCode == c.VendorCode).FirstOrDefault<Vendors>();
            return View(dbContext.Vendors.Where(abc => abc.VendorCode == c.VendorCode).FirstOrDefault<Vendors>());
        }
    }
}