using Project_63133302.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Project_63133302.DATA
{
	public class PhuongThuc_63133302
	{
		Project_63133302Entities db = new Project_63133302Entities();

		public List<PhuongThuc> LayDanhSachPhuongThuc()
		{
			return db.PhuongThucs.ToList();
		}

	}
}