using Models;
using Models.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineShop.Areas.Admin.Controllers
{
    public class CategoryController : Controller
    {
        // GET: Admin/Category
        public ActionResult Index(int pagep  = 1,int pagesize  = 3)
        {
            //var iplCate = new CategoryModel();
            //var model = iplCate.ListAll(false);
            //return View(model);

            var dao = new CategoryModel();
            return View(dao.ListAllPagiing(pagep, pagesize));



        }

        

        // GET: Admin/Category/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Admin/Category/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/Category/Create
        [HttpPost]
        [ValidateAntiForgeryToken]  /*Chống Required liên tục lên server*/
        public ActionResult Create(Category collection)
        {
            try
            {
                if (ModelState.IsValid) {

                     //TODO: Add insert logic here

                    var isCate = new CategoryModel();
                    var res = isCate.Insert(collection.Name, collection.Alias, DateTime.Parse( collection.CreatedDate.ToString()), int.Parse( collection.ParentID.ToString()), bool.Parse( collection.Status.ToString()), int.Parse(collection.Order.ToString()));
                    if (res > 0)
                    {
                        return RedirectToAction("Index");


                    }
                    else
                    {
                        ModelState.AddModelError("", "Thêm mới  một mẫu tin không thành công!");
                    }

                    

                };

                return View(collection);
                
            }
            catch
            {
                return View();
            }
        }

        // GET: Admin/Category/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Admin/Category/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Admin/Category/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Admin/Category/Delete/5
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
