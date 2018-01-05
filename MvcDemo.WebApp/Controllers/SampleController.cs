using System.Linq;
using System.Web.Mvc;
using Orion.API.Extensions;
using Orion.API.Models;

namespace ZigSheng.PFMS.WebApp.Controllers
{
	public class SampleController : Controller
	{

		protected override void HandleUnknownAction(string actionName)
		{
			Pagination<string> page = new string[20].ToList().AsPagination(1, 10);
			page.TotalItems = 200;
			ViewBag.Pagination = page;



			View(actionName).ExecuteResult(ControllerContext);
		}

	}

}