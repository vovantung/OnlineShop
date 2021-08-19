using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Models;
using Models.Framework;

namespace OnlineShop.Areas.Admin.Controllers
{
    public class MainMenuController : Controller
    {
        // GET: Admin/MainMenu
        public ActionResult Index()
        {
            var model = new MenuModel().ListByGroupId(1);
            return PartialView(model);
           
        }
        
       
    }
}