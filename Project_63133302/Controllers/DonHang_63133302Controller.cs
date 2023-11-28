using Project_63133302.App_Start;
using Project_63133302.DATA;
using Project_63133302.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace Project_63133302.Controllers
{
    public class DonHang_63133302Controller : Controller
    {
		// GET: DonHang
		[CheckUser]

		public ActionResult Index()
		{
			KhachHang user = SessionConfig.GetUser();
			var xuLyDonHang= new DonHang_63133302();

			var ds = xuLyDonHang.LayDanhSachDonhang(user.Id);
			return View(ds);
		}


	

		[CheckUser]
		public ActionResult ThanhToan()
        {
			KhachHang user = SessionConfig.GetUser();
			var xuLyGioHang = new GioHang_63133302();
			var idGH = xuLyGioHang.LayGioHang(user.Id).Id;
			var ds = xuLyGioHang.LaySanPhamTuGioHang(idGH);
			return View(ds);
		}

		[HttpPost]
		[CheckUser]
		public ActionResult ThanhToan(DonHang dh, string ho, string ten)
		{
			KhachHang user = SessionConfig.GetUser();
			var xuLyDonHang = new DonHang_63133302();
			var xuLyGioHang = new GioHang_63133302();
			var idGH = xuLyGioHang.LayGioHang(user.Id).Id;
			dh.Ten = ho +" " + ten;
			dh.IdKH = user.Id;
			xuLyDonHang.ThemDonHang(dh, idGH);
			return Redirect("/");
		}

		[CheckUser]
		public ActionResult ChiTietDonHang(int id)
		{
			var xuLyDonHang = new DonHang_63133302();
			var dh = xuLyDonHang.LayChiTietDonHang(id);
			return View(dh);
		}
	}
}