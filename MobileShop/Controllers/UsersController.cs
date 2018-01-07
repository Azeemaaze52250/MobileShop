using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MobileShop.Models;

namespace MobileShop.Controllers
{
    public class UsersController : Controller
    {
        MobileShopContext dbContext = null;

        public UsersController(MobileShopContext _deContext)
        {
            dbContext = _deContext;
        }

        public IActionResult Index()
        {
            return View(dbContext.Users.ToList<Users>());
        }

        [HttpGet]
        public IActionResult AddNewUser()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddNewUser(Users c)
        {
            dbContext.Users.Add(c);
            dbContext.SaveChanges();

            return RedirectToAction(nameof(UserLogin));
        }

        public IActionResult DeleteUser(Users c)
        {
            dbContext.Users.Remove(c);
            dbContext.SaveChanges();

            return RedirectToAction(nameof(Index));
        }

        public IActionResult EditUser(Users c)
        {
            dbContext.Users.Update(c);
            dbContext.SaveChanges();

            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public IActionResult UserDetail(Users c)
        {

            return View(dbContext.Users.Where(abc => abc.UserId == c.UserId).FirstOrDefault<Users>());
        }

        [HttpGet]
        public IActionResult UserLogin()
        {
                        return View();
        }

        [HttpPost]
        public IActionResult UserLogin(Users c)
        {
            var v = dbContext.Users.Where(a => a.UserName.Equals(c.UserName) && a.Password.Equals(c.Password)).FirstOrDefault();
            if (v != null)
            {
                
                return RedirectToAction(nameof(Index), nameof(Products));

            }
            else
            {
                ViewBag.Message = "Please Enter Valid UserName or Password";
            }
            return View();
        }
    }
}