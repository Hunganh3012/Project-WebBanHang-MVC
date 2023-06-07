using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebBanHang.Models;
using WebBanHang.Models.EF;

namespace WebBanHang.Areas.Admin.Controllers
{
    public class CategoryController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        // GET: Admin/Category
        public ActionResult Index()
        {
            var item =db.Categories;
            return View(item);
        }
        public ActionResult Add()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        //đảm bảo tính bảo mật bằng cách kiểm tra mã token ngẫu nhiên được tạo ra từ form và gửi kèm yêu cầu.
        public ActionResult Add(Category model)
        {
            if (ModelState.IsValid)
            {
                model.CreateDate = DateTime.Now;
                model.ModifiedDate = DateTime.Now;
                model.Position = 1; //Thứ tự
                //Tạo đường link như tên miền nên không cần dấu(filtercha thì có dấu gạch 
                //vd:tin-tuc, danh-muc
                model.Alias =WebBanHang.Models.Commons.Filter.FilterChar(model.Title);
                db.Categories.Add(model);
                db.SaveChanges();
            return RedirectToAction("Index");
            }
            return View(model);
            //chuyển hướng người dùng đến phương thức hành động "Index" của cùng một controller
        }
        public ActionResult Edit( int id)
        {
            var item = db.Categories.Find(id);
            return View(item);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Category model)
        {
            if (ModelState.IsValid)
            {
                db.Categories.Attach(model);
                model.ModifiedDate = DateTime.Now;
                model.Alias = WebBanHang.Models.Commons.Filter.FilterChar(model.Title);
                db.Entry(model).Property(x => x.Title).IsModified = true;
                db.Entry(model).Property(x => x.Description).IsModified = true;
                db.Entry(model).Property(x => x.Alias).IsModified = true;
                db.Entry(model).Property(x => x.SeoDescription).IsModified = true;
                db.Entry(model).Property(x => x.SeoKeywords).IsModified = true;
                db.Entry(model).Property(x => x.SeoTitle).IsModified = true;
                db.Entry(model).Property(x => x.Position).IsModified = true;
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(model);
        }

        [HttpPost]
        public ActionResult UpdateD (int id)
        {
            var item = db.Categories.Where(e => e.Id == id);
                foreach (var i in item)
                {
                    i.isDelete = true;
                }
                var result =  db.Categories.Where(row => row.isDelete != true).ToList();
                db.SaveChanges();
                return  Json( new { success = result });
            return Json(new { success = false });
        }
    }
}