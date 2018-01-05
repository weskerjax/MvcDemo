using System.ComponentModel.DataAnnotations;

namespace MvcDemo.Domain.Enums
{

	public enum UserSort
	{
		/// <summary>使用者Id</summary>
		[Display(Name = "使用者Id")]
		UserId,

		/// <summary>姓名</summary>
		[Display(Name = "姓名")]
		UserName,

		/// <summary>帳號</summary>
		[Display(Name = "帳號")]
		Account,

		/// <summary>部門</summary>
		[Display(Name = "部門")]
		DepartmentId,

		/// <summary>分機號碼</summary>
		[Display(Name = "分機號碼")]
		ExtensionNum,

		/// <summary>職稱</summary>
		[Display(Name = "職稱")]
		UserTitle,

		/// <summary>E-Mail</summary>
		[Display(Name = "E-Mail")]
		Email,

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