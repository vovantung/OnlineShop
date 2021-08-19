using Models;
using Models.Framework;
using OnlineShop.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Filters;

namespace OnlineShop.Areas.Admin.Controllers
{
    public class IsUserController : Controller
    {
        // GET: Admin/IsUser
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(Account user)
        {
            if (ModelState.IsValid)
            {
                user.Password = new Encsript().ToMD5(user.Password);
                var isUser = new AccountModel();
                var result = isUser.InsertUser(user);
                if (result == null)
                {
                    ModelState.AddModelError("", "Tạo tài khoản người dùng thất bại.");
                }
                else
                {
                    return RedirectToAction("Index", "Category");
                }

            }
            
            return View(user);
        }
    }
}