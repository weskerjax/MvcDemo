using System.Collections.Generic;
using System.ServiceModel;
using MvcDemo.Domain;
using MvcDemo.Domain.Enums;
using Orion.API.Models;

namespace MvcDemo.Service
{
	[ServiceContract]
	public interface IUserService
	{
		[OperationContract]
		Dictionary<int, string> GetNameItems();

		[OperationContract]
		Dictionary<int, string> GetFullNameItems();
		
		[OperationContract]
		Pagination<UserDomain> GetPagination(string keyword, PageParams<UserSort?> pageParams);
		
		[OperationContract]
		UserDomain GetById(int userId);
		
		[OperationContract]
		UserDomain GetByAccount(string account);
		
		[OperationContract]
		int Save(UserDomain domain);



		[OperationContract]
		int CheckPassword(string account, string password);
		
		[OperationContract]
		void SetPassword(int userId, string password);

		[OperationContract]
		IList<string> GetHoldActList(int userId);



		[OperationContract]
		UserActDomain GetSelfAct(int userId);
		
		[OperationContract]
		void SetSelfAct(UserActDomain domain);


		[OperationContract]
		void AddSignInRecord(string account, string signInIp, string signInType, string statusCode, string statusMsg);


		[OperationContract]
		Dictionary<string, string> GetPreferenceItems(int userId);

		[OperationContract]
		string GetPreference(int userId, string name);

		[OperationContract]
		void SavePreference(int userId, string name, string value);
		 
	}
}
