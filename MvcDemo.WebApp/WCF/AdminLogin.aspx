<%@ Page Language="C#" %>
<%@ Import namespace="System.Web.Mvc" %>
<%@ Import namespace="Orion.API" %>
<%@ Import namespace="Orion.Mvc.Security" %>
<%@ Import namespace="MvcDemo.Domain.Enums" %>

<% 
	/* 用於權限開發 */
	IList<string> actList = new[]
	{
		ACT.UserSetting,
		ACT.UserActSetting,

	}.Select(x => x.ToString()).ToList();

	actList = OrionUtils.GetEnumValues<ACT>().Select(x => x.ToString()).ToList();
	actList.Add("DevelopAdmin");

	var signInManager = DependencyResolver.Current.GetService<ISignInManager>();
	signInManager.DevelopSignIn(actList);

	//Response.Redirect("~/");
%>
