<%@ Import namespace="Autofac" %>
<%@ Import namespace="Autofac.Integration.Wcf" %>
<%@ Import namespace="System.Web.Mvc" %>
<%@ Import namespace="MvcDemo.Service" %>
<%@ Import namespace="MvcDemo.Domain.Enums" %>


<script language="c#" runat="server">	  

	private IComponentContext container = AutofacHostFactory.Container;

	public void Page_Init(object sender, EventArgs e)
	{
		var userService = (IUserService)container.Resolve(typeof(IUserService));
		userService.GetById(1);

		Response.Write("Rum Complete.");
		Response.End();
	}
</script>
