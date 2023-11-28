using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Project_63133302.App_Start
{
	public class CheckUser : AuthorizeAttribute
	{
		public override void OnAuthorization(AuthorizationContext filterContext)
		{
			var User = SessionConfig.GetUser();
			if (User == null)
			{
				//filterContext.HttpContext.Session["ReturnUrlUser"] = filterContext.HttpContext.Request.Url.PathAndQuery;
				// Điều hướng về trang đăng nhập
				filterContext.Result = new RedirectToRouteResult(
					new System.Web.Routing.RouteValueDictionary(new
					{
						Controller = "TaiKhoan_63133302",
						Action = "DangNhap",
					}));
				return;
			}

			return;
		}
	}
}