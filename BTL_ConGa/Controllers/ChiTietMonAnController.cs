using Microsoft.AspNetCore.Mvc;

namespace BTL_ConGa.Controllers
{
    public class ChiTietMonAnController : Controller
    {
        // com bo
        public IActionResult CanhGaSotNguVi()
        {
            return View("Views/ChiTietMonAn/ComBo/CanhGaSotNguVi.cshtml");
        }
        // thuc an tru
        public IActionResult ComDuiGaSotNguVi()
        {
            return View("Views/ChiTietMonAn/ThucAnTrua/ComDuiGaSotNguVi.cshtml");
        }
        // nuoc uong
        public IActionResult Coca()
        {
            return View("Views/ChiTietMonAn/NuocUong/Coca.cshtml");
        }
        // dong gia
        public IActionResult BanhXepTom()
        {
            return View("Views/ChiTietMonAn/DongGia/BanhXepTom.cshtml");
        }
    }
}
