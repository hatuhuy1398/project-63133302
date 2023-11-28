using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using Project_63133302.Models;

namespace Project_63133302.DATA
{
	public class SanPham_63133302
	{
		Project_63133302Entities db = new Project_63133302Entities();	

		public List<SanPham> LayDanhSachSanPham()
		{
			var danhsach = db.SanPhams.ToList();
			return danhsach;
		}

		public SanPham LayChiTietSanPham(int id)
		{
			var sp = db.SanPhams.Find(id);
			return sp;
		}
		public void XoaSanSanPham(int id)
		{
			var sp = db.SanPhams.Find(id);
			db.SanPhams.Remove(sp);
			db.SaveChanges();
		}

		public List<SanPham> LayDanhSachSanPhamTheoDanhMuc(int id)
		{
			var danhsach = db.SanPhams.ToList();
			danhsach = danhsach.Where(m => m.IdDanhMuc == id).ToList();
			return danhsach;
		}
		public void ThemMoiSanPham(SanPham sp)
		{
			var newSp = new SanPham();
			newSp.TenSP = sp.TenSP;
			newSp.MoTa = sp.MoTa;
			newSp.IdDanhMuc = sp.IdDanhMuc;
			newSp.SoLuong = sp.SoLuong;
			newSp.Gia = sp.Gia;
			newSp.Anh = sp.Anh;
			db.SanPhams.Add(newSp); 
			db.SaveChanges();

		}

		public void ChinhSuaSanPham(SanPham sp, int id)
		{
			var newSp = db.SanPhams.Find(id);
			if(newSp == null)
			{
				return;
			}	
			newSp.TenSP = sp.TenSP;
			newSp.MoTa = sp.MoTa;
			newSp.IdDanhMuc = sp.IdDanhMuc;
			newSp.SoLuong = sp.SoLuong;
			newSp.Gia = sp.Gia;
			newSp.Anh = sp.Anh;
			db.SaveChanges();
		}

		public void XoaSanPham(int id)
		{
			var sp = db.SanPhams.Find(id);
			if(sp == null)
			{
				return;
			}
			db.SanPhams.Remove(sp);
			db.SaveChanges();
		}
	}
}