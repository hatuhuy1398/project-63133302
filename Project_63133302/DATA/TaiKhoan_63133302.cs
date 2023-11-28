using Project_63133302.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Project_63133302.DATA
{
	public class TaiKhoan_63133302
	{
		Project_63133302Entities db = new Project_63133302Entities();

		public bool DangKy(KhachHang kh)
		{
			var KiemTraTaiKhoan = db.KhachHangs.Where(m => m.TaiKhoan.ToLower() == kh.TaiKhoan.ToLower()).FirstOrDefault();
			if (KiemTraTaiKhoan != null)
			{
				return false;
			}

			var newKH = new KhachHang();
			newKH.TaiKhoan = kh.TaiKhoan.ToLower();
			newKH.MatKhau = kh.MatKhau;
			newKH.Ho = kh.Ho;
			newKH.Ten = kh.Ten;
			newKH.NgaySinh = DateTime.Now;
			newKH.NgayTao = DateTime.Now;
			newKH.GioiTinh = true;
			db.KhachHangs.Add(newKH);
			db.SaveChanges();
			var idKhNew = db.KhachHangs.ToList().LastOrDefault();
			var xuLyGiohang = new GioHang_63133302();
			xuLyGiohang.TaoGiohang(idKhNew.Id);


			return true;
		}

		public KhachHang DangNhap(string email, string pass)
		{
			var kh = db.KhachHangs.Where(m => m.TaiKhoan.ToLower() == email.ToLower() & m.MatKhau == pass).FirstOrDefault();
			if (kh == null)
			{
				return null;
			}
			return kh;
		}

		public TaiKhoanAdmin DangNhapAdmin(string email, string pass)
		{
			var admin = db.TaiKhoanAdmins.Where(m => m.TaiKhoan.ToLower() == email.ToLower() & m.MatKhau == pass).FirstOrDefault();
			if (admin == null)
			{
				return null;
			}
			return admin;
		}

		public KhachHang CapNhatTaiKhoan(KhachHang kh)
		{
			var newkh = db.KhachHangs.Find(kh.Id);
			if(newkh == null)
			{
				return null;
			}
			newkh.Ho = kh.Ho;
			newkh.Ten = kh.Ten;
			newkh.GioiTinh = kh.GioiTinh;
			newkh.NgaySinh = kh.NgaySinh;
			newkh.Sdt = kh.Sdt;
			newkh.DiaChi = kh.DiaChi;
			db.SaveChanges();
			return newkh;
		}

		public List<KhachHang> LayDanhSachKhachHang()
		{
			var ds = db.KhachHangs.ToList();
			return ds;
		}
	}
}