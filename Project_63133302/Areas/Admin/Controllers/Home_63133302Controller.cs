using Project_63133302.App_Start;
using Project_63133302.DATA;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Project_63133302.Areas.Admin.Controllers
{
    public class Home_63133302Controller : Controller
    {
        // GET: Admin/Home_63133302
        [CheckAdmin]
        public ActionResult Index()
        {
            var xuLyTaiKhoan = new TaiKhoan_63133302();
            var ds = xuLyTaiKhoan.LayDanhSachKhachHang();
            return View(ds);
        }

        public ActionResult DangNhap()
        {
			var ADSS = SessionConfig.GetAdmin();
			if (ADSS != null)
			{
				return Redirect("/admin");
			}
			return View();
        }

        [HttpPost]
		public ActionResult DangNhap(string email, string password)
		{
            var xuLyTaiKhoan = new TaiKhoan_63133302();
            var admin = xuLyTaiKhoan.DangNhapAdmin(email, password);
            if(admin != null)
            {
                SessionConfig.SetAdmin(admin);
                return RedirectToAction("Index");
            }
            ViewBag.error = "Tên đăng nhập hoặc mật khẩu không đúng !";
			return View();
		}

		public ActionResult DangXuat()
		{
			SessionConfig.SetAdmin(null);
			return RedirectToAction("/DangNhap");
		}
	}
}