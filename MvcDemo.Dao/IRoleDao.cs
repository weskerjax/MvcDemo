using System.Collections.Generic;
using MvcDemo.Domain;
using MvcDemo.Domain.Enums;
using Orion.API.Models;

namespace MvcDemo.Dao
{
	public interface IRoleDao
    {
		Dictionary<int, string> GetNameItems();
        Pagination<RoleDomain> GetPagination(string keyword, PageParams<RoleSort?> pageParams);
        RoleDomain GetById(int roleId);
        int Save(RoleDomain domain);
    }
}
