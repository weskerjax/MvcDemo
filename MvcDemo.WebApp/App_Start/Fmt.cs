using System.Web;

namespace MvcDemo.WebApp
{
	public static class Fmt
	{

		public static IHtmlString Decimal(decimal? value)
		{
			if (!value.HasValue) { return null; }
			return new HtmlString($"{value:G29}");
		}


		public static IHtmlString Ellipsis(object value)
		{
			if (value == null) { return null; }

			value = HttpUtility.HtmlEncode(value);
			return new HtmlString($"<div class=\"ellipsis\" title=\"{value}\">{value}</div>");
		}



	}
}