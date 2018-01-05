using System;
using System.Collections.Generic;
using Orion.API.Models;

namespace MvcDemo.Domain
{
	public class UserDomain 
    {

        /// <summary>使用者Id</summary>
        public int UserId { get; set; }

        /// <summary>帳號</summary>
        public string Account { get; set; }

        /// <summary>姓名</summary>
        public string UserName { get; set; }

        /// <summary>信箱</summary>
        public string Email { get; set; }

        /// <summary>狀態</summary>
		public UseStatus Status { get; set; }

        /// <summary>部門 Id</summary>
        public int DepartmentId { get; set; }

        /// <summary>分機號碼</summary>
        public string ExtensionNum { get; set; }

        /// <summary>職稱</summary>
        public string UserTitle { get; set; }

        /// <summary>備註</summary>
        public string RemarkText { get; set; }


        /// <summary>角色Ids</summary>
        public IList<int> RoleIds { get; set; }


		/// <summary>建立人</summary>
		public int CreateBy { get; set; }

		/// <summary>建立日期</summary>
		public DateTime CreateDate { get; set; }

		/// <summary>修改人</summary>
		public int ModifyBy { get; set; }

		/// <summary>修改日期</summary>
		public DateTime ModifyDate { get; set; }

    }
}
