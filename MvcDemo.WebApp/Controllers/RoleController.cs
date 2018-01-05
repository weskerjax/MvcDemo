using System.Collections.Generic;
using System.Web.Mvc;
using Orion.API.Extensions;
using Orion.API.Models;
using Orion.Mvc.Attributes;
using Orion.Mvc.Extensions;
using Orion.Mvc.Security;
using MvcDemo.Domain;
using MvcDemo.Domain.Enums;
using MvcDemo.WebApp.Models;

namespace MvcDemo.WebApp.Controllers
{
	[ActAuthorize(ACT.RoleSetting)]
	public class RoleController : Controller
	{
		public ISmsServiceContext Svc { get; set; }



		protected override void OnActionExecuted(ActionExecutedContext filterContext)
		{ 
		}




		public ActionResult Index()
		{
			return RedirectToAction(nameof(List));
		}



		public ActionResult List(PageParams<RoleSort?> pageParams, string keyword = null)
		{
			Pagination<RoleDomain> domainPage = Svc.Role.GetPagination(keyword, pageParams);			
			ViewBag.Pagination = domainPage;


			return View();
		}



		[HttpGet]
		[UseViewPage("Form")]
		public ActionResult Create()
		{
			var vm = new RoleViewModel
			{
				UserIds = new List<int>(),
			};
			return View(vm);
		}



		[HttpPost]
		[UseViewPage("Form")]
		public ActionResult Create(RoleViewModel vm)
		{
			if (!ModelState.IsValid) { return View(vm); }

			var domain = vm.MappingModel<RoleViewModel, RoleDomain>();
			domain.ModifyBy = User.Identity.GetUserId();

			int roleId = Svc.Role.Save(domain);
			this.SetStatusSuccess("儲存成功!!");
			return RedirectToAction(nameof(Edit), new { roleId });
		}


		[HttpGet]
		[UseViewPage("Form")]
		public ActionResult Edit(int roleId)
		{
			RoleDomain domain = Svc.Role.GetById(roleId);

			var vm = domain.MappingModel<RoleDomain, RoleViewModel>(); 

			return View(vm);
		}



		[HttpPost]
		[UseViewPage("Form")]
		public ActionResult Edit(RoleViewModel vm)
		{
			if (!ModelState.IsValid) { return View(vm); }

			var domain = vm.MappingModel<RoleViewModel, RoleDomain>(); 
			domain.ModifyBy = User.Identity.GetUserId();

			int roleId = Svc.Role.Save(domain);
			this.SetStatusSuccess("儲存成功!!");
			return RedirectToAction(nameof(Edit), new { roleId });
		}


	}
}