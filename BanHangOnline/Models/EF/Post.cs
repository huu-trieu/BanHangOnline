using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BanHangOnline.Models.EF
{
    [Table("tb_Post")]
    public class Post : CommonAbstract
    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        [Required()]
        [StringLength(150)]
        public string Title { get; set; }
        [StringLength(150)]
        public string Alias { get; set; }
        public string Description { get; set; }

        [AllowHtml]
        public string Details { get; set; }
        [StringLength(250)]
        public string Image { get; set; }
        public int CategoryID { get; set; }
        [StringLength(500)]
        public string SeoDescription { get; set; }
        [StringLength(250)]
        public string SeoTitle { get; set; }
        [StringLength(250)]
        public string SeoKeywords { get; set; }
        public bool isActive { set; get; }
        public virtual Category Category { get; set; }
    }
}