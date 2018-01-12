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
            IList<Products> plist = dbContext.Products.ToList();
            ViewBag.pl = plist;

            IList<Vendors> clist = dbContext.Vendors.ToList();
            ViewBag.cl = clist;

            return View();
        }

        [HttpPost]
        public IActionResult AddNewPurchase(Purchase c)
        {
            c.Tdate = DateTime.Today.Date;

            Products p = dbContext.Products.Where(pp => pp.ProductCode == c.ProductCode).FirstOrDefault();
            Vendors v = dbContext.Vendors.Where(cc => cc.VendorCode == c.VendorCode).FirstOrDefault();


            if (p.Quantity==null)
            {
                p.Quantity = 0;
            }


            p.Quantity = p.Quantity + c.Quantity;

            dbContext.Products.Update(p);
            dbContext.Purchase.AddAsync(c);
            dbContext.SaveChanges();

           

            string msgBody = "<p>New Purchase From " + v + " <br/> " +
                "Item=" + c.ProductCodeNavigation.ProductName +" <br/> " +
                "Quantity =" + c.Quantity + " <br/> " +
                "Total Amount="+ c.LineTotal +" </p>";

            EmailSending ES = new EmailSending();
            ES.SendEmail("New Purchase on" + DateTime.Now, msgBody, "");

            return RedirectToAction(nameof(Index));
        }

        public IActionResult DeletePurchase(Purchase c)
        {
            dbContext.Purchase.Remove(c);
            dbContext.SaveChanges();

            return RedirectToAction(nameof(Index));
        }

        //public IActionResult EditPurchase(Purchase c)
        //{
        //    dbContext.Purchase.Update(c);
        //    dbContext.SaveChanges();

        //    return RedirectToAction(nameof(Index));
        //}

        [HttpPost]
        public IActionResult PurchaseDetail(Purchase c)
        {
            // Purchase SinglePurchase = dbContext.Purchase.Where(abc => abc.PurchaseCode == c.PurchaseCode).FirstOrDefault<Purchase>();
            return View(dbContext.Purchase.Where(abc => abc.Id == c.Id).FirstOrDefault<Purchase>());
        }
    }
}