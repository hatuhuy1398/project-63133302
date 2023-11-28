using Project_63133302.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Project_63133302.DATA
{
	public class DanhMuc_63133302
	{
		Project_63133302Entities db = new Project_63133302Entities();

		public List<DanhMuc> LayDanhSachDanhMuc()
		{
			return db.DanhMucs.ToList();
		}

	}
}