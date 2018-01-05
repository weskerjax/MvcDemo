using System.Collections.Generic;
using System.ServiceModel;
using MvcDemo.Domain;
using MvcDemo.Domain.Enums;
using Orion.API.Models;

namespace MvcDemo.Service
{
	[ServiceContract]
    public interface IRoleService
    {
        [OperationContract]
        Dictionary<int, string> GetNameItems();
                
        [OperationContract]
        Pagination<RoleDomain> GetPagination(string keyword, PageParams<RoleSort?> pageParams);
        
        [OperationContract]
        RoleDomain GetById(int roleId);
        
        [OperationContract]
        int Save(RoleDomain domain);


    }
}
