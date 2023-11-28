using Project_63133302.DATA;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Project_63133302.App_Start;
using Project_63133302.Models;

namespace Project_63133302.Controllers
{
	public class Home_63133302Controller : Controller
	{
		
		public ActionResult Index()
		{
			var xuLySanPham = new SanPham_63133302();
			var danhsach = xuLySanPham.LayDanhSachSanPham().Take(4).ToList();
			return View(danhsach);
		}

		[CheckUser]
		public ActionResult GioHang()
		{
			KhachHang user = SessionConfig.GetUser();
			var xuLyGioHang = new GioHang_63133302();
			var idGH = xuLyGioHang.LayGioHang(user.Id).Id;

			var ds = xuLyGioHang.LaySanPhamTuGioHang(idGH);
			return View(ds);	
		}

		[CheckUser]
		[HttpPost]
		public ActionResult ThemSanPhamVaoGioHang(SanPhamGioHang sp)
		{
			KhachHang user = SessionConfig.GetUser();

			var xuLyGioHang = new GioHang_63133302();

			sp.IdGH = xuLyGioHang.LayGioHang(user.Id).Id;
			xuLyGioHang.ThemSanPhamVaoGioHang(sp);

			return RedirectToAction("GioHang");
		}
		[CheckUser]
		[HttpPost]
		public ActionResult XoaSanPhamTrongGioHang(int id)
		{
			var xuLyGioHang = new GioHang_63133302();
			xuLyGioHang.XoaSanPhamKhoiGioHang(id);
			return RedirectToAction("GioHang");
		}
	}
}