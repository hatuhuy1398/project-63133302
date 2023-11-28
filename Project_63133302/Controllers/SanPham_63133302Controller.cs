using Project_63133302.DATA;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Project_63133302.Controllers
{
    public class SanPham_63133302Controller : Controller
    {



        // GET: SanPham_63133302
        public ActionResult Index(string name = "")
        {
            var xuLySanPham = new SanPham_63133302();
            var ds = xuLySanPham.LayDanhSachSanPham();
            if (!String.IsNullOrEmpty(name))
            {
				ds = ds.Where(m => m.TenSP.ToLower().Contains(name.ToLower())).ToList();

			}
            
			return View(ds);
        }
        public ActionResult Details(int id)
        {

            var xuLySanPham = new SanPham_63133302();
            var sanpham = xuLySanPham.LayChiTietSanPham(id);
			return View(sanpham);
        }
    }
}