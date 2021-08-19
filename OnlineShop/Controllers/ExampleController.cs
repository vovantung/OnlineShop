using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Models;

namespace OnlineShop.Controllers
{
    public class ExampleController : Controller
    {
        // GET: Example
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Dictionary()
        {
            return View();
        }
        public JsonResult Translation(string word)
        {
            
            var ret = new Translate().Trans(word);
            
            return Json(new
            {
                toword_trans = ret

            });



        }

    }
}