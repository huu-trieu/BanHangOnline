using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace BanHangOnline.Models.EF
{
    [Table("TTNhapKho")]
    public class TTNhapkho
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public string TenSP { get; set; }
        public int SoLuongChuaNhap { get; set; }
        public int SoLuongSauKhiThem { get; set; }
        public int SoLuongThem { get; set; }
        public decimal GiaTien { get; set; }
        public decimal GiaCu { get; set; }
        public DateTime NgayTao { get; set; }
    }
}