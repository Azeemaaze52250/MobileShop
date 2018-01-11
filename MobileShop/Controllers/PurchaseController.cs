using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MobileShop.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace MobileShop.Controllers
{
    public class PurchaseController : Controller
    {
        MobileShopContext dbContext = null;

        public PurchaseController(MobileShopContext _deContext)
        {
            dbContext = _deContext;
        }

        public IActionResult Index()
        {
            return View(dbContext.Purchase.ToList<Purchase>());
        }

        [HttpGet]
        public IActionResult AddNewPurchase()
        {
            ViewData["vendor"] = new SelectList(dbContext.Vendors, "VendorCode", "VendorName");
            return View();
        }

        [HttpPost]
        public IActionResult AddNewPurchase(Purchase c)
        {
            c.Tdate = DateTime.Today.Date;
            dbContext.Purchase.Add(c);
            dbContext.SaveChanges();

            ViewData["Vendor"] = new SelectList(dbContext.Vendors, "VendorCode", "VendorName", c.VendorCode);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult DeletePurchase(Purchase c)
        {
            dbContext.Purchase.Remove(c);
            dbContext.SaveChanges();

            return RedirectToAction(nameof(Index));
        }

        public IActionResult EditPurchase(Purchase c)
        {
            dbContext.Purchase.Update(c);
            dbContext.SaveChanges();

            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public IActionResult PurchaseDetail(Purchase c)
        {
            // Purchase SinglePurchase = dbContext.Purchase.Where(abc => abc.PurchaseCode == c.PurchaseCode).FirstOrDefault<Purchase>();
            return View(dbContext.Purchase.Where(abc => abc.Id == c.Id).FirstOrDefault<Purchase>());
        }
    }
}