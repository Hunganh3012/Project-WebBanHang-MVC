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
    }
}