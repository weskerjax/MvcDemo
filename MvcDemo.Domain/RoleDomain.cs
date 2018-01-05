using System;
using System.Collections.Generic;
using Orion.API.Models;

namespace MvcDemo.Domain
{
	public class RoleDomain
    {    

        /// <summary>角色Id</summary>
        public int RoleId { get; set; }

        /// <summary>角色名稱</summary>
        public string RoleName { get; set; }

        /// <summary>允許權限</summary>
        public IList<string> AllowActList { get; set; }

        /// <summary>備註</summary>
        public string RemarkText { get; set; }

        /// <summary>狀態</summary>
		public UseStatus Status { get; set; }


        /// <summary>使用者Ids</summary>
        public IList<int> UserIds { get; set; }

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
