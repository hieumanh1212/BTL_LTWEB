using Microsoft.AspNetCore.Mvc;

namespace BTL_ConGa.Controllers
{
    public class TaiKhoanController : Controller
    {
        public IActionResult TaiKhoan()
        {
            return View("Views/TaiKhoan/TaiKhoan.cshtml");
        }

        public IActionResult DoiMatKhau()
        {
            return View();
        }
    }
}
