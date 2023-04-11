using BTL_ConGa.Models;
using BTL_ConGa.Models.LichSu;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Globalization;

namespace BTL_ConGa.Controllers
{
    public class TaiKhoanController : Controller
    {
        BtlWebContext db = new BtlWebContext();
        public IActionResult TaiKhoan()
        {
            return View("Views/TaiKhoan/TaiKhoan.cshtml");
        }
        public IActionResult ChiTietTaiKhoan()
        {
            ViewBag.IDCustomer = HttpContext.Session.GetString("IDCustomer");
            ViewBag.Name = HttpContext.Session.GetString("Name");
            ViewBag.Phone = HttpContext.Session.GetString("Phone");
            ViewBag.Address = HttpContext.Session.GetString("Address");
            ViewBag.Email = HttpContext.Session.GetString("Email");
            ViewBag.Gender = HttpContext.Session.GetString("Gender");
            ViewBag.Birth = HttpContext.Session.GetString("Birth");

            return View("Views/TaiKhoan/ChiTietTaiKhoan.cshtml");
        }
        public IActionResult DoiMatKhau()
        {
            ViewBag.Username = HttpContext.Session.GetString("UserName");
            ViewBag.Password = HttpContext.Session.GetString("Password");
            return View("Views/TaiKhoan/DoiMatKhau.cshtml");
        }
        public IActionResult LichSuDatHang()
        {
            var hdb = (from p in db.MonAns
                       join d in db.ChiTietHoaDonBans
                       on p.MaMonAn equals d.MaMonAn
                       join g in db.HoaDonBans
                       on d.MaHoaDon equals g.MaHoaDon
                       where g.IdkhachHang == HttpContext.Session.GetString("IDCustomer")
                       orderby g.MaHoaDon
                       select new LichSuModel
                       {
                           MaHoaDon = g.MaHoaDon, 
                           NgayTao = g.NgayTao,
                           TongTien = g.TongTien,
                           IdkhachHang = g.IdkhachHang,
                           SoLuong = d.SoLuong,
                           MaMonAn = p.MaMonAn,
                           TenMonAn = p.TenMonAn,
                           DonGia = p.DonGia,
                           AnhDaiDien = p.AnhDaiDien
                       }).ToList();

            //Liệt kê các hóa đơn của khách hàng X
            var soluonghdb = db.HoaDonBans.Where(x => x.IdkhachHang == HttpContext.Session.GetString("IDCustomer")).ToList();
            ViewBag.DanhSachHDB = soluonghdb;
            ViewBag.SoLuongHDB = soluonghdb.Count;
            //var chitiethdb = db.ChiTietHoaDonBans.Where(x=>x.MaHoaDon == )
            return View(hdb);
        }

        [HttpGet]
        public IActionResult DangNhap()
        {
            if (HttpContext.Session.GetString("UserName") == null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("TrangChu", "TrangChu");

            }
        }
        [HttpPost]
        public IActionResult DangNhap(TaiKhoan user)
        {
            if (HttpContext.Session.GetString("UserName") == null)
            {
                var u = db.TaiKhoans.Where(x => x.TaiKhoan1 == user.TaiKhoan1 && x.MatKhau == user.MatKhau).FirstOrDefault();
                var k = db.KhachHangs.Where(x => x.TaiKhoan == user.TaiKhoan1).FirstOrDefault();
                if (u != null)
                {
                    HttpContext.Session.SetString("UserName", u.TaiKhoan1.ToString());
                    HttpContext.Session.SetString("Password", u.MatKhau.ToString());
                    HttpContext.Session.SetString("IDCustomer", k.IdkhachHang.ToString());
                    HttpContext.Session.SetString("Name", k.TenKhachHang.ToString());
                    HttpContext.Session.SetString("Phone", k.SoDienThoai.ToString());
                    HttpContext.Session.SetString("Address", k.DiaChi.ToString());
                    HttpContext.Session.SetString("Email", k.Email.ToString());
                    HttpContext.Session.SetString("Gender", k.GioiTinh.ToString());
                    HttpContext.Session.SetString("Birth", k.NgaySinh.ToString("yyyy-MM-dd"));
                    if (u.MaLoaiTaiKhoan == "LTK01")
                    {
                        return RedirectToAction("", "Nhanvien");
                    }
                    else if (u.MaLoaiTaiKhoan == "LTK02")
                    {
                        return RedirectToAction("TrangChu", "TrangChu");
                    }
                    else
                    {
                        return RedirectToAction("", "Admin");
                    }
                }
            }
            return View(user);

        }

        public IActionResult DangXuat()
        {
            HttpContext.Session.Clear();
            HttpContext.Session.Remove("UserName");
            return RedirectToAction("TrangChu", "TrangChu");
        }

        public int splitId(string id)
        {
            //KH002 
            string res = id.Substring(2, id.Length - 2);
            return int.Parse(res);
        }

        public IActionResult DangKy()
        {
            var lastCustomer = db.KhachHangs.ToList();
            int lastId = splitId(lastCustomer.OrderByDescending(x => splitId(x.IdkhachHang)).FirstOrDefault().IdkhachHang.ToString());
            ViewBag.lastId = lastId;
            return View(lastId);
        }

    }
}


