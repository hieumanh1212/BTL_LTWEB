using BTL_ConGa.Models;
using Microsoft.AspNetCore.Mvc;

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
                if (u != null)
                {
                    HttpContext.Session.SetString("UserName", u.TaiKhoan1.ToString());
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
