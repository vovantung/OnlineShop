using Models;
using Models.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineShop.Areas.Admin.Controllers
{
    public class ListAccountController : Controller
    {
        // GET: Admin/ListAccount
        public ActionResult Index( string searchString, int page = 1, int pagesize = 3)
        {
            var lAccount = new AccountModel();

            return View(lAccount.ListAccountPagiing(searchString, page, pagesize));
        }
        [HttpPost]
        public  ActionResult Edit(Account user)
        {
            var userE = new AccountModel();
            var result = userE.EditAccount(user);
            if (result)
            {
                ModelState.AddModelError("", "Cập nhật thông tin người dùng không thành công!");
                return View(user);

            }
            else
            {
                RedirectToAction("Index", "ListAccount");
                return null;

            }


        }

    }
}