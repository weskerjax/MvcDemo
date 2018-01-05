using Orion.API.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MvcDemo.WebApp.Models
{
	public class RoleViewModel
	{
		/// <summary>角色Id</summary>
		[Display(Name = "角色Id")]
		public int RoleId { get; set; }

		/// <summary>角色名稱</summary>
		[Required]
		[Display(Name = "角色名稱")]
		public string RoleName { get; set; }

		/// <summary>允許權限</summary>
		[Display(Name = "允許權限")]
		public IList<string> AllowActList { get; set; }

		/// <summary>備註</summary>
		[DataType(DataType.MultilineText)]
		[Display(Name = "備註")]
		public string RemarkText { get; set; }

		/// <summary>狀態</summary>
		[Required]
		[Display(Name = "狀態")]
		public UseStatus Status { get; set; }


		/// <summary>使用者Ids</summary>
		[Display(Name = "使用者")]
		public IList<int> UserIds { get; set; }


		/// <summary>建立人</summary>
		[Display(Name = "建立人")]
		public int CreateBy { get; set; }

		/// <summary>建立日期</summary>
		[Display(Name = "建立日期")]
		public DateTime CreateDate { get; set; }

		/// <summary>修改人</summary>
		[Display(Name = "修改人")]
		public int ModifyBy { get; set; }

		/// <summary>修改日期</summary>
		[Display(Name = "修改日期")]
		public DateTime ModifyDate { get; set; }


	}
}