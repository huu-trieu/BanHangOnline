using BanHangOnline.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BanHangOnline.Controllers
{
    public class ArticleController : Controller
    {
        // GET: Article
        private ApplicationDbContext db = new ApplicationDbContext();
        public ActionResult Index(string alias)
        {
            var item = db.Posts.FirstOrDefault(x => x.Alias == alias);

            return View(item);
        }
    }
}