using Project_63133302.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Project_63133302.App_Start
{
	public class SessionConfig
	{
		//User
		// Lưu session cho user
		public static void SetUser(KhachHang user)
		{
			// lưu vào session
			HttpContext.Current.Session["user"] = user;
		}

		// Lấy session
		public static KhachHang GetUser()
		{
			// lưu vào session
			return (KhachHang)HttpContext.Current.Session["user"];
		}

		// Amin
		public static void SetAdmin(TaiKhoanAdmin admin)
		{
			// lưu vào session
			HttpContext.Current.Session["admin"] = admin;
		}

		// Lấy session
		public static TaiKhoanAdmin GetAdmin()
		{
			// lưu vào session
			return (TaiKhoanAdmin)HttpContext.Current.Session["admin"];
		}
	}
}