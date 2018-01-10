using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MobileShop.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace MobileShop.Controllers
{
    public class SaleController : Controller
    {
        MobileShopContext dbContext = null;

        public SaleController(MobileShopContext _deContext)
        {
            dbContext = _deContext;
        }

        public IActionResult Index()
        {
            return View(dbContext.Sale.ToList<Sale>());
        }

        [HttpGet]
        public IActionResult AddNewSale()
        {
            ViewBag["Customer"] = new SelectList(dbContext.Customers, "CustomerCode", "CustomerName");
            return View();
        }

        [HttpPost]
        public IActionResult AddNewSale(Sale c)
        {
            c.Tdate = DateTime.Today.Date;
            dbContext.Sale.Add(c);
            dbContext.SaveChanges();

            ViewBag["Customer"] = new SelectList(dbContext.Customers, "CustomerCode", "CustomerName", c.CustomerCode);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult DeleteSale(Sale c)
        {
            dbContext.Sale.Remove(c);
            dbContext.SaveChanges();

            return RedirectToAction(nameof(Index));
        }

        public IActionResult EditSale(Sale c)
        {
            dbContext.Sale.Update(c);
            dbContext.SaveChanges();

            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public IActionResult SaleDetail(Sale c)
        {
            // Sale SingleSale = dbContext.Sale.Where(abc => abc.SaleCode == c.SaleCode).FirstOrDefault<Sale>();
            return View(dbContext.Sale.Where(abc => abc.Id == c.Id).FirstOrDefault<Sale>());
        }
    }
}