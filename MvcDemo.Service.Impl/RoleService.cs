using System.Collections.Generic;
using MvcDemo.Dao;
using MvcDemo.Domain;
using MvcDemo.Domain.Enums;
using Orion.API;
using Orion.API.Models;

namespace MvcDemo.Service.Impl
{
	public class RoleService : IRoleService
	{
		private IRoleDao _roleDao;

		public RoleService(IRoleDao roleDao)
		{
			_roleDao = roleDao;
		}




		public Dictionary<int, string> GetNameItems()
		{
			return _roleDao.GetNameItems();
		}


		public Pagination<RoleDomain> GetPagination(string keyword, PageParams<RoleSort?> pageParams)
		{
			return _roleDao.GetPagination(keyword, pageParams);
		}

		public RoleDomain GetById(int roleId)
		{
			var domain = _roleDao.GetById(roleId);
			if (domain == null) { throw new OrionNoDataException("角色資料不存在"); }

			return domain;
		}


		public int Save(RoleDomain domain)
		{
			Checker.Has(domain.RoleName, "角色名稱不可以為空");


			if (domain.Status != UseStatus.Enable && (domain.UserIds != null && domain.UserIds.Count > 0))
			{
				throw new OrionException("角色還有使用者不可以關閉");
			}

			return _roleDao.Save(domain);
		}

	}
}
