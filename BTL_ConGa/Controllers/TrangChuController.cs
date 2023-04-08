using BTL_ConGa.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using X.PagedList;

namespace BTL_ConGa.Controllers
{
    public class TrangChuController : Controller
    {
        BtlWebContext db = new BtlWebContext();
        public IActionResult TrangChu(int? page)
        {
            int pageSize = 8;
            int pageNumber = page == null || page <=0?1:page.Value;
            var listMonAn = db.MonAns.AsNoTracking().OrderBy(x => x.MaMonAn);
            PagedList<MonAn> lst = new PagedList<MonAn>(listMonAn, pageNumber, pageSize);
            return View(lst);
        }
        
        
        
    }
}
