using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebBanHang.Models;
using WebBanHang.Models.EF;

namespace WebBanHang.Areas.Admin.Controllers
{
    public class NewsController : Controller
    {
        // GET: Admin/News
        private ApplicationDbContext db = new ApplicationDbContext();
        public ActionResult Index()
        {
            var item=db.News.OrderByDescending(x=>x.CreateDate).ToList();
            return View(item);
        }
        public ActionResult Add()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Add(News model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    model.CreateDate = DateTime.Now;
                    model.CategoryId = 3;
                    model.ModifiedDate = DateTime.Now;
                    model.Alias = WebBanHang.Models.Commons.Filter.FilterChar(model.Title);
                    db.News.Add(model);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                return View(model);

            }
            catch(Exception ex)
            {
                throw;
            }

        }
        public ActionResult Edit(int id)
        {
            var item = db.News.Find(id);
            return View(item);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(News model)
        {

            if (ModelState.IsValid)
            {
                db.News.Attach(model);
                model.ModifiedDate = DateTime.Now;
                model.Alias = WebBanHang.Models.Commons.Filter.FilterChar(model.Title);
                db.Entry(model).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
             
            }
            return View(model);
            }

        [HttpPost]
        public ActionResult UpdateD(int id)
        {
            try
            {
                db.Configuration.ProxyCreationEnabled = false;
                var item = db.News.Where(x => x.Id== id);
               foreach(var e in item)
                {
                    e.IsDelete = true;
                }
                var result = db.News.Where(row => row.IsDelete != true).ToList();
                db.SaveChanges();
                return Json(new { success = result });
                return Json(new { success = false });
            }
            catch(Exception ex)
                {
                    throw;
                }
        }
    }
}