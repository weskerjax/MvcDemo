using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Reflection;
using System.ServiceModel;
using System.ServiceModel.Configuration;
using System.Web;
using System.Web.Mvc;
using Autofac;
using Autofac.Integration.Mvc;
using Autofac.Integration.Wcf;
using MvcDemo.Dao.Database;
using Orion.API;
using Orion.Mvc.Security;
using Orion.Mvc.UI;

namespace MvcDemo.WebApp
{
	public static class AutofacConfig
	{

		public static void Bootstrapper()
		{
			var builder = new ContainerBuilder();

			builder.RegisterType<SmsDataContext>().InstancePerLifetimeScope();


			var server = HttpContext.Current.Server;
			builder.RegisterInstance(new MenuProvider(server.MapPath("~/Menu.config")));
			builder.RegisterInstance(new BreadcrumbProvider(server.MapPath("~/Breadcrumb.config")));
			builder.RegisterType<OptionItemsProvider>().InstancePerRequest();
			builder.RegisterType<SmsServiceContext>().AsImplementedInterfaces().InstancePerRequest();


			builder.RegisterType<PasswordSHA256Handle>().As<IPasswordHandle>();
			builder.RegisterType<SignInStoreSession>().As<ISignInStore>();
			builder.RegisterType<SignInManager>().As<ISignInManager>();
			builder.RegisterType<OrionNLogLogger>().As<IOrionLogger>();
			 


			/* DAO, Service */
			builder.RegisterAssemblyTypes(Assembly.Load("MvcDemo.Dao"))
				   .Where(t => t.Name.EndsWith("Dao"))
				   .AsImplementedInterfaces();

			builder.RegisterAssemblyTypes(Assembly.Load("MvcDemo.Service.Impl"))
				   .Where(t => t.Name.EndsWith("Service"))
				   .AsImplementedInterfaces();



			var asm = Assembly.GetExecutingAssembly();


			// Register MVC controllers.
			builder.RegisterControllers(asm).PropertiesAutowired();


			// OPTIONAL: Register model binders that require DI.
			//builder.RegisterModelBinders(asm);
			//builder.RegisterModelBinderProvider();

			// OPTIONAL: Register web abstractions like HttpContextBase.
			//builder.RegisterModule<AutofacWebTypesModule>();

			// OPTIONAL: Enable property injection in view pages.
			//builder.RegisterSource(new ViewRegistrationSource());

			// OPTIONAL: Enable property injection into action filters.
			//builder.RegisterFilterProvider();



			// 指定解析器
			var container = builder.Build();

			/* 指定解析器 */
			DependencyResolver.SetResolver(new AutofacDependencyResolver(container));

			/* 指定 WCF 解析器 */
			AutofacHostFactory.Container = container;
		}




		public static void RegisterWcfByConfig(this ContainerBuilder builder, params Assembly[] assemblies)
		{
			List<Type> allTypes = assemblies.SelectMany(asm => asm.GetTypes()).ToList();

			MethodInfo regMethod = typeof(AutofacConfig).GetMethods().First(m => m.Name == "RegisterWcf");

			string xpath = "system.serviceModel/client";
			var section = (ClientSection)ConfigurationManager.GetSection(xpath);

			foreach (ChannelEndpointElement item in section.Endpoints)
			{
				Type svcType = allTypes.FirstOrDefault(t => t.FullName == item.Contract);
				if (svcType == null) { throw new Exception("找不到類型 " + item.Contract); }

				MethodInfo method = regMethod.MakeGenericMethod(svcType);
				method.Invoke(null, new object[] { builder, item.Name });
			}
		}



		public static void RegisterWcf<TService>(this ContainerBuilder builder, string endpointConfig)
		{
			builder.Register(c => new ChannelFactory<TService>(endpointConfig))
				   .SingleInstance();

			builder.Register(c => c.Resolve<ChannelFactory<TService>>().CreateChannel())
				   .As<TService>()
				   .UseWcfSafeRelease();
		}

	}

}