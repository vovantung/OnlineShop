using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineShop.Controllers
{
    public class MenuSiteHController : Controller
    {
        // GET: MenuSiteH
        public ActionResult Index()
        {
            return View();
        }

        public PartialViewResult MenuH(string menuActive)
        {
            ViewBag.menuActiveStr = menuActive;
            var model = new MenuModel().ListByGroupId(1);
            return PartialView(model);
           

        }
    }
}