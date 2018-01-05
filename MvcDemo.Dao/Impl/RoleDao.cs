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
	public class RoleDao : IRoleDao
	{
		private SmsDataContext _dc;

		public RoleDao(SmsDataContext dc)
		{
			_dc = dc;
		}


		public Dictionary<int, string> GetNameItems()
		{
			return _dc.RoleInfo
				.Select(x => new { x.RoleId, x.RoleName })
				.ToDictionary(x => x.RoleId, x => x.RoleName);			
		}




		private RoleDomain toDomain(RoleInfo data)
		{
			return new RoleDomain
			{
				RoleId = data.RoleId,
				RoleName = data.RoleName,
				AllowActList = OrionUtils.ToIdsList<string>(data.AllowActList),
				RemarkText = data.RemarkText,
				Status = data.Status.ToEnum<UseStatus>(),
				UserIds = data.UserRole.Select(x => x.UserId).ToList(),
				CreateBy = data.CreateBy,
				CreateDate = data.CreateDate,
				ModifyBy = data.ModifyBy,
				ModifyDate = data.ModifyDate,
			};
		}



		public Pagination<RoleDomain> GetPagination(string keyword, PageParams<RoleSort?> pageParams)
		{

			IQueryable<RoleInfo> query = _dc.RoleInfo;
			query = query.WhereHas(x => x.RoleName.Contains(keyword.Trim()));

			if (pageParams == null) { pageParams = PageParams<RoleSort?>.Unlimited(); }

			bool isDesc = pageParams.Descending;
			try
			{
				query = query.OrderBy(pageParams.OrderField, isDesc);
			}
			catch (Exception)
			{
				query = query.OrderBy(x => x.RoleName, isDesc);
			}


			var result = query.AsPagination(pageParams.PageIndex, pageParams.PageSize);
			return result.As(x=>toDomain(x));
		}




		public RoleDomain GetById(int roleId)
		{
			RoleInfo data = _dc.RoleInfo.FirstOrDefault(x => x.RoleId == roleId);
			if (data == null) { return null; }

			RoleDomain domain = toDomain(data);
			return domain;
		}




		public int Save(RoleDomain domain)
		{
			RoleInfo data;

			if (domain.RoleId > 0)
			{
				data = _dc.RoleInfo.FirstOrDefault(x => x.RoleId == domain.RoleId);
				Checker.Has(data, "角色不存在無法修改");               
			}
			else
			{
				data = new RoleInfo
				{
					CreateBy = domain.ModifyBy,
					CreateDate = DateTime.Now,
				};
				_dc.RoleInfo.InsertOnSubmit(data);
			}

			data.RoleName = domain.RoleName;
			data.AllowActList = OrionUtils.ToIdsString(domain.AllowActList);
			data.Status = domain.Status.ToString();
			data.RemarkText = domain.RemarkText;
			data.ModifyBy = domain.ModifyBy;
			data.ModifyDate = DateTime.Now;


			/*角色使用者對應處理*/
			if (domain.UserIds == null) { domain.UserIds = new List<int>(); }

			var userList = data.UserRole.ToList();

			userList.ForEach(x =>
			{
				if (domain.UserIds.Contains(x.UserId)) { return; }
				_dc.UserRole.DeleteOnSubmit(x);
			});

			domain.UserIds.ForEach(x =>
			{
				if (userList.Any(y => y.UserId == x)) { return; }

				data.UserRole.Add(new UserRole
				{
					UserId = x,
					CreateBy = domain.ModifyBy,
					CreateDate = DateTime.Now,
					ModifyBy = domain.ModifyBy,
					ModifyDate = DateTime.Now,
				});
			});


			_dc.SubmitChanges();


			return data.RoleId;
		}




	}
}
