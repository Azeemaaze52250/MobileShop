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
            dbContext.ProductCategory.Add(c);
            dbContext.SaveChanges();

            return RedirectToAction(nameof(Index));
        }

        public IActionResult DeleteProductCategory(ProductCategory c)
        {
            //IList < Products > p= dbContext.Products.Where(ab => ab.CategoryCode == c.CategoryCode).ToList<Products>(); ;

            
            //dbContext.Products.RemoveRange(p);
           
            dbContext.ProductCategory.Remove(c);
            dbContext.SaveChanges();

            return RedirectToAction(nameof(Index));
        }

        public IActionResult EditProductCategory(ProductCategory c)
        {
            dbContext.ProductCategory.Update(c);
            dbContext.SaveChanges();

            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public IActionResult ProductCategoryDetail(ProductCategory c)
        {
                       return View(dbContext.ProductCategory.Where(abc => abc.CategoryCode == c.CategoryCode).FirstOrDefault<ProductCategory>());
        }
    }
}