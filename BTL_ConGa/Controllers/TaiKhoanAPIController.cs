using BTL_ConGa.Models;
using BTL_ConGa.Models.TaiKhoanAPI;
using BTL_ConGa.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BTL_ConGa.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaiKhoanAPIController : ControllerBase
    {
        private readonly IUserInforService _userInforService;
        BtlWebContext db = new BtlWebContext();
        public TaiKhoanAPIController(IUserInforService userInforService, BtlWebContext db)
        {
            _userInforService = userInforService;
            this.db = db;
        }


        [HttpPost]
        [Route("DangKy")]
        public async Task<IActionResult> DangKy([FromBody] TaiKhoanIn4Model taiKhoan)
        {
            try
            {
                var itemCheckExsits = db.TaiKhoans.FirstOrDefault(x => x.TaiKhoan1 == taiKhoan.Username);
                if (itemCheckExsits != null)
                    return BadRequest();
                //throw new Exception("Đăng kí không thành công");
                await _userInforService.Register(taiKhoan);
                return Ok();
            }
            catch
            {
                return BadRequest();
                throw new Exception("Đăng kí không thành công");
            }
        }


        [HttpPost]
        [Route("DangNhap")]
        public IActionResult DangNhap([FromBody] TaiKhoanDangNhap taikhoan)
        {
            try
            {
                var checkUsernameExsit = db.TaiKhoans.FirstOrDefault(x => x.TaiKhoan1 == taikhoan.Username && x.MatKhau == taikhoan.Password);
                //Tai khoan da ton tai
                if (checkUsernameExsit != null)
                {
                    //Nhân viên
                    if (checkUsernameExsit.MaLoaiTaiKhoan == "LTK01")
                    {
                        return Accepted();  //202
                    }
                    //Khách hàng
                    else if (checkUsernameExsit.MaLoaiTaiKhoan == "LTK02")
                    {
                        return NoContent(); //204
                    }
                    //Admin
                    else
                    {
                        return Ok();  //200
                    }
                                     
                    //return RedirectToAction("TrangChu", "TrangChu");
                }
                else
                {
                    return BadRequest();
                    //return View();
                }

            }
            catch
            {
                throw new Exception("Đăng nhập không thành công");
            }
        }

        //4. httpPut để chỉnh sửa thông tin một khách hàng
        [HttpPut]
        public bool UpdateProfile(string makhach, string hovaten, string sodienthoai, string diachi, string email, string gioitinh, DateTime ngaysinh)
        {
            BtlWebContext dbCustomer = new BtlWebContext();
            //Lấy mã khách đã có
            KhachHang customer = dbCustomer.KhachHangs.FirstOrDefault(x => x.IdkhachHang == makhach);
            if (customer == null) return false;
            //customer.Makhach = id;
            customer.TenKhachHang = hovaten;
            customer.SoDienThoai = sodienthoai;
            customer.DiaChi = diachi;
            customer.Email = email;
            customer.GioiTinh = gioitinh;
            customer.NgaySinh = ngaysinh;
            dbCustomer.SaveChanges();
            return true;
        }
    }
}
