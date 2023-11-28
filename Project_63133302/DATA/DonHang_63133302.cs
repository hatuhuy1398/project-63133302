using Project_63133302.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace Project_63133302.DATA
{
	public class DonHang_63133302
	{
		Project_63133302Entities db = new Project_63133302Entities();
		public void ThemDonHang(DonHang dh, int idGH)
		{
			var xuLyGioHang = new GioHang_63133302();
			var newDh = new DonHang();
			newDh.IdKH = dh.IdKH;
			newDh.IdPT = dh.IdPT;
			newDh.Ten = dh.Ten;
			newDh.TrangThai = "đang giao";
			newDh.DienThoai = dh.DienThoai;
			newDh.DiaChi = dh.DiaChi;
			newDh.GhiChuDonHang = dh.GhiChuDonHang;
			newDh.NgayTaoDon = DateTime.Now;
			var a = db.SanPhamGioHangs.Where(m => m.IdGH == idGH).Sum(m => m.SanPham.Gia * m.SoLuong);
			var b= db.PhuongThucs.Find(dh.IdPT);
			newDh.TongTienThanhToan = a + b.PhiVanChuyen;
			db.DonHangs.Add(newDh);
			db.SaveChanges();
			//giai thich
			ThemSanPhamDonHang(idGH, newDh.Id);
			xuLyGioHang.XoaGioHang(idGH);
			db.SaveChanges();
		}
		// giaithich
		public void ThemSanPhamDonHang(int idGH, int idDH)
		{

			var newDH = new DonHang();
			GioHang_63133302 map = new GioHang_63133302();
			var dsSP = map.LaySanPhamTuGioHang(idGH);
			List<SanPhamDonHang> listSp = new List<SanPhamDonHang>();
			foreach (var sp in dsSP)
			{
				if (db.SanPhams.Find(sp.IdSP).SoLuong - sp.SoLuong < 0)
				{
					continue;
				}
				db.SanPhams.Find(sp.IdSP).SoLuong = (int)(db.SanPhams.Find(sp.IdSP).SoLuong - sp.SoLuong);
				SanPhamDonHang spdh = new SanPhamDonHang();
				spdh.IdSP = sp.IdSP;
				spdh.IdDonHang = idDH;
				spdh.TenSP = sp.SanPham.TenSP;
				spdh.Anh = sp.SanPham.Anh;
				spdh.DanhMuc = sp.SanPham.DanhMuc.Ten;
				spdh.SoLuong = sp.SoLuong;
				spdh.Gia = sp.SanPham.Gia;
				listSp.Add(spdh);
			}
			db.SanPhamDonHangs.AddRange(listSp);
			db.SaveChanges();
		}

		public List<DonHang> LayDanhSachDonhang(int idKH)
		{
			var ds = db.DonHangs.Where(m => m.IdKH == idKH).ToList();
			return ds;
		}
		public List<DonHang> LayDanhSachTatCaDonhang()
		{
			var ds = db.DonHangs.ToList();
			return ds;
		}

		public DonHang LayChiTietDonHang(int id)
		{
			var dh = db.DonHangs.Find(id);
			return dh;
		}

		public List<SanPhamDonHang> LayDanhSachSanPhamDonHang(int idDh)
		{
			var ds = db.SanPhamDonHangs.Where(m => m.IdDonHang == idDh).ToList();
			return ds;
		}

		public void XoaDonHang(int id)
		{
			var dh = db.DonHangs.Find(id);
			if (dh == null)
			{
				return;
			}
			db.DonHangs.Remove(dh);
			db.SaveChanges();
		}
	}
}