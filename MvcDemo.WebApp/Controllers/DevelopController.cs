using System;
using System.Web;
using System.Web.Mvc;

namespace MvcDemo.WebApp.Controllers
{
	[Authorize(Roles = "DevelopAdmin")]
	public class DevelopController : Controller
	{

		public ActionResult Index() { return RedirectToAction("BootstrapOverview"); }
		public ActionResult BootstrapOverview() { return View(); }
		public ActionResult Dialog() { return View(); }
		public ActionResult DialogShow() { return View(); }
		public ActionResult Icons() { return View(); }
		public ActionResult IconsExamples() { return View(); }
		public ActionResult SampleForm() { return View(); }
		public ActionResult SampleList1() { return View(); }
		public ActionResult SampleList2() { return View(); }
		public ActionResult SampleList3() { return View(); }
		public ActionResult SampleList4() { return View(); }
		public ActionResult WhereBuilder() { return View(); }

		public ActionResult SampleExcel(string output)
		{
			string filename = HttpUtility.UrlEncode($"SampleExcel-{DateTime.Now:yyyyMMddHHmmss}.xls");

			ViewBag.Layout = "~/Views/shared/_ExcelLayout.cshtml";
			Response.ContentType = "application/octet-stream";
			Response.AddHeader("Content-Disposition", "attachment; filename*=UTF-8''" + filename);
			return View();
		}



	}
}