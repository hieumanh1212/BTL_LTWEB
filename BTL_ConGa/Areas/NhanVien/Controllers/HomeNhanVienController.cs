﻿using Microsoft.AspNetCore.Mvc;
using BTL_ConGa.Models;
using Microsoft.EntityFrameworkCore;
using X.PagedList;

namespace BTL_ConGa.Areas.NhanVien.Controllers
{
    [Area("nhanvien")]
    [Route("nhanvien")]
    [Route("nhanvien/homenhanvien")]
    
    public class HomeNhanVienController : Controller
    {
        BtlWebContext db = new BtlWebContext();

        [Route("")]
        [Route("index")]
        public IActionResult Index()
        {
            return View();
        }
        // Tat Ca Mon An
        //[Route("tatcamonan")]
        //public IActionResult TatCaMonAn(int? page)
        //{
        //    int pageSize = 5;
        //    int pageNumber = page == null || page < 0 ? 1 : page.Value;
        //    // phuc vu phan trang
        //    var lstMonAn = db.MonAns.AsNoTracking().OrderBy(x => x.TenMonAn);
        //    PagedList<MonAn> lst = new PagedList<MonAn>(lstMonAn, pageNumber, pageSize);
        //    return View(lst);
        //}
        [Route("tatcamonan")]
        public IActionResult TatCaMonAn()
        {
            var lstTatCaMonAn = db.MonAns.ToList();
            return View(lstTatCaMonAn);
        }

        //Mon An Theo Danh Muc
        //[Route("monantheodanhmuc")]
        //public IActionResult MonAnTheoDanhMuc(String madanhmuc, int? page)
        //{

        //	int pageSize = 3;
        //	int pageNumber = page == null || page < 0 ? 1 : page.Value;
        //	// phuc vu phan trang
        //	var lstMonAn = db.MonAns.AsNoTracking().Where(x => x.MaDanhMuc == madanhmuc).OrderBy(x => x.TenMonAn);
        //	PagedList<MonAn> lst = new PagedList<MonAn>(lstMonAn, pageNumber, pageSize);
        //	var tendanhmuc = db.DanhMucs.Find(madanhmuc);
        //	ViewBag.madanhmuc = madanhmuc;
        //	ViewBag.tendanhmuc = tendanhmuc.TenDanhMuc;
        //	return View(lst);
        //}
        [Route("monantheodanhmuc")]
        public IActionResult MonAnTheoDanhMuc(String madanhmuc)
        {

            var lstMonAnTheoDanhMuc = db.MonAns.Where(x=>x.MaDanhMuc==madanhmuc).ToList();
            var tendanhmuc = db.DanhMucs.Find(madanhmuc);
            ViewBag.tendanhmuc = tendanhmuc.TenDanhMuc;
            return View(lstMonAnTheoDanhMuc);
        }


        [Route("chitietmonan")]
        public IActionResult ChiTietMonAn(String mamonan)
        {

            var lstMonAn = db.MonAns.Find(mamonan);
            return View(lstMonAn);

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

    }
}