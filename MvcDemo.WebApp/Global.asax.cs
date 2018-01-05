using Orion.API;
using Orion.Mvc.ModelBinder;
using Orion.Mvc.Security;
using MvcDemo.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using System.Web.Routing;
using System.Net;
using Orion.Mvc;

namespace MvcDemo.WebApp
{

	public class MvcApplication : System.Web.HttpApplication
	{
		protected void Application_Start()
		{   
			/* 忽略檢查憑證 */
			ServicePointManager.ServerCertificateValidationCallback = (sender, certificate, chain, sslPolicyErrors) => true;

			AutofacConfig.Bootstrapper();
			FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
			RouteConfig.RegisterRoutes(RouteTable.Routes);

			ModelBinders.Binders.Add(typeof(string), new StringTrimModelBinder());
			ModelBinderProviders.BinderProviders.Add(new WhereParamsModelBinderProvider());

			var currentFactory = ControllerBuilder.Current.GetControllerFactory();
			ControllerBuilder.Current.SetControllerFactory(new SessionStateControllerFactory(currentFactory));
		}


		protected void Application_BeginRequest(object sender, EventArgs e)
		{
			/*多國語言處理*/
			CultureHandle.Handle(Request);
		}


		protected void Application_PostRequestHandlerExecute(object sender, EventArgs e)
		{
			/* 攔截權限不足 */
			if (Response.StatusCode != 401) { return; }
			if (!User.Identity.IsAuthenticated) { return; }

			Context.Server.TransferRequest("/Error/Forbidden", true);
		}


		protected void Application_Error(object sender, EventArgs e)
		{
			/* 當錯誤發生時清除 Elmah 的舊紀錄 */
			OrionElmahUtils.ClearOldXmlLog();
		}


		protected void Application_AcquireRequestState(object sender, EventArgs e)
		{
			var signInManager = DependencyResolver.Current.GetService<ISignInManager>();

#if DEBUG
			/*開發時自動登入*/
			try
			{
				IList<string> actList = OrionUtils.EnumToDictionary<ACT>().Keys.ToList();
				actList.Add("DevelopAdmin");
				signInManager.DevelopSignIn(actList);
			}
			catch (Exception) { }
#endif

			signInManager.Authenticate(Context);
		}


	}
}
