using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MobileShop.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Hosting;
using System.IO;

namespace MobileShop.Controllers
{
    public class ProductsController : Controller
    {
        MobileShopContext dbContext = null;
        IHostingEnvironment env = null;

        public ProductsController(MobileShopContext _deContext,IHostingEnvironment _env)
        {
            dbContext = _deContext;
            env = _env;
        }

        public IActionResult Index()
        {
            return View(dbContext.Products.ToList<Products>());
        }

        [HttpGet]
        public IActionResult AddNewProduct()
        {
            ViewData["ProductCategory"] = new SelectList(dbContext.ProductCategory, "CategoryCode", "CategoryName");
            return View();
        }

        [HttpPost]
        public IActionResult AddNewProduct(Products c,IFormFile Image)
        {
            ViewData["ProductCategory"] = new SelectList(dbContext.ProductCategory, "CategoryCode", "CategoryName");
            
            c.Tdate = DateTime.Today.Date;
            string wwwrootPath = env.WebRootPath;
            string PPFolderPath = wwwrootPath + "/ProductImages/";

            string Name = Image.Name;
            string FileName = Image.FileName;
            long FileLength = Image.Length;

            string FileNameWithoutExtension = Path.GetFileNameWithoutExtension(FileName);
            Random r = new Random();

            FileNameWithoutExtension = DateTime.Now.ToString("ddMMyyyyhhmm") + r.Next(1, 1000).ToString();
            string Extension = Path.GetExtension(FileName);

            FileStream fs = new FileStream(PPFolderPath + FileNameWithoutExtension + Extension, FileMode.CreateNew);
            Image.CopyTo(fs);
            fs.Close();
            fs.Dispose();

            c.Image = "~/ProductImages/" + FileNameWithoutExtension + Extension;

            dbContext.Products.Add(c);
            dbContext.SaveChanges();

           
            return RedirectToAction(nameof(Index));

           
        }

        public IActionResult DeleteProduct(Products c)
        {
                        dbContext.Products.Remove(c);
            dbContext.SaveChanges();

            return RedirectToAction(nameof(Index));
        }

        public IActionResult EditProduct(int ProductCode)
        {
            //ViewData["ProductCategory"] = new SelectList(dbContext.ProductCategory, "CategoryCode", "CategoryName");
            IList<ProductCategory> pc = dbContext.ProductCategory.ToList();
            ViewBag.ProductCategory = pc;
            Products p = dbContext.Products.Where(pd => pd.ProductCode == ProductCode).FirstOrDefault();
            return View(p);
        }

        [HttpPost]
        public IActionResult EditProduct(Products c)
        {
            IList<ProductCategory> pc = dbContext.ProductCategory.ToList();
            ViewBag.ProductCategory = pc;
            //ViewData["ProductCategory"] = new SelectList(dbContext.ProductCategory, "CategoryCode", "CategoryName");

            Products p = dbContext.Products.Where(pd => pd.ProductCode == c.ProductCode).FirstOrDefault();

            if (p!=null)
            {
                p.ProductName = c.ProductName;
                p.CategoryCode = c.CategoryCode;
                p.Color = c.Color;
                p.Description = c.Description;
                p.Iemino = c.Iemino;
                p.ModelNo = c.ModelNo;
                p.Price = c.Price;
                p.SerialNo = c.SerialNo;

                dbContext.Products.Update(p);
                dbContext.SaveChanges();
            }

            

            return RedirectToAction(nameof(Index));
        }


        public IActionResult ProductDetail(Products c)
        {
           
            return View(dbContext.Products.Where(abc => abc.ProductCode == c.ProductCode).FirstOrDefault<Products>());
        }

        public int ProductSaleCountAjax(int ProductCode)
        {
            return dbContext.Products.Where(p => p.CategoryCode == ProductCode).Count();
        }

        public string ProductOutOfStockCheck(int ProductCode)
        {
            Products pd = dbContext.Products.Where(p => p.ProductCode == ProductCode).SingleOrDefault();

            if (pd.Quantity == 0 || pd.Quantity==null)
            {
                return "OutStock";
            }
            else
                return "";
        }
    }
}