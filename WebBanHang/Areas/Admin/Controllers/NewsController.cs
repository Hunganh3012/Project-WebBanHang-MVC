﻿using System;
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
            var items = db.News.OrderByDescending(x => x.CreateDate).ToList();

            foreach (var item in items)
            {
                if (!string.IsNullOrEmpty(item.SelectedCategoryIds))
                {
                    var selectedCategoryIds = item.SelectedCategoryIds.Split(',');

                    var categories = db.Categories.Where(c => selectedCategoryIds.Contains(c.Id.ToString())).Select(c => c.Title);

                    item.CategoryString = string.Join(", ", categories);
                }
            }

            return View(items);
        }
          public ActionResult Add()
        {
            var result = (from Category in db.Categories select Category).ToList();
            if (result != null)
            {
                ViewBag.MyCate = result.Select(x => new SelectListItem { Text = x.Title, Value = x.Id.ToString() });
            }
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Add(News model, string[] selectedCategories)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    model.CreateDate = DateTime.Now;
                    model.ModifiedDate = DateTime.Now;
                    model.Alias = WebBanHang.Models.Commons.Filter.FilterChar(model.Title);

                    if (selectedCategories != null)
                    {
                        model.SelectedCategoryIds = string.Join(",", selectedCategories);
                    }

                    db.News.Add(model);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                return View(model);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public ActionResult Edit(int id)
        {
            var item = db.News.Find(id);
            var categories = db.Categories.ToList();
            var categoryList = new SelectList(categories, "Id", "Title");

            ViewBag.CategoryList = categoryList;
            return View(item);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(News model, string[] selectedCategories)
        {

            if (ModelState.IsValid)
            {
                db.News.Attach(model);
                model.ModifiedDate = DateTime.Now;
                model.Alias = WebBanHang.Models.Commons.Filter.FilterChar(model.Title);
                if (selectedCategories != null)
                {
                    model.SelectedCategoryIds = string.Join(",", selectedCategories);
                }
                db.Entry(model).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
             
            }
            return View(model);
            }

        [HttpPost]
        public ActionResult UpdateD(int id)
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
        [HttpPost]
        public ActionResult UpdateDAll(List<int> ids)
        {
            db.Configuration.ProxyCreationEnabled = false;
            var items = db.News.Where(x => ids.Contains(x.Id)).ToList();

                    foreach (var item in items)
                    {
                        item.IsDelete = true;
                    }
                    db.SaveChanges(); // Lưu các thay đổi vào cơ sở dữ liệu

                    var result = db.News.Where(x => x.IsDelete != true).ToList();
            return Json(new { success = result });
            return Json(new { success = false });
        }
    }
}