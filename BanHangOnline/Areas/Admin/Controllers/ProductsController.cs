using BanHangOnline.Models;
using BanHangOnline.Models.EF;
using PagedList;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BanHangOnline.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin,Employee")]
    public class ProductsController : Controller
    {
        // GET: Admin/Products
        private ApplicationDbContext db = new ApplicationDbContext();
        public ActionResult Index(string Searchtext,int? page)
        {
            IEnumerable<Product> items = db.Products.OrderByDescending(x => x.ID);
            var pageSize = 10;
            if (page == null)
            {
                page = 1;
            }
            if (!string.IsNullOrEmpty(Searchtext))
            {
                items = items.Where(x => x.Alias.Contains(Searchtext) || x.Title.Contains(Searchtext));
            }
            var pageIndex = page.HasValue ? Convert.ToInt32(page) : 1;
            items = items.ToPagedList(pageIndex, pageSize);
            ViewBag.Page = page; // trang hiện tại đang đứng
            ViewBag.PageSize = pageSize; // số item được phép hiển thị trên 1 trang
            return View(items);
        }

        public ActionResult Add()
        {
            ViewBag.ProductCategory = new SelectList(db.ProductCategories.ToList(), "ID", "Title");
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Add(Product model, List<string> Images, List<int> rDefault)
        {
            if (ModelState.IsValid)
            {
                if (Images != null && Images.Count > 0)
                {
                    for (int i = 0; i < Images.Count; i++)
                    {
                        if (i + 1 == rDefault[0])
                        {
                            model.Image = Images[i];
                            model.ProductImage.Add(new ProductImage
                            {
                                ProductID = model.ID,
                                Image = Images[i],
                                isDefault = true
                            });
                        }
                        else
                        {
                            model.ProductImage.Add(new ProductImage
                            {
                                ProductID = model.ID,
                                Image = Images[i],
                                isDefault = false
                            });
                        }
                    }
                }
                model.createdDate = DateTime.Now;
                model.modifiedDate = DateTime.Now;
                if (string.IsNullOrEmpty(model.SeoTitle))
                {
                    model.SeoTitle = model.Title;
                }
                if (string.IsNullOrEmpty(model.Alias))
                    model.Alias = WebBanHangOnline.Models.Common.Filter.FilterChar(model.Title);
                db.Products.Add(model);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ProductCategory = new SelectList(db.ProductCategories.ToList(), "Id", "Title");
            return View(model);
        }

        public ActionResult Edit(int id)
        {
            ViewBag.ProductCategory = new SelectList(db.ProductCategories.ToList(), "Id", "Title");
            var item = db.Products.Find(id);
            return View(item);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Product model)
        {
            if (ModelState.IsValid)
            {
                model.modifiedDate = DateTime.Now;
                model.Alias = WebBanHangOnline.Models.Common.Filter.FilterChar(model.Title);
                db.Products.Attach(model);
                db.Entry(model).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(model);
        }

        [HttpPost]
        public ActionResult Delete(int id)
        {

            var item = db.Products.Find(id);

            if (item != null)
            {
                var checkImg = item.ProductImage.Where(x => x.ProductID == item.ID);
                if (checkImg != null)
                {
                    foreach (var img in checkImg)
                    {
                        db.ProductImages.Remove(img);
                        db.SaveChanges();
                    }
                }
                db.Products.Remove(item);
                db.SaveChanges();
                return Json(new { success = true });
            }

            return Json(new { success = false });
        }

        [HttpPost]
        public ActionResult IsActive(int id)
        {
            var item = db.Products.Find(id);
            if (item != null)
            {
                item.isActive = !item.isActive;
                db.Entry(item).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return Json(new { success = true, isActive = item.isActive });
            }
            return Json(new { success = false });
        }

        [HttpPost]
        public ActionResult IsHome(int id)
        {
            var item = db.Products.Find(id);
            if (item != null)
            {
                item.isHome = !item.isHome;
                db.Entry(item).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return Json(new { success = true, isHome = item.isHome });
            }
            return Json(new { success = false });
        }

        [HttpPost]
        public ActionResult IsSale(int id)
        {
            var item = db.Products.Find(id);
            if (item != null)
            {
                item.isSale = !item.isSale;
                db.Entry(item).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return Json(new { success = true, isSale = item.isSale });
            }
            return Json(new { success = false });
        }

        public ActionResult IndexKho(string Searchtext, int? page)
        {
            IEnumerable<Product> items = db.Products.OrderByDescending(x => x.ID);
            var pageSize = 10;
            if (page == null)
            {
                page = 1;
            }
            if (!string.IsNullOrEmpty(Searchtext))
            {
                items = items.Where(x => x.Alias.Contains(Searchtext) || x.Title.Contains(Searchtext));
            }
            var pageIndex = page.HasValue ? Convert.ToInt32(page) : 1;
            items = items.ToPagedList(pageIndex, pageSize);
            ViewBag.Page = page; // trang hiện tại đang đứng
            ViewBag.PageSize = pageSize; // số item được phép hiển thị trên 1 trang
            return View(items);
        }
        public ActionResult EditK(int id)
        {
            ViewBag.ProductCategory = new SelectList(db.ProductCategories.ToList(), "Id", "Title");
            var item = db.Products.Find(id);
            return View(item);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditK(Product model)
        {
            if (ModelState.IsValid)
            {
                model.modifiedDate = DateTime.Now;
                model.Alias = WebBanHangOnline.Models.Common.Filter.FilterChar(model.Title);
       
                var product = db.Products.Find(model.ID);
                var oldPrice = product.Price;

                if (product != null)
                {
                        product.Quantity += model.Quantity;
                        product.Price = model.Price;
                    db.Entry(product).State = EntityState.Modified;
                    db.SaveChanges();

                    TTNhapkho ttNhapkho = new TTNhapkho
                    {
                        ProductId = product.ID,
                        TenSP = product.Title,
                        SoLuongThem = model.Quantity,
                        SoLuongChuaNhap = product.Quantity - model.Quantity,
                        SoLuongSauKhiThem = product.Quantity,
                        GiaTien = product.Price,
                        GiaCu = oldPrice,
                        NgayTao = DateTime.Now
                    };
                    db.TTNhapkho.Add(ttNhapkho);
                    db.SaveChanges();
                    return RedirectToAction("IndexKho", "Products");
                }
            }
            return View(model);
        }
        public ActionResult ViewHistory(int ID)
        {
            var history = db.TTNhapkho.Where(x => x.ProductId == ID).ToList();
            var productName = db.TTNhapkho.Where(p => p.ProductId == ID).Select(p => p.TenSP).FirstOrDefault();
            ViewBag.ProductName = productName;
            return View(history);
        }



    }
}