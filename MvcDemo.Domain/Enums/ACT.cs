using System.ComponentModel;

namespace MvcDemo.Domain.Enums
{
	/// <summary>Access Control Tag</summary>
	public enum ACT 
	{ 

		/*############################################################*/

		/// <summary>角色管理</summary>
		[Description("角色管理")]
		RoleSetting,

		/// <summary>使用者管理</summary>
		[Description("使用者管理")]
		UserSetting,

		/// <summary>使用者個人權限</summary>
		[Description("使用者個人權限")]
		UserActSetting,
		 


	}
}