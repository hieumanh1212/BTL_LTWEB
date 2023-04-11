using BTL_ConGa.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BTL_ConGa.Areas.NhanVien.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class APINhanVienController : ControllerBase
    {
        BtlWebContext db = new BtlWebContext();
        [HttpPut]
        [Route("DoiMatKhau")]
        public bool ChangePassword(string taikhoan, string matkhau)
        {
            BtlWebContext db = new BtlWebContext();
            //Lấy mã khách đã có
            TaiKhoan tk = db.TaiKhoans.FirstOrDefault(x => x.TaiKhoan1 == taikhoan);
            if (tk == null) return false;
            tk.MatKhau = matkhau;
            db.SaveChanges();
            return true;
        }
    }
}
