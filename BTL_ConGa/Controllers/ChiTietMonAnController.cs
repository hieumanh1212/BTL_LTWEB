using BTL_ConGa.Models;
using Microsoft.AspNetCore.Mvc;

namespace BTL_ConGa.Controllers
{
    public class ChiTietMonAnController : Controller
    {
        BtlWebContext db = new BtlWebContext();
        public IActionResult ChiTietSanPham(String MaMon)
        {
            /*var sanPham = db.MonAns.SingleOrDefault(x => x.MaMonAn == MaMon);
            var ctsanpham = db.Anhs.Where(x => x.MaMonAn == MaMon).ToList();*/
            var sanPham = (from a in db.MonAns
                           join b in db.DanhMucs on a.MaDanhMuc equals b.MaDanhMuc
                           join c in db.Anhs on a.MaMonAn equals c.MaMonAn
                           where a.MaMonAn == MaMon
                           select new
                           {
                               a.MaMonAn,
                               a.TenMonAn,
                               a.DonGia,
                               a.MoTa,
                               a.TrangThai,
                               a.AnhDaiDien,
                               a.SoLuong,
                               b.MaDanhMuc,
                               b.TenDanhMuc,
                               c.MaAnh,
                               c.HinhAnh,
                           }).ToList();
            var monAn = (from a in db.MonAns
                         where a.MaMonAn == MaMon
                         select a).ToList();
            ViewBag.monAn = monAn;
            ViewBag.sanPham = sanPham;
            return View(sanPham);
        }
        /*// com bo
        public IActionResult ComBoBurger()
        {
            return View("Views/ChiTietMonAn/ComBo/ComBoBurger.cshtml");
        }
        public IActionResult ComBoMyY()
        {
            return View("Views/ChiTietMonAn/ComBo/ComBoMyY.cshtml");
        }

        // thuc an tru
        public IActionResult ComDuiGaSotNguVi()
        {
            return View("Views/ChiTietMonAn/ThucAnTrua/ComDuiGaSotNguVi.cshtml");
        }
        public IActionResult ComGaKhongXuongSotNguVi()
        {
            return View("Views/ChiTietMonAn/ThucAnTrua/ComGaKhongXuongSotNguVi.cshtml");
        }
        // nuoc uong
        public IActionResult Coca()
        {
            return View("Views/ChiTietMonAn/NuocUong/Coca.cshtml");
        }
        public IActionResult Dasani()
        {
            return View("Views/ChiTietMonAn/NuocUong/Dasani.cshtml");
        }
        // dong gia
        public IActionResult BanhXepTom()
        {
            return View("Views/ChiTietMonAn/DongGia/BanhXepTom.cshtml");
        }
        public IActionResult MienCuonRongBien()
        {
            return View("Views/ChiTietMonAn/DongGia/MienCuonRongBien.cshtml");
        }
        // mon chinh
        public IActionResult CanhGaSotNguVi()
        {
            return View("Views/ChiTietMonAn/MonChinh/CanhGaSotNguVi.cshtml");
        }
        public IActionResult CanhGaSotCayChayLuoi()
        {
            return View("Views/ChiTietMonAn/MonChinh/CanhGaSotCayChayLuoi.cshtml");
        }*/
    }
}
