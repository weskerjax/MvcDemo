using System;
using System.Collections.Generic;

namespace MvcDemo.Domain
{
    public class UserActDomain 
    {
        /// <summary>使用者Id</summary>
        public int UserId { get; set; }

        /// <summary>角色權限</summary>
        public IList<string> RoleActList { get; set; }

        /// <summary>允許權限</summary>
        public IList<string> AllowActList { get; set; }

        /// <summary>拒絕權限</summary>
        public IList<string> DenyActList { get; set; }

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
