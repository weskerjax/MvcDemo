using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using MvcDemo.Domain;
using MvcDemo.Domain.Enums;
using MvcDemo.WebApp.Models;
using Orion.API;
using Orion.API.Extensions;
using Orion.API.Models;
using Orion.Mvc.Attributes;
using Orion.Mvc.Extensions;
using Orion.Mvc.Security;

namespace MvcDemo.WebApp.Controllers
{
	[ActAuthorize(ACT.UserSetting)]
	public class UserController : Controller
	{
		public ISmsServiceContext Svc { get; set; }


		protected override void OnActionExecuted(ActionExecutedContext filterContext)
		{			 
		}




		public ActionResult Index()
		{
			return RedirectToAction(nameof(List));
		}





		public ActionResult List(PageParams<UserSort?> pageParams, string keyword = null)
		{
			Pagination<UserDomain> domainPage = Svc.User.GetPagination(keyword, pageParams);
			ViewBag.Pagination = domainPage;

			return View();
		}


		public ActionResult Typeahead(string query)
		{

			Pagination<UserDomain> domainPage = Svc.User.GetPagination(query, new PageParams<UserSort?>
			{
				PageIndex  = 1,
				PageSize   = 40,
				OrderField = UserSort.UserName, 
				Descending = false,
			});

			var list = domainPage.List
				.Where(x => x.UserId != 1)
				.Select(x => new
				{ 
					Value = x.UserId,
					Label = x.UserName + " " + x.Account,
				});
			return Json(list);
		}




		[HttpGet]
		[UseViewPage("Form")]
		public ActionResult Create()
		{
			var vm = new UserViewModel
			{
				RoleIds = new List<int>(),
			};

			return View(vm);
		}


		[HttpPost]
		[UseViewPage("Form")]
		public ActionResult Create(UserViewModel vm)
		{
			if (!ModelState.IsValid) { return View(vm); }

			var domain = vm.MappingModel<UserViewModel, UserDomain>();
			domain.ModifyBy = User.Identity.GetUserId();


			int userId = Svc.User.Save(domain);
			this.SetStatusSuccess("儲存成功!!");
			return RedirectToAction(nameof(Edit), new { userId });
		}



		public ActionResult IsAccountNotExist(string account)
		{
			bool notExists = false;
			try
			{
				Svc.User.GetByAccount(account);            
			}
			catch (OrionException) 
			{ 
				notExists = true;
			}

			return Json(notExists, JsonRequestBehavior.AllowGet);
		}




		[HttpGet]
		[UseViewPage("Form")]
		public ActionResult Edit(int userId)
		{
			ViewBag.HoldActList = Svc.User.GetHoldActList(userId);

			UserDomain domain = Svc.User.GetById(userId);

			var vm = domain.MappingModel<UserDomain, UserViewModel>();

			return View(vm);
		}



		[HttpPost]
		[UseViewPage("Form")]
		public ActionResult Edit(UserViewModel vm)
		{
			ViewBag.HoldActList = Svc.User.GetHoldActList(vm.UserId);

			if (!ModelState.IsValid) { return View(vm); }

			var domain = vm.MappingModel<UserViewModel, UserDomain>();
			domain.ModifyBy = User.Identity.GetUserId();


			int userId = Svc.User.Save(domain);
			this.SetStatusSuccess("儲存成功!!");
			return RedirectToAction(nameof(Edit), new { userId });
		}




		public ActionResult SetPassword(UserSetPasswordViewModel vm)
		{
			if (Request.HttpMethod != "POST") { return View(vm); }
			if (!ModelState.IsValid) { return View(vm); }

			Svc.User.SetPassword(vm.UserId, vm.Password);
			this.SetStatusSuccess("儲存成功!!");
			return View(vm);
		}





		[HttpGet]
		[ActAuthorize(ACT.UserActSetting)]
		public ActionResult ActEdit(int userId)
		{
			UserActDomain domain = Svc.User.GetSelfAct(userId);

			var vm = domain.MappingModel<UserActDomain, UserActViewModel>();

			return View(vm);
		}


		[HttpPost]
		[ActAuthorize(ACT.UserActSetting)]
		public ActionResult ActEdit(UserActViewModel vm)
		{

			var domain = vm.MappingModel<UserActViewModel, UserActDomain>();
			domain.ModifyBy = User.Identity.GetUserId();


			Svc.User.SetSelfAct(domain);
			this.SetStatusSuccess("儲存成功!!");
			return RedirectToAction(nameof(ActEdit), new { vm.UserId });
		}





	}
}