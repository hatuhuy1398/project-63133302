using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Project_63133302.App_Start
{
	public class CheckAdmin : AuthorizeAttribute
	{
		public override void OnAuthorization(AuthorizationContext filterContext)
		{
			var Admin = SessionConfig.GetAdmin();
			if (Admin == null)
			{
				//filterContext.HttpContext.Session["ReturnUrlAdmin"] = filterContext.HttpContext.Request.Url.PathAndQuery;
				// Điều hướng về trang đăng nhập
				filterContext.Result = new RedirectToRouteResult(
					new System.Web.Routing.RouteValueDictionary(new
					{
						Controller = "Home_63133302",
						Action = "DangNhap",
						area = "Admin"
					}));
				return;
			}

			return;
		}
	}
}