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


        [HttpGet]
        public List<TaiKhoan> GetCustomerLists()
        {
            return db.TaiKhoans.ToList();
        }

        [HttpGet("{maloai}")]
        public TaiKhoan GetBy(string maLoai)
        {
            return db.TaiKhoans.FirstOrDefault(x => x.TaiKhoan1 == maLoai);
        }

        //[HttpPost]
        //public bool DangKy(string taikhoan1, string matkhau, string maloaitaikhoan, string idkhachhang, 
        //    string tenkhachhang, string ngaysinh, string sodienthoai, string diachi, string email, 
        //    string gioitinh, string taikhoan2)
        //{
        //    try
        //    {
        //        var checkUsernameExsit = db.TaiKhoans.FirstOrDefault(x=>x.TaiKhoan1==taikhoan1);
        //        //Tai khoan da ton tai
        //        if(checkUsernameExsit != null)
        //        {
        //            return false;
        //        }
        //        else
        //        {
        //            TaiKhoan taikhoan = new TaiKhoan();
        //            taikhoan.TaiKhoan1 = taikhoan1;
        //            taikhoan.MatKhau = matkhau;
        //            taikhoan.MaLoaiTaiKhoan = maloaitaikhoan;

        //            db.TaiKhoans.AddAsync(taikhoan);
        //            db.SaveChanges();

        //            return true;
        //        }

        //    }
        //    catch
        //    {
        //        throw new Exception("Đăng kí không thành công"); 
        //    }
        //}

        [HttpPost]
        [Route("DangKy")]
        public async Task<IActionResult> DangKy([FromBody] TaiKhoanIn4Model taikhoan)
        {
            try
            {
                var checkUsernameExsit = db.TaiKhoans.FirstOrDefault(x => x.TaiKhoan1 == taikhoan.Username);
                //Tai khoan da ton tai
                if (checkUsernameExsit != null)
                {
                    return BadRequest();
                }
                else
                {
                    try
                    {
                        await _userInforService.Register(taikhoan);
                        return Ok();
                    }
                    catch
                    {
                        throw new Exception("hhh");
                    }
                }

            }
            catch
            {
                throw new Exception("Đăng kí không thành công");
            }
        }


        [HttpPost]
        [Route("DangNhap")]
        public IActionResult DangNhap([FromBody] TaiKhoanOnlyModel taikhoan)
        {
            try
            {
                var checkUsernameExsit = db.TaiKhoans.FirstOrDefault(x => x.TaiKhoan1 == taikhoan.Username && x.MatKhau == taikhoan.Password 
                && x.MaLoaiTaiKhoan == taikhoan.AccountType);
                //Tai khoan da ton tai
                if (checkUsernameExsit != null)
                {
                    return Ok();                   
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
    }
}
