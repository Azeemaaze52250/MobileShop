using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MobileShop.Models;
using System.Collections;

namespace MobileShop.Controllers
{
    public class ProductCategoryController : Controller
    {
        MobileShopContext dbContext = null;

        public ProductCategoryController(MobileShopContext _deContext)
        {
            dbContext = _deContext;
        }

        public IActionResult Index()
        {
            return View(dbContext.ProductCategory.ToList<ProductCategory>());
        }

        [HttpGet]
        public IActionResult AddNewProductCategory()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddNewProductCategory(ProductCategory c)
        {
            c.Tdate = DateTime.Today.Date;

            if (dbContext.ProductCategory.Where(pc=>pc.CategoryName==c.CategoryName).Count()>0)
            {
                ViewBag.CategoryAlreadyExist = "Category Already Exist";
                return View();
            }

            dbContext.ProductCategory.Add(c);
            dbContext.SaveChanges();

            return RedirectToAction(nameof(Index));
        }

        public int CategoryCountAjax(int CategoryCode)
        {
            return dbContext.Products.Where(p => p.CategoryCode == CategoryCode).Count();
        }

        public IActionResult DeleteProductCategory(ProductCategory c)
        {
            //IList < Products > p= dbContext.Products.Where(ab => ab.CategoryCode == c.CategoryCode).ToList<Products>(); ;

            
            //dbContext.Products.RemoveRange(p);
           
            dbContext.ProductCategory.Remove(c);
            dbContext.SaveChanges();

            return RedirectToAction(nameof(Index));
        }

        public IActionResult EditProductCategory(int CategoryCode)
        {
            ProductCategory pc = dbContext.ProductCategory.Where(p => p.CategoryCode == CategoryCode).SingleOrDefault();

            if (pc != null)
            {
                return View(pc);
            }


            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public IActionResult EditProductCategory(ProductCategory c)
        {
            ProductCategory pc = dbContext.ProductCategory.Where(p => p.CategoryCode == c.CategoryCode).SingleOrDefault();

            if (pc != null)
            {
                pc.CategoryName = c.CategoryName;

                dbContext.Update(pc);
                dbContext.SaveChanges();
            }
           

            return RedirectToAction(nameof(Index));
        }

       
        public IActionResult ProductCategoryDetail(ProductCategory c)
        {
                       return View(dbContext.ProductCategory.Where(abc => abc.CategoryCode == c.CategoryCode).FirstOrDefault<ProductCategory>());
        }
    }
}