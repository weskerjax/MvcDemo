using System.Collections.Generic;
using System.Web.Mvc;
using System.Web.SessionState;
using MvcDemo.Domain;
using MvcDemo.WebApp.Models;
using Orion.API;
using Orion.Mvc.Security;
using Orion.Mvc.UI;

namespace MvcDemo.WebApp.Controllers
{
	[SessionState(SessionStateBehavior.Required)]
	public class HomeController : Controller
	{
		public MenuProvider MenuProvider { get; set; }
		public BreadcrumbProvider BreadcrumbProvider { get; set; }
		public ISignInManager SignInManager { get; set; }
		public ISmsServiceContext Svc { get; set; }

		private int _userId = -1;




		protected override void OnActionExecuting(ActionExecutingContext filterContext)
		{
			_userId = User.Identity.GetUserId();
		}



		public ActionResult Index()
		{
			return View();
		}





		[HttpGet]
		[AllowAnonymous]
		public ActionResult Login()
		{
			/*排除以登入沒有權限*/
			if (User.Identity.IsAuthenticated)
			{
				return RedirectToAction("Forbidden", "Error");
			}

			/*排除 Ajax*/
			if (Request.IsAjaxRequest())
			{
				Response.TrySkipIisCustomErrors = true;
				Response.StatusCode = 403;
				return Content("請登入系統!!");
			}


			var vm = new UserLoginViewModel();

			return View(vm);
		}



		[HttpPost]
		[AllowAnonymous]
		[ValidateAntiForgeryToken]
		public ActionResult Login(UserLoginViewModel vm, string returnUrl)
		{

			if (!ModelState.IsValid) { return View(vm); }

			int userId;
			try
			{
				userId = Svc.User.CheckPassword(vm.Account, vm.Password);
				Svc.User.AddSignInRecord(
					vm.Account,
					Request.UserHostAddress,
					"site",
					"success",
					string.Empty
				);
			}
			catch (OrionException ex)
			{
				Svc.User.AddSignInRecord(
					vm.Account,
					Request.UserHostAddress,
					"site",
					"error",
					ex.Message
				);
				throw ex;
			}



			UserDomain user = Svc.User.GetById(userId);
			IList<string> actList = Svc.User.GetHoldActList(userId);

			var identity = new OrionUserIdentity
			{
				UserId = userId,
				UserName = user.UserName,
				Account = user.Account,
				Name = user.Account,
			};
			SignInManager.SignIn(identity, actList);


			if (string.IsNullOrWhiteSpace(returnUrl))
			{
				returnUrl = Url.Action("Index", "Home");
			}
			return Redirect(returnUrl);
		}




		[HttpPost]
		public ActionResult Logout()
		{
			SignInManager.SignOut();
			return RedirectToAction("Login");
		}




		public ActionResult ChangePassword(UserChangePasswordViewModel vm)
		{
			if (Request.HttpMethod != "POST") { return View(vm); }
			if (!ModelState.IsValid) { return View(vm); }

			Svc.User.CheckPassword(User.Identity.GetAccount(), vm.OldPassword);
			Svc.User.SetPassword(User.Identity.GetUserId(), vm.Password);

			TempData["StatusSuccess"] = "儲存成功!!";
			return View(vm);
		}






		/*=================================================================*/

		[ChildActionOnly]
		public ActionResult Navbar()
		{
			return PartialView();
		}


		[ChildActionOnly]
		public ActionResult Sidebar()
		{
			var vm = MenuProvider.GetAllowList(User, Request.Url.PathAndQuery);
			return PartialView(vm);
		}

		[ChildActionOnly]
		public ActionResult Breadcrumb()
		{
			var vm = BreadcrumbProvider.GetPathList(Request.Url.LocalPath);
			return PartialView(vm);
		}






	}
}
