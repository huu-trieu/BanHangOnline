using BanHangOnline.Models;
using BanHangOnline.Models.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;

namespace BanHangOnline.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    public class OrderController : Controller
    {
        // GET: Admin/Order
        private ApplicationDbContext db = new ApplicationDbContext();
        public ActionResult Index(string Searchtext,int? page)
        {
            //var items = db.Orders.OrderByDescending(x => x.createdDate).ToList();
           
            if (page == null)
            {
                page = 1;
            }
            IEnumerable<Order> items = db.Orders.OrderByDescending(x => x.ID);
            if (!string.IsNullOrEmpty(Searchtext))
            {
                items = items.Where(x => x.Email.Contains(Searchtext) || x.CustomerName.Contains(Searchtext));
            }
            var pageNumber = page ?? 1;
            var pageSize = 10;
            ViewBag.Page = pageNumber; // trang hiện tại đang đứng
            ViewBag.PageSize = pageSize; // số item được phép hiển thị trên 1 trang
            return View(items.ToPagedList(pageNumber, pageSize));
        }

        public ActionResult View(int id)
        {
            var item = db.Orders.Find(id);

            return View(item);
        }

        public ActionResult Partial_SanPham(int id)
        {
            var items = db.OrderDetails.Where(x => x.OrderID == id).ToList();
            return PartialView(items);
        }

        [HttpPost]
        public ActionResult UpdateTT(int id, int trangthai) 
        {
            var item = db.Orders.Find(id);
            if (item != null)
            {
                db.Orders.Attach(item);
                item.Status = trangthai;// cần fix
                db.Entry(item).Property(x => x.TypePayment).IsModified = true;
                db.SaveChanges();
                return Json(new { message = "Success", Success = true });
            }
            return Json(new { message = "Unsuccess", Success = false });
        }
    }
}