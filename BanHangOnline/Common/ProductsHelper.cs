using BanHangOnline.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BanHangOnline.Common
{
    public class ProductsHelper
    {
        private static ApplicationDbContext db = new ApplicationDbContext();

        public static int getQuantityByProductId(int prodId )
        {
            var item = db.Products.Find(prodId);
            if (item != null)
            {
                return item.Quantity;
            }
            return 1;
        }
    }
}