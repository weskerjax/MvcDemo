using System;
using System.Collections.Generic;
using System.Linq;
using MvcDemo.Dao.Database;
using MvcDemo.Domain;
using MvcDemo.Domain.Enums;
using Orion.API;
using Orion.API.Extensions;
using Orion.API.Models;

namespace MvcDemo.Dao.Impl
{
	public class UserDao : IUserDao
	{
		private SmsDataContext _dc;

		public UserDao(SmsDataContext dc)
		{
			_dc = dc;
		}




		public Dictionary<int, string> GetNameItems()
		{
			var items = _dc.UserInfo
				.Select(x => new { x.UserId, x.UserName })
				.ToDictionary(x => x.UserId, x => x.UserName);

			return items;
		}



		public Dictionary<int, string> GetFullNameItems()
		{
			var items = _dc.UserInfo
				.Select(x => new { x.UserId, x.UserName, x.Account })
				.ToDictionary(x => x.UserId, x => x.UserName + " " + x.Account);

			return items;
		}





		private UserDomain toDomain(UserInfo data)
		{
			return new UserDomain
			{
				UserId = data.UserId,
				Account = data.Account,
				UserName = data.UserName,
				Email = data.Email,
				Status = data.Status.ToEnum<UseStatus>(),
				DepartmentId = data.DepartmentId ?? 0,
				ExtensionNum = data.ExtensionNum,
				UserTitle = data.UserTitle,
				RemarkText = data.RemarkText,
				RoleIds = data.UserRole.Select(x => x.RoleId).ToList(),
				CreateBy = data.CreateBy,
				CreateDate = data.CreateDate,
				ModifyBy = data.ModifyBy,
				ModifyDate = data.ModifyDate,

			};
		}




		public Pagination<UserDomain> GetPagination(string keyword, PageParams<UserSort?> pageParams)
		{
			IQueryable<UserInfo> query = _dc.UserInfo;


			if (keyword.HasText())
			{
				keyword = keyword.Trim();

				query = query.Where(q =>
					q.Account.Contains(keyword) ||
					q.UserName.Contains(keyword) ||
					q.UserTitle.Contains(keyword)
				);
			}


			if (pageParams == null) { pageParams = PageParams<UserSort?>.Unlimited(); }

			bool isDesc = pageParams.Descending;
			try
			{
				query = query.OrderBy(pageParams.OrderField, isDesc); 
			}
			catch (Exception)
			{
				query = query.OrderBy(x => x.UserId, isDesc);
			}


			var result = query.AsPagination(pageParams.PageIndex, pageParams.PageSize);
			return result.As(x => toDomain(x));
		}






		public UserDomain GetById(int userId)
		{
			UserInfo data = _dc.UserInfo.FirstOrDefault(x => x.UserId == userId);
			if (data == null) { return null; }

			UserDomain domain = toDomain(data);
			return domain;
		}


		public UserDomain GetByAccount(string account)
		{
			UserInfo data = _dc.UserInfo.FirstOrDefault(x => x.Account == account.ToLower());
			if (data == null) { return null; }

			UserDomain domain = toDomain(data);
			return domain;
		}
		




		public int Save(UserDomain domain)
		{
			UserInfo data;

			if (domain.UserId > 0)
			{
				data = _dc.UserInfo.FirstOrDefault(x => x.UserId == domain.UserId);
				Checker.Has(data, "使用者不存在無法修改");
			}
			else
			{
				data = new UserInfo
				{
					Account    = domain.Account.ToLower(),
					CreateBy   = domain.ModifyBy,
					CreateDate = DateTime.Now,
				};
				_dc.UserInfo.InsertOnSubmit(data);
			}


			data.UserName     = domain.UserName;            
			data.DepartmentId = domain.DepartmentId;            
			data.ExtensionNum = domain.ExtensionNum;            
			data.UserTitle    = domain.UserTitle;            
			data.Email        = domain.Email;            
			data.Status       = domain.Status.ToString();
			data.RemarkText   = domain.RemarkText;
			data.ModifyBy     = domain.ModifyBy;
			data.ModifyDate   = DateTime.Now;


			/*使用者角色對應處理*/
			if (domain.RoleIds == null) { domain.RoleIds = new List<int>(); }

			_dc.UserRole.DeleteAllOnSubmit(data.UserRole.ToList());

			var roleList = domain.RoleIds.Select(x=> new UserRole
			{
				RoleId = x,
				CreateBy = domain.ModifyBy,
				CreateDate = DateTime.Now,
				ModifyBy = domain.ModifyBy,
				ModifyDate = DateTime.Now,
			});
			data.UserRole.AddRange(roleList);


			_dc.SubmitChanges();

			return data.UserId;
		}





		public string GetPassword(int userId)
		{
			return _dc.UserInfo.Where(x => x.UserId == userId).Select(x => x.Password).FirstOrDefault();
		}

		public void SetPassword(int userId, string password)
		{
			UserInfo data = _dc.UserInfo.FirstOrDefault(x => x.UserId == userId);
			if (data == null) { return; }

			data.Password = password;

			_dc.SubmitChanges();
		}



		/// <summary>
		/// 使用者本身的權限
		/// </summary>
		public UserActDomain GetSelfAct(int userId)
		{
			UserInfo data = _dc.UserInfo.FirstOrDefault(x => x.UserId == userId);
			Checker.Has(data, "帳號不存在！");

			IList<string> roleAct = _dc.UserInfo
					.Where(x => x.UserId == userId)
					.SelectMany(x => x.UserRole.Select(y => y.RoleInfo.AllowActList))
					.AsEnumerable()
					.SelectMany(x => OrionUtils.ToIdsList<string>(x))
					.Distinct()
					.ToList();

			IList<string> allowActList = OrionUtils.ToIdsList<string>(data.AllowActList);
			IList<string> denyActList = OrionUtils.ToIdsList<string>(data.DenyActList);

			var domain = new UserActDomain
			{                
				UserId = data.UserId,
				CreateBy = data.ModifyBy,
				CreateDate = data.CreateDate,
				ModifyBy = data.ModifyBy,
				ModifyDate = data.ModifyDate,
				RoleActList = roleAct,
				AllowActList = allowActList,
				DenyActList = denyActList,
			};

			return domain;
		}



		public void SetSelfAct(UserActDomain domain)
		{

			UserInfo data = _dc.UserInfo.FirstOrDefault(x => x.UserId == domain.UserId);
			Checker.Has(data, "帳號不存在！");

			data.AllowActList = OrionUtils.ToIdsString(domain.AllowActList);
			data.DenyActList = OrionUtils.ToIdsString(domain.DenyActList);
			data.ModifyBy = domain.ModifyBy;
			data.ModifyDate = DateTime.Now;

			_dc.SubmitChanges();
		}




		public void AddSignInRecord(string account, string signInIp, string signInType, string statusCode, string statusMsg)
		{
			var data = new UserSignInRecord
			{
				Account = account.ToLower(),
				SignInIp = signInIp,
				SignInType = signInType,
				StatusCode = statusCode,
				StatusMsg = statusMsg,                
				CreateDate = DateTime.Now,
			};
			_dc.UserSignInRecord.InsertOnSubmit(data);
			_dc.SubmitChanges();
		}




		public Dictionary<string, string> GetPreferenceItems(int userId)
		{
			Dictionary<string, string> items = _dc.UserPreference
				.Where(x => x.UserId == userId)
				.Select(x => new { x.Name, x.Value })
				.ToDictionary(x => x.Name, x => x.Value);

			return items;
		}


		public string GetPreference(int userId, string name)
		{
			return _dc.UserPreference
				.Where(x => x.UserId == userId)
				.Where(x => x.Name == name)
				.Select(x => x.Value)
				.FirstOrDefault();
		}


		public void SavePreference(int userId, string name, string value)
		{
			UserPreference data = _dc.UserPreference
				.Where(x => x.UserId == userId)
				.Where(x => x.Name == name)
				.FirstOrDefault();

			if (data == null)
			{
				data = new UserPreference
				{
					UserId = userId,
					Name = name,
					CreateDate = DateTime.Now,
				};
				_dc.UserPreference.InsertOnSubmit(data);
			}
						
			data.Value = value;
			data.ModifyDate = DateTime.Now;

			_dc.SubmitChanges();
		}




	}
}
