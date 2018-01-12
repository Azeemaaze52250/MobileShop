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
            IList<Products> plist = dbContext.Products.ToList();
            ViewBag.pl = plist;

            IList<Vendors> clist = dbContext.Vendors.ToList();
            ViewBag.cl = clist;

            return View(dbContext.Vendors.ToList<Vendors>());
        }

        [HttpGet]
        public IActionResult AddNewVendor()
        {
            IList<Products> plist = dbContext.Products.ToList();
            ViewBag.pl = plist;

            IList<Vendors> clist = dbContext.Vendors.ToList();
            ViewBag.cl = clist;

            return View();
        }

        [HttpPost]
        public IActionResult AddNewVendor(Vendors c)
        {
            c.Tdate = DateTime.Today.Date;
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

        public IActionResult EditVendoer(int VendoerCode)
        {

            Vendors c = dbContext.Vendors.Where(db => db.VendorCode == VendoerCode).FirstOrDefault();
            return View(c);
        }
        [HttpPost]
        public IActionResult EditVendoer(Vendors c)
        {
            Vendors cE = dbContext.Vendors.Where(db => db.VendorCode == c.VendorCode).FirstOrDefault();
            cE.VendorName = c.VendorName;
            cE.Area = c.Area;
            cE.Cnic = c.Cnic;
            
            cE.Mobile = c.Mobile;

            dbContext.Vendors.Update(cE);
            dbContext.SaveChanges();

            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public IActionResult VendorDetail(Vendors c)
        {
            // Vendors SingleVendor = dbContext.Vendors.Where(abc => abc.VendorCode == c.VendorCode).FirstOrDefault<Vendors>();
            return View(dbContext.Vendors.Where(abc => abc.VendorCode == c.VendorCode).FirstOrDefault<Vendors>());
        }

        public string VendorStar(int VendorCode)
        {
            Purchase pd = dbContext.Purchase.Where(p => p.VendorCode == VendorCode && p.Tdate >= DateTime.Now.AddDays(-30)).SingleOrDefault();

            if (pd != null)
            {
                return "star";
            }
            else
                return "";
        }
    }
}