using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MobileShop.Models;
using Microsoft.AspNetCore.Http;

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
            c.Tdate = DateTime.Today.Date;
            dbContext.Users.Add(c);
            dbContext.SaveChanges();

            string msgBody = "<p>New User Created by User Id <br/>" + c.UserName + "</p>";

            EmailSending ES = new EmailSending();
            ES.SendEmail("New User Creation Confirmation",msgBody,c.UserName);

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
                //MyGlobalVariables mgv = new MyGlobalVariables();
                HttpContext.Session.SetString("currentUserID",v.UserId.ToString());
                HttpContext.Session.SetString("currentUserName", v.UserName);
                HttpContext.Session.SetString("currentUserRole", v.UserRole);


                ViewData["currentUserID"] = HttpContext.Session.GetString("currentUserID");
                ViewData["currentUserName"] = HttpContext.Session.GetString("currentUserName");
                ViewData["currentUserRole"] = HttpContext.Session.GetString("currentUserRole");

                return RedirectToAction(nameof(Index), "Home");

            }
            else
            {
                ViewBag.Message = "Please Enter Valid UserName or Password";
            }
            return View();
        }

        public IActionResult LogOut()
        {


            HttpContext.Session.SetString("currentUserID", "");
            HttpContext.Session.SetString("currentUserName", "");
            HttpContext.Session.SetString("currentUserRole", "");


            ViewData["currentUserID"] = HttpContext.Session.GetString("currentUserID");
            ViewData["currentUserName"] = HttpContext.Session.GetString("currentUserName");
            ViewData["currentUserRole"] = HttpContext.Session.GetString("currentUserRole");

            return RedirectToAction(nameof(UserLogin), "Users");
                       
        }
    }
}