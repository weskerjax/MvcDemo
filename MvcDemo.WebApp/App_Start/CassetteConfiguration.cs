using Cassette;
using Cassette.Scripts;
using Cassette.Stylesheets;

namespace MvcDemo.WebApp
{
	/// <summary>
	/// Configures the Cassette asset bundles for the web application.
	/// </summary>
	public class CassetteBundleConfiguration : IConfiguration<BundleCollection>
	{
		public void Configure(BundleCollection bundles)
		{

			bundles.AddPerIndividualFile<StylesheetBundle>("Content");
			bundles.AddPerIndividualFile<ScriptBundle>("Scripts");

			bundles.Add<StylesheetBundle>("Styles/Bundles", new[] {
				"~/Scripts/bootstrap-3.3.6/css/bootstrap.css",
				"~/Scripts/bootstrap-datetimepicker-1.0.1/bootstrap-datetimepicker.css",
				"~/Scripts/jquery.whereBuilder/jquery.whereBuilder.css",
				"~/Scripts/font-awesome-4.5.0/css/font-awesome.css",
				"~/Content/Styles/extensions.css",
				"~/Content/Styles/layout.css",
				"~/Content/Styles/theme-gradient/theme.css",
				"~/Content/Styles/mark-label.css",
			});


			bundles.Add<ScriptBundle>("Scripts/Bundles", new[] {
				"~/Scripts/modernizr-2.6.2/modernizr-2.6.2.js",
				"~/Scripts/moment-2.7.0/moment-2.7.0.js",
				"~/Scripts/respond-1.2.0/respond.js",
				"~/Scripts/jquery-1.12.2/jquery-1.12.2.js",
				"~/Scripts/jquery.cookie-1.4.1/jquery.cookie-1.4.1.js",
				"~/Scripts/jquery.tmpl-1.0.0/jquery.tmpl-1.0.0.js",
				"~/Scripts/jquery.validate-1.12.0/jquery.validate-1.12.0.js",
				"~/Scripts/jquery.validate-1.12.0/jquery.validate.additional-1.12.0.js",
				"~/Scripts/jquery.validate-1.12.0/jquery.validate.unobtrusive.js",
				"~/Scripts/jquery.whereBuilder/jquery.whereBuilder.js",
				"~/Scripts/bootstrap-3.3.6/js/bootstrap.js",
				"~/Scripts/bootstrap-datetimepicker-1.0.1/bootstrap-datetimepicker.js",
				"~/Scripts/bootstrap-typeahead-1.0.0/bootstrap-typeahead.js",
				"~/Scripts/main/polyfill.js",
				"~/Scripts/main/float-compute.js",
				"~/Scripts/main/jquery.barcodein.js",
				"~/Scripts/main/jquery.konami.js",
				"~/Scripts/main/jquery.ezAjax.js",
				"~/Scripts/main/iframeDialog.js",
				"~/Scripts/main/Dialog.js",
				"~/Scripts/main/StatusMsg.js",
				"~/Scripts/main/ext-picker.js",
				"~/Scripts/main/ext-typeahead.js",
				"~/Scripts/main/typing-limit.js",
				"~/Scripts/main/title-tip.js",
				"~/Scripts/main/global.js",
			});

		}
	}
}