<%@ page language="C#" %>
<%@ Import namespace="Orion.API" %>
<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
	<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
	<title></title>
</head>
<body>
	<ul>
		<%
			List<string> list = ConfigSectionManager.GetServiceAddressList();
			//list.Add("~/WCF/ExecuteArchive.aspx");
		%>
		<% foreach (var path in list) { %>
			<li><a href="<%= VirtualPathUtility.ToAbsolute(path) %>"><%= path %></a></li>
		<% } %>
	</ul>
</body>
</html>