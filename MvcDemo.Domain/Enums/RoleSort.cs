using System.ComponentModel.DataAnnotations;

namespace MvcDemo.Domain.Enums
{
	public enum RoleSort
	{
		/// <summary>角色Id</summary>
		[Display(Name = "角色Id")]
		RoleId,

		/// <summary>角色名稱</summary>
		[Display(Name = "角色名稱")]
		RoleName,

		/// <summary>狀態</summary>
		[Display(Name = "狀態")]
		Status,

		/// <summary>建立者 Id</summary>
		[Display(Name = "建立者")]
		CreateBy,

		/// <summary>建立時間</summary>
		[Display(Name = "建立時間")]
		CreateDate,

		/// <summary>修改者 Id</summary>
		[Display(Name = "修改者")]
		ModifyBy,

		/// <summary>修改時間</summary>
		[Display(Name = "修改時間")]
		ModifyDate,
	}
}
