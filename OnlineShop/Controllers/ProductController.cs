using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Common1;
using Models;



namespace OnlineShop.Controllers
{
    public class ProductController : Controller
    {
        //public  ActionResult testMail()
        //{
        //    new MailHelper().SendMail("Nhan de mai", "Đây lf nội dung mail", "vovantungdt123@gmail.com");
        //    return View();
        //}

        [HttpGet]
        public ActionResult Index(string ProductTypeID, string searchString, int page = 1, int pagesize = 5)
        {
            ViewBag.searchStr = searchString;
            ViewBag.ProductTypeID = ProductTypeID;
            var model = new ProductModel().ListProdctPagiing(ProductTypeID, searchString, page, pagesize);
            return View(model);
        }

        //[HttpPost]
        //public ActionResult Index(string PrID, string searchString, int page = 1, int pagesize = 5)
        //{
        //    ViewBag.searchStr = searchString;
        //    ViewBag.ProductTypeID = "more";

        //    var model = new ProductModel().ListProdctPagiing(PrID, searchString, page, pagesize);
        //    return View(model);
        //}
        public ActionResult Details()
        {
            var model = new ProductModel().getProductbyMetaTitle(HttpContext.Request.Url.AbsolutePath.ToString());
            ViewBag.product = model;

            return View();
        }

        public ActionResult Ecommerce_checkout()
        {
            
            if (Session["EcomCart"] != null)
            {
                string[,] ecomCart = (string[,])Session["EcomCart"];
                ViewBag.eC = ecomCart;
            }
            return View();
        }

        public JsonResult Ecom_cart(string id)
        {
            try {

                var session = (string[,])Session["EcomCart"];
                string[,] ecomCart;
                if (session != null)
                {
                    for (int i = 0; i < session.Length/2; i++)
                    {
                        if(session[i,0] == id)
                        {
                            session[i, 1] = (int.Parse(session[i, 1]) + 1).ToString();
                            Session.Add("EcomCart", session);
                            return Json(new { ret = true });
                        }

                    }

                    ecomCart = new string[session.Length/2 + 1,2];
                    for (int i = 0; i < session.Length/2; i++)
                    {
                        ecomCart[i,0] = session[i,0];
                        ecomCart[i,1] = session[i,1];
                    }
                    ecomCart[session.Length/2,0] = id;
                    ecomCart[session.Length/2, 1] = "1";
                }
                else
                {
                    ecomCart = new string[1,2];
                    ecomCart[0,0] = id;
                    ecomCart[0,1] = "1";
                }

                Session.Add("EcomCart", ecomCart);
                return Json(new { ret = true});

            }
            catch(Exception ex)
            {
                return Json(new { ret = false});

            }
        }

        public JsonResult RemoveItemCart(string id)
        {
            try
            {
                string[,] sesion = (string[,])Session["EcomCart"];
                for (int i = 0; i < sesion.Length; i++)
                {
                    if (sesion[i,0] == id)
                    {
                        sesion[i,0] = "0";
                        Session.Add("EcomCart", sesion);
                        return Json(new {ret=true});
                    }
                }
            }catch(Exception ex)
            {
                return Json(new { ret = false});

            }
            return Json(new { ret = true });

        }

        public JsonResult Quantity(string countert, string id)
        {

            try
            {
                string[,] sesion = (string[,])Session["EcomCart"];
                for (int i = 0; i < sesion.Length; i++)
                {
                    if (sesion[i, 0] == id)
                    {
                        sesion[i, 1] = countert;
                        Session.Add("EcomCart", sesion);
                        return Json(new { ret = true });
                    }
                }
            }
            catch (Exception ex)
            {
                return Json(new { ret = false });

            }
            return Json(new { ret = true });


        }

    }
}