using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace BanHangOnline.Models.EF
{
    [Table("tb_OrderDetails")]
    public class OrderDetails
    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        public int OrderID { get; set; }

        public int ProductID { get; set; }
        public decimal Pirce { get; set; }
        public int Quantity { get; set; }

        public virtual Order Order { set; get; }
        public virtual Product Product { set; get; }
    }
}