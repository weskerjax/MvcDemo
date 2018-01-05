using System;
using System.Web.Mvc;

namespace MvcDemo.WebApp
{
	public static class WebAppExtensions
	{ 


		/// <summary></summary>
		public static T Items<T>(this HtmlHelper helper, Func<OptionItemsProvider, T> selector)
		{
			OptionItemsProvider provider = helper.ViewBag.OptionItemsProvider;
			if (provider == null)
			{
				provider = DependencyResolver.Current.GetService<OptionItemsProvider>();
				helper.ViewBag.OptionItemsProvider = provider;
			}

			return selector(provider);
		}


	}
}