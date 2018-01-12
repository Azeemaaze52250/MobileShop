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
            IList<Products> plist = dbContext.Products.ToList();
            ViewBag.pl = plist;

            IList<Customers> clist = dbContext.Customers.ToList();
            ViewBag.cl = clist;

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
            Products p = dbContext.Products.Where(pp => pp.ProductCode == s.ProductCode).FirstOrDefault();
            Customers c = dbContext.Customers.Where(cc => cc.CustomerCode == s.CustomerCode).FirstOrDefault();

            if (s!=null)
            {
                if (p.Quantity==null || p.Quantity==0 || (p.Quantity<s.Quantity))
                {
                   
                    ViewBag.ErrorMessage = "Quantity is Greater Than Existing Stock";
                    return View();
                }
                p.Quantity = p.Quantity - s.Quantity;

                dbContext.Products.Update(p);

                dbContext.Sale.AddAsync(s);
                dbContext.SaveChanges();
            }

            string msgBody = "<p>Thanks From Your Visit " + c.CustomerName + " <br/> " +
               "Item=" + p.ProductName + " <br/> " +
               "Quantity =" + s.Quantity + " <br/> " +
               "Total Amount=" + s.LineTotal + " </p>";

            EmailSending ES = new EmailSending();
            ES.SendEmail("Sale on" + DateTime.Now, msgBody, c.Email);

            return RedirectToAction(nameof(Index));
        }
    }
}