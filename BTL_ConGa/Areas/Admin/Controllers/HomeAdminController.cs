﻿using Microsoft.AspNetCore.Mvc;
using BTL_ConGa.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using X.PagedList;

namespace BTL_ConGa.Areas.Admin.Controllers
{
	
	[Area("admin")]
	[Route("admin")]
	[Route("admin/homeadmin")]
	public class HomeAdminController : Controller
	{
        BtlWebContext db = new BtlWebContext();
		[Route("")]
		[Route("index")]
		public IActionResult Index()
		{
            return RedirectToAction("ThongKe");
		}
        [Route("thongke")]
        public IActionResult ThongKe()
        {
            var lsthoadon = db.HoaDonBans.ToList();
            return View(lsthoadon);
        }

        // Hoa Don Ban
        //[Route("hoadonban")]
        //public IActionResult HoaDonBan(int? page)
        //{
        //    int pageSize = 3;
        //    int pageNumber = page == null || page < 0 ? 1 : page.Value;
        //    // phuc vu phan trang
        //    var lstHoaDonBan = db.HoaDonBans.AsNoTracking().OrderBy(x => x.MaHoaDon);
        //    PagedList<HoaDonBan> lst = new PagedList<HoaDonBan>(lstHoaDonBan, pageNumber, pageSize);
        //    return View(lst);
        //}
        [Route("hoadonban")]
        public IActionResult HoaDonBan()
        {
            var lstHoaDonBan = db.HoaDonBans.ToList();
            return View(lstHoaDonBan);
        }


        [Route("chitiethoadonban")]
        public IActionResult ChiTietHoaDonBan(String mahoadon)
        {
            var lstHoaDonBan = db.HoaDonBans.Find(mahoadon);
            return View(lstHoaDonBan);
        }

        // Danh Muc Mon An

        //[Route("danhmucmonan")]
        //public IActionResult DanhMucMonAn(int? page)
        //{
        //    int pageSize = 3;
        //    int pageNumber = page == null || page < 0 ? 1 : page.Value;
        //    // phuc vu phan trang
        //    var lstDanhMucMonAn = db.DanhMucs.AsNoTracking().OrderBy(x => x.TenDanhMuc);
        //    PagedList<DanhMuc> lst = new PagedList<DanhMuc>(lstDanhMucMonAn, pageNumber, pageSize);
        //    return View(lst);
        //}
        [Route("danhmucmonan")]
        public IActionResult DanhMucMonAn()
        {
            var lstDanhMucMonAn = db.DanhMucs.ToList();
            return View(lstDanhMucMonAn);

        }


        // Nhan Vien
        //[Route("nhanvien")]
        //public IActionResult NhanVien(int? page)
        //{
        //    int pageSize = 3;
        //    int pageNumber = page == null || page < 0 ? 1 : page.Value;
        //    //phuc vu phan trang
        //    var lstNhanVien = db.NhanViens.AsNoTracking().OrderBy(x => x.TenNhanVien);
        //    PagedList<Models.NhanVien> lst = new PagedList<Models.NhanVien>(lstNhanVien, pageNumber, pageSize);
        //    return View(lst); 
        //}
        [Route("nhanvien")]
        public IActionResult NhanVien()
        {
            var lstNhanVien = db.NhanViens.ToList();
            return View(lstNhanVien);

        }
        [Route("themnhanvien")]
        public IActionResult ThemNhanVien()
        {
            List<string> gioitinh = new List<string>();
            gioitinh.Add("Nam");
            gioitinh.Add("Nữ");
            gioitinh.Add("Khác");
            ViewBag.GioiTinh = new SelectList(gioitinh);
            return View();
        }


        // Tat Ca Mon An

        //[Route("tatcamonan")]
        //public IActionResult TatCaMonAn(int? page)
        //      {
        //          int pageSize = 5;
        //          int pageNumber = page == null || page < 0 ? 1 : page.Value;
        //          // phuc vu phan trang
        //          var lstMonAn = db.MonAns.AsNoTracking().OrderBy(x => x.TenMonAn);
        //          PagedList<MonAn> lst = new PagedList<MonAn>(lstMonAn, pageNumber, pageSize);
        //          return View(lst);
        //      }

        [Route("tatcamonan")]
        public IActionResult TatCaMonAn()
        {
            var lstTatCaMonAn = db.MonAns.ToList();
            return View(lstTatCaMonAn);
        }

        //[Route("monantheodanhmuc")]
        //public IActionResult MonAnTheoDanhMuc(String madanhmuc, int? page)
        //{

        //    int pageSize = 3;
        //    int pageNumber = page == null || page < 0 ? 1 : page.Value;
        //    // phuc vu phan trang
        //    var lstMonAn = db.MonAns.AsNoTracking().Where(x=>x.MaDanhMuc==madanhmuc).OrderBy(x => x.TenMonAn);
        //    PagedList<MonAn> lst = new PagedList<MonAn>(lstMonAn, pageNumber, pageSize);
        //    var tendanhmuc = db.DanhMucs.Find(madanhmuc);
        //    ViewBag.madanhmuc = madanhmuc;
        //    ViewBag.tendanhmuc = tendanhmuc.TenDanhMuc;
        //    return View(lst);
        //}

        [Route("monantheodanhmuc")]
        public IActionResult MonAnTheoDanhMuc(String madanhmuc)
        {
            var danhmuc = db.DanhMucs.Find(madanhmuc);
            ViewBag.tendanhmuc = danhmuc.TenDanhMuc;
            var lstMonAnTheoDanhMuc = db.MonAns.Where(x => x.MaDanhMuc == madanhmuc).ToList();
            return View(lstMonAnTheoDanhMuc);
        }

        [Route("chitietmonan")]
        public IActionResult ChiTietMonAn(String mamonan)
        {

            var lstMonAn = db.MonAns.Find(mamonan);
            return View(lstMonAn);

        }
        //Khach Hang

        //[Route("khachhang")]
        //public IActionResult KhachHang(int? page)
        //{
        //    int pageSize = 3;
        //    int pageNumber = page == null || page < 0 ? 1 : page.Value;
        //    // phuc vu phan trang
        //    var lstKhachHang = db.KhachHangs.AsNoTracking().OrderBy(x => x.TenKhachHang);
        //    PagedList<KhachHang> lst = new PagedList<KhachHang>(lstKhachHang, pageNumber, pageSize);
        //    return View(lst);
        //}
        [Route("khachhang")]
        public IActionResult KhachHang(int? page)
        {
            var lstKhachHang = db.KhachHangs.ToList();
            return View(lstKhachHang);
        }

        // FeedBack

        //[Route("feedback")]
        //public IActionResult FeedBack(int? page)
        //{
        //    int pageSize = 3;
        //    int pageNumber = page == null || page < 0 ? 1 : page.Value;
        //    // phuc vu phan trang
        //    var lstFeedBack = db.Feedbacks.AsNoTracking().OrderBy(x => x.HoTen);
        //    PagedList<Feedback> lst = new PagedList<Feedback>(lstFeedBack, pageNumber, pageSize);
        //    return View(lst);
        //}
        [Route("feedback")]
        public IActionResult FeedBack()
        {
            var lstFeedback = db.Feedbacks.ToList();
            return View(lstFeedback);
        }

        // BaiViet

        //[Route("baiviet")]
        //public IActionResult BaiViet(int? page)
        //{
        //    int pageSize = 3;
        //    int pageNumber = page == null || page < 0 ? 1 : page.Value;
        //    // phuc vu phan trang
        //    var lstBaiViet = db.TinTucs.AsNoTracking().OrderBy(x => x.TieuDe);
        //    PagedList<TinTuc> lst = new PagedList<TinTuc>(lstBaiViet, pageNumber, pageSize);
        //    return View(lst);
        //}
        [Route("baiviet")]
        public IActionResult BaiViet()
        {
            var lstTinTuc = db.TinTucs.ToList();
            return View(lstTinTuc);
        }


        // Voucher

        //[Route("voucher")]
        //public IActionResult Voucher(int? page)
        //{
        //    int pageSize = 3;
        //    int pageNumber = page == null || page < 0 ? 1 : page.Value;
        //    // phuc vu phan trang
        //    var lstVoucher = db.Vouchers.AsNoTracking().OrderBy(x => x.TenVoucher);
        //    PagedList<Voucher> lst = new PagedList<Voucher>(lstVoucher, pageNumber, pageSize);
        //    return View(lst);
        //}
        [Route("voucher")]
        public IActionResult Voucher()
        {
            var lstVoucher = db.Vouchers.ToList();
            return View(lstVoucher);
        }

        [Route("dangxuat")]
        public IActionResult DangXuat()
        {
            HttpContext.Session.Clear();
            HttpContext.Session.Remove("UserName");
            return RedirectToAction("TrangChu", "TrangChu");
        }

        //thêm mới một nhân viên
        [Route("ThemNhanVienMoi")]
        [HttpGet]
        public IActionResult ThemNhanVienMoi()
        {
            
            return View();
        }

        [Route("SuaDanhMuc")]
        [HttpGet]
        public IActionResult SuaDanhMuc(string maDanhMuc)
        {
            ViewBag.MaDanhMuc = new SelectList(db.DanhMucs.ToList(), "MaDanhMuc", "TenDanhMuc");
            var danhMuc = db.DanhMucs.Find(maDanhMuc);
            return View(danhMuc);
        }
        [Route("SuaDanhMuc")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult SuaDanhMuc(DanhMuc danhMuc)
        {
            if (ModelState.IsValid)
            {
                db.Update(danhMuc);
                db.SaveChanges();
                return RedirectToAction("DanhMucMonAn");

            }
            return View(danhMuc);
        }
        [Route("XoaDanhMuc")]
        [HttpGet]
        public IActionResult XoaDanhMuc(string maDanhMuc)
        {
            TempData["Message"] = "";
            var monAn = db.MonAns.Where(x => x.MaDanhMuc == maDanhMuc).ToList();
            if (monAn.Count() > 0)
            {
                TempData["Message"] = "Không xóa được danh mục này";
                return RedirectToAction("DanhMucMonAn");
            }
            db.Remove(db.DanhMucs.Find(maDanhMuc));
            db.SaveChanges();
            TempData["Message"] = "Danh mục đã được xóa";
            return RedirectToAction("DanhMucMonAn");
        }
        [Route("Split")]
        public int splitId(string id)
        {
            //KH002 
            string res = id.Substring(2, id.Length - 2);
            return int.Parse(res);
        }
        [Route("ThemDanhMuc")]
        public IActionResult ThemDanhMuc()
        {
            var lastDanhMuc = db.DanhMucs.ToList();
            int lastId = splitId(lastDanhMuc.OrderByDescending(x => splitId(x.MaDanhMuc)).FirstOrDefault().MaDanhMuc.ToString());
            ViewBag.lastId = lastId;
            return View();
        }

        [Route("SuaNhanVien")]
        [HttpGet]
        public IActionResult SuaNhanVien(string maNhanVien)
        {
            // Lấy đối tượng NhanVien cần sửa từ CSDL bằng mã nhân viên
            var nhanVien = db.NhanViens.Find(maNhanVien);
            //ViewBag.TaiKhoan = new SelectList(db.TaiKhoans, "MaLoaiTaiKhoan", "TaiKhoan");
            ViewBag.TaiKhoan = db.NhanViens.FirstOrDefault(x => x.MaNhanVien == maNhanVien).TaiKhoan;
            ViewBag.GioiTinh = new List<SelectListItem>
            {
                new SelectListItem { Value = "Nam", Text = "Nam" },
                new SelectListItem { Value = "Nữ", Text = "Nữ" },
            };


            return View(nhanVien); // Trả về view hiển thị form sửa đối tượng
        }

        [Route("SuaNhanVien")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult SuaNhanVien(Models.NhanVien nhanVien)
        {


            // Cập nhật thông tin của đối tượng NhanVien trong CSDL
            db.Entry(nhanVien).State = EntityState.Modified;

            db.SaveChanges();

            return RedirectToAction("NhanVien"); // Trở về trang danh sách đối tượng

        }

        [Route("XoaNhanVien")]
        [HttpGet]
        public IActionResult XoaNhanVien(string maNhanVien)
        {
            TempData["Message"] = "";
            var hoaDonBan = db.HoaDonBans.FirstOrDefault(h => h.MaNhanVien == maNhanVien);
            if (hoaDonBan != null)
            {
                TempData["Message"] = "Không thể xóa nhân viên này vì đã có hóa đơn bán liên quan";
                return RedirectToAction("NhanVien");
            }
            var nhanVien = db.NhanViens.Find(maNhanVien);
            if (nhanVien == null)
            {
                return NotFound();
            }
            db.NhanViens.Remove(nhanVien);
            var taiKhoan = db.TaiKhoans.FirstOrDefault(t => t.TaiKhoan1 == nhanVien.TaiKhoan);
            if (taiKhoan != null)
            {
                db.TaiKhoans.Remove(taiKhoan);
            }


            db.SaveChanges();
            TempData["Message"] = "Nhân viên và tài khoản của nhân viên đã được xóa";
            return RedirectToAction("NhanVien");
        }
    }
}
