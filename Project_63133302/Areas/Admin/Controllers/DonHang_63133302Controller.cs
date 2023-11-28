using Project_63133302.App_Start;
using Project_63133302.DATA;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Project_63133302.Areas.Admin.Controllers
{
    public class DonHang_63133302Controller : Controller
    {
		// GET: Admin/DonHang_63133302
		[CheckAdmin]

		public ActionResult Index()
        {
            var xuLyDonHang = new DonHang_63133302();
            var ds = xuLyDonHang.LayDanhSachTatCaDonhang();

			return View(ds);
        }
		[CheckAdmin]

		public ActionResult ChiTietDonHang(int id)
        {
			var xuLyDonHang = new DonHang_63133302();
			var dh = xuLyDonHang.LayChiTietDonHang(id);
			return View(dh);
		}
		[CheckAdmin]

		public ActionResult XoaDonHang(int Id)
		{
			var xuLyDonHang = new DonHang_63133302();
			var dh = xuLyDonHang.LayChiTietDonHang(Id);
			return View(dh);
		}
		[CheckAdmin]

		[HttpPost, ActionName("XoaDonHang")]
		public ActionResult XacNhanXoa(int Id)
		{

			var xuLyDonHang = new DonHang_63133302();
			xuLyDonHang.XoaDonHang(Id);
			return RedirectToAction("Index");
		}
	}
}