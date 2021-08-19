using Models;
using OnlineShop.Areas.Admin.Code;
using OnlineShop.Areas.Admin.Models;
using OnlineShop.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Facebook;


namespace OnlineShop.Areas.Admin.Controllers
{
    public class LoginController : Controller
    {
        public string USER_SESSION { get; private set; }
        public ActionResult LoginFacebook()
        {
            var fb = new FacebookClient();
            var loginUrl = fb.GetLoginUrl(new { });

            return View();
        }

        // GET: Admin/Login
        [HttpGet]
        public ActionResult Index()
        {
            return View();
            
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(LoginModel model)

        {
            
           
            
            
            if (ModelState.IsValid){
                var result = new AccountModel().Login(model.Username, new md5().Encrypt(model.Password,"TX"));
                if (result == 0)
                {
                    ModelState.AddModelError("", "Tài khoản không tồn tại.");
                }
                else if(result == -1)
                {
                    ModelState.AddModelError("", "Tài khoản đang bị khóa.");

                }
                else if (result == -2)
                {
                    ModelState.AddModelError("", "Mật khẩu không đúng.");

                }
                else if (result == 1)
                {
                    var user = new AccountModel().GetUserIDbyUsername(model.Username);
                    var userSession = new UserLogin();
                    userSession.UserID = user.UserID;
                    userSession.UserName = user.Username;
                    Session.Add(CommonConstant.USER_SESSSION, userSession);
                    //SessionHelper.SetSession(new UserSession(){ Username = model.Username });
                    return RedirectToAction("Index", "User");

                } 
            } 
            return View(model);
        }
    }
}