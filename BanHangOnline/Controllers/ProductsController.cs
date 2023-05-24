using BanHangOnline.Models;
using BanHangOnline.Models.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BanHangOnline.Controllers
{
    public class ProductsController : Controller
    {
        // GET: Products
        private ApplicationDbContext db = new ApplicationDbContext();
        public ActionResult Index(string Searchtext)
        {
            IEnumerable<Product> items = db.Products.OrderByDescending(x => x.ID);
            if (!string.IsNullOrEmpty(Searchtext))
            {
                items = items.Where(x => x.Alias.Contains(Searchtext) || x.Title.Contains(Searchtext));
            }
            //var items = db.Products.ToList();
            return View(items);
        }
        public ActionResult Detail(string alias, int id)
        {
            var item = db.Products.Find(id);
            if (item != null)
            {
                db.Products.Attach(item);
                item.ViewCount = item.ViewCount + 1;
                db.Entry(item).Property(x => x.ViewCount).IsModified = true;
                db.SaveChanges();
            }
            
            return View(item);
        }
        public ActionResult ProductCategory(string alias, int id, string Searchtext)
        {
            IEnumerable<Product> items = db.Products.OrderByDescending(x => x.ID);
            //var items = db.Products.ToList();
            if (id > 0)
            {
                items = items.Where(x => x.ProductCategoryID == id).ToList();
            }
            var cate = db.ProductCategories.Find(id);
            if (cate != null)
            {
                ViewBag.CateName = cate.Title;
            }
            
            if (!string.IsNullOrEmpty(Searchtext))
            {
                items = items.Where(x => x.Alias.Contains(Searchtext) || x.Title.Contains(Searchtext));
            }
            ViewBag.CateId = id;
            return View(items);
        }

        public ActionResult Partial_ItemByCateId()
        {
            var items = db.Products.Where(x => x.isHome && x.isActive).Take(12).ToList();
            return PartialView(items);
        }
        public ActionResult Partial_ProductSale()
        {
            var items = db.Products.Where(x => x.isSale && x.isActive).Take(12).ToList();
            return PartialView(items);
        }

    }
}