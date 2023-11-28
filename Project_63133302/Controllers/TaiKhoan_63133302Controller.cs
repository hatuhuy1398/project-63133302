using Project_63133302.App_Start;
using Project_63133302.DATA;
using Project_63133302.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Project_63133302.Controllers
{
    public class TaiKhoan_63133302Controller : Controller
    {
        // GET: TaiKhoan_63133302

        public ActionResult DangNhap()
        {
			var KHSS = SessionConfig.GetUser();
			if (KHSS != null)
			{
				return Redirect("/");
			}
			return View();
        }

		[HttpPost]
		public ActionResult DangNhap(string email, string pass)
		{
			
			var xuLyTaiKhoan = new TaiKhoan_63133302();
			var khachHangDangNhap = xuLyTaiKhoan.DangNhap(email, pass);
			if (khachHangDangNhap != null)
			{
				SessionConfig.SetUser(khachHangDangNhap);
				return Redirect("/");
			}
			ViewBag.error = "Tài Khoản hoặc mật khẩu không đúng";
			return View();

		}
		public ActionResult DangKy()
		{
			var KHSS = SessionConfig.GetUser();
			if (KHSS != null)
			{
				return Redirect("/");
			}
			return View();
		}

        [HttpPost]
		public ActionResult DangKy(KhachHang Kh)
		{
			var xuLyTaiKhoan = new TaiKhoan_63133302();
			if (xuLyTaiKhoan.DangKy(Kh) == true)
			{
				return Redirect("/TaiKhoan_63133302/DangNhap");
			}
			ViewBag.error = "Tài Khoản đã tồn tại trong hệ thống";
			return View();
		}

		[CheckUser]
		public ActionResult DangXuat()
		{
			SessionConfig.SetUser(null);
			return RedirectToAction("DangNhap");
		}

		[CheckUser]
		public ActionResult CaiDat()
		{
			var KHSS = SessionConfig.GetUser();
			return View(KHSS);	
		}

		[HttpPost]
		[CheckUser]
		public ActionResult CapNhatTaiKhoan(KhachHang kh)
		{
			var KHSS = SessionConfig.GetUser();
			var xuLyTaiKhoan = new TaiKhoan_63133302();
			kh.Id = KHSS.Id;
			var newKH = xuLyTaiKhoan.CapNhatTaiKhoan(kh);

			if (newKH != null)
			{
				SessionConfig.SetUser(newKH);
				return RedirectToAction("CaiDat", newKH);
			}
			return RedirectToAction("CaiDat", KHSS);
		}
	}
}