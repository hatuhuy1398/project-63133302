using Project_63133302.App_Start;
using Project_63133302.DATA;
using Project_63133302.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Project_63133302.Areas.Admin.Controllers
{
	public class SanPham_63133302Controller : Controller
	{
		// GET: Admin/SanPham_63133302
		[CheckAdmin]

		public ActionResult Index()
		{
			var xuLySanPham = new SanPham_63133302();
			var ds = xuLySanPham.LayDanhSachSanPham();
			return View(ds);
		}
		[CheckAdmin]

		public ActionResult ThemMoiSanPham()
		{
		
			return View();
		}
		[CheckAdmin]

		[HttpPost]
		public ActionResult ThemMoiSanPham(SanPham sp)
		{
			var xuLySanPham = new SanPham_63133302();
			xuLySanPham.ThemMoiSanPham(sp);
			return RedirectToAction("Index");
		}
		[CheckAdmin]

		public ActionResult ChinhSuaSanPham(int id)
		{
			var xuLySanPham = new SanPham_63133302();
			var sp = xuLySanPham.LayChiTietSanPham(id);
			return View(sp);
		}
		[CheckAdmin]

		[HttpPost]
		public ActionResult ChinhSuaSanPham(SanPham sp)
		{
			var xuLySanPham = new SanPham_63133302();
			xuLySanPham.ChinhSuaSanPham(sp, sp.Id);
			return RedirectToAction("Index");
		}

		[CheckAdmin]

		public ActionResult XoaSanPham(int Id)
		{
			var xuLySanPham = new SanPham_63133302();
			var sp = xuLySanPham.LayChiTietSanPham(Id);
			return View(sp);
		}

		[CheckAdmin]

		[HttpPost, ActionName("XoaSanPham")]
		public ActionResult XacNhanXoa(int Id)
		{

			var xuLySanPham = new SanPham_63133302();
			xuLySanPham.XoaSanSanPham(Id);
			return RedirectToAction("Index");
		}

	}
}

