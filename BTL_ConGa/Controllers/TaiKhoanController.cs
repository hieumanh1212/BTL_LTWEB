using BTL_ConGa.Models;
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
            return View("Views/TaiKhoan/DoiMatKhau.cshtml");
        }
        public IActionResult LichSuDatHang()
        {
            return View("Views/TaiKhoan/LichSuDatHang.cshtml");
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
                    HttpContext.Session.SetString("IDCustomer", k.IdkhachHang.ToString());
                    HttpContext.Session.SetString("Name", k.TenKhachHang.ToString());
                    HttpContext.Session.SetString("Phone", k.SoDienThoai.ToString());
                    HttpContext.Session.SetString("Address", k.DiaChi.ToString());
                    HttpContext.Session.SetString("Email", k.Email.ToString());
                    HttpContext.Session.SetString("Gender", k.GioiTinh.ToString());
                    HttpContext.Session.SetString("Birth", k.NgaySinh.ToString("yyyy-MM-dd"));
                    if (u.MaLoaiTaiKhoan == "LTK01")
                    {
                        return RedirectToAction("ChiTietTaiKhoan", "TaiKhoan");
                    }
                    else if (u.MaLoaiTaiKhoan == "LTK02")
                    {
                        return RedirectToAction("TrangChu", "TrangChu");
                    }
                    else
                    {
                        return RedirectToAction("DoiMatKhau", "TaiKhoan");
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


