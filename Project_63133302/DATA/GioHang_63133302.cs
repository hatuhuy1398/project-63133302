using Project_63133302.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Project_63133302.DATA
{
	public class GioHang_63133302
	{
		Project_63133302Entities db = new Project_63133302Entities();

		public GioHang TaoGiohang(int idKH)
		{
			var newGH = new GioHang();
			newGH.IdKH = idKH;
			newGH.NgayCapNhat = DateTime.Now;
			db.GioHangs.Add(newGH);
			db.SaveChanges();
			return newGH;
		}

		public GioHang LayGioHang(int idKH)
		{
			var GioHang = db.GioHangs.Where(m => m.IdKH == idKH).FirstOrDefault();
			return GioHang;
		}


		public void ThemSanPhamVaoGioHang(SanPhamGioHang sp)
		{
			var KiemTraSp = db.SanPhamGioHangs.Where(m => m.IdSP == sp.IdSP).FirstOrDefault();
			if (KiemTraSp != null)
			{
				KiemTraSp.SoLuong += sp.SoLuong;
			}
			else
			{
				var newSp = new SanPhamGioHang();
				newSp.IdSP = sp.IdSP;
				newSp.IdGH = sp.IdGH;
				newSp.SoLuong = sp.SoLuong;
				newSp.NgayThem = DateTime.Now;
				db.SanPhamGioHangs.Add(newSp);

			}
			db.SaveChanges();
		}

		public List<SanPhamGioHang> LaySanPhamTuGioHang(int idGH)
		{
			var ds = db.SanPhamGioHangs.Where(m => m.IdGH == idGH).ToList();

			return ds;
		}

		public void XoaSanPhamKhoiGioHang(int id)
		{
			var sp = db.SanPhamGioHangs.Find(id);
			db.SanPhamGioHangs.Remove(sp);
			db.SaveChanges();
		}
		public void XoaGioHang(int idGH)
		{
			var ds = db.SanPhamGioHangs.Where(m => m.IdGH == idGH).ToList() ;
			db.SanPhamGioHangs.RemoveRange(ds);
			db.SaveChanges() ;	
		}
	
	}
}