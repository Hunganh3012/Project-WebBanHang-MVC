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
        private ApplicationDbContext _dbConnect = new ApplicationDbContext();
        // GET: Admin/Category
        public ActionResult Index()
        {
            var item = _dbConnect.Categories;
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
            return RedirectToAction("Index");
            }
            return View(model);
            //chuyển hướng người dùng đến phương thức hành động "Index" của cùng một controller
        }
    }
}