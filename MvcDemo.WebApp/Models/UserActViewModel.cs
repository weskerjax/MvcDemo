using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MvcDemo.WebApp.Models
{
	public class UserActViewModel
	{

		/// <summary>使用者Id</summary>
		[Required]
		[Display(Name = "使用者編號")]
		public int UserId { get; set; }

		/// <summary>角色權限</summary>
		[Display(Name = "角色權限")]
		public IList<string> RoleActList { get; set; }

		/// <summary>允許權限</summary>
		[Display(Name = "允許權限")]
		public IList<string> AllowActList { get; set; }

		/// <summary>拒絕權限</summary>
		[Display(Name = "拒絕權限")]
		public IList<string> DenyActList { get; set; }


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