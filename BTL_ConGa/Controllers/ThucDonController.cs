using BTL_ConGa.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using X.PagedList;

namespace BTL_ConGa.Controllers
{
    public class ThucDonController : Controller
    {
        BtlWebContext db = new BtlWebContext();
        
        public IActionResult MonAnTheoDanhMuc(String MaDanhMuc, int? page)
        {
            int pageSize = 3;
            int pageNumber = page == null || page < 0 ? 1 : page.Value;
            List<MonAn> lstMonan = db.MonAns.AsNoTracking().Where(x => x.MaDanhMuc == MaDanhMuc).OrderBy(x => x.TenMonAn).ToList();
            PagedList<MonAn> lst = new PagedList<MonAn>(lstMonan, pageNumber, pageSize);
            ViewBag.MaDanhMuc = MaDanhMuc;
            return View(lst);
        }
    }
}
