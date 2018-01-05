using System.Web.Mvc;

namespace MvcDemo.WebApp.Controllers
{
	[AllowAnonymous]
	public class ErrorController : Controller
	{

		protected override void OnActionExecuted(ActionExecutedContext filterContext)
		{
			Response.TrySkipIisCustomErrors = true;
		}


		public ActionResult Forbidden()
		{
			Response.StatusCode = 403;
			ViewBag.Title = "權限不足無法執行！";
			ViewBag.Message = "抱歉！您的帳號權限無法觀看此頁面，請回上一頁，或前往其他頁面。";
			ViewBag.Color = "#f4b04f";
			ViewBag.OOPS = "OOPS!";

			return View("../Shared/Error");
		}

		public ActionResult NotFound()
		{
			Response.StatusCode = 404;
			ViewBag.Title = "網址頁面並不存在！";
			ViewBag.Message = "抱歉！您所指定的網址的頁面並不存在，請回上一頁，或前往其他頁面。";
			ViewBag.Color = "#f4b04f";
			ViewBag.OOPS = "OOPS!";

			return View("../Shared/Error");
		}


		public ActionResult ServerError()
		{
			Response.StatusCode = 500;
			ViewBag.Title = "伺服器發生錯誤！";
			ViewBag.Message = "抱歉！伺服器發生錯誤，請回上一頁，或前往其他頁面。";
			ViewBag.Color = "#e66454";
			ViewBag.OOPS = "OUCH!";

			return View("../Shared/Error");
		}



	}
}
