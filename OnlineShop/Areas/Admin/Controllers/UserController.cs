using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Models;
using Models.Framework;
using OnlineShop.Common;
using BotDetect.Web.Mvc;


namespace OnlineShop.Areas.Admin.Controllers
{
    public class UserController : Controller
    {
       

        [HttpGet]
        public ActionResult Register()
        {
            return View();
        }
        [HttpPost]
        [CaptchaValidationActionFilter("CaptchaCode", "IRegisterCaptcha", "Wrong Captcha!")]
        public ActionResult Register(Account user)
        {
            if (ModelState.IsValid)
            {
                user.Password = new md5().Encrypt(user.Password, "TX");
                var isUser = new AccountModel();
                var result = isUser.InsertUser(user);
                if (result == null)
                {
                    ModelState.AddModelError("", "Tạo tài khoản người dùng thất bại.");
                }
                else
                {
                    return RedirectToAction("Index", "User");
                }

            }

            return View(user);
        }


        [HttpPost]
        public JsonResult ChangStatus(int id)
        {
            var result = new AccountModel().ChangStatus(id);
            return Json(new
            {
                status = result
            });
           

        }
        // GET: Admin/User
        public ActionResult Index(string searchString, int  page = 1, int pagesize  = 5)
        {
            var user = new AccountModel();
            ViewBag.searchStr = searchString;

            return View(user.ListAccountPagiing(searchString, page, pagesize));
           
        }

        // GET: Admin/User/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Admin/User/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/User/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Admin/User/Edit/5
        public ActionResult Edit(int id)
        {
            var user = new AccountModel();
            return View( user.getUserbyID(id));
        }

        // POST: Admin/User/Edit/5
        [HttpPost]
        public ActionResult Edit(Account user)
        {

            var userE = new AccountModel();
            var result = userE.EditAccount(user);
            if (result == false)
            {
                ModelState.AddModelError("", "Cập nhật thông tin người dùng không thành công!");
                return View(user);

            }
            else
            {
               return RedirectToAction("Index", "User");
                
            }

          
        }

        // GET: Admin/User/Delete/5
        [HttpDelete]
        public ActionResult Delete(int id)
        {
           var dao = new AccountModel();
           var result =  dao.DeleteUser(id);
           return RedirectToAction("Index");
          
        }

        // POST: Admin/User/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
