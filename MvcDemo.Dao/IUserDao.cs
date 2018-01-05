using System.Collections.Generic;
using MvcDemo.Domain;
using MvcDemo.Domain.Enums;
using Orion.API.Models;


namespace MvcDemo.Dao
{
	public interface IUserDao
	{
		Dictionary<int, string> GetNameItems();
		Dictionary<int, string> GetFullNameItems();
		Pagination<UserDomain> GetPagination(string keyword, PageParams<UserSort?> pageParams);
		UserDomain GetById(int userId);
		UserDomain GetByAccount(string account);
		int Save(UserDomain domain);

		string GetPassword(int userId);
		void SetPassword(int userId, string password);

		UserActDomain GetSelfAct(int userId);
		void SetSelfAct(UserActDomain domain);

		void AddSignInRecord(string account, string signInIp, string signInType, string statusCode, string statusMsg);


		Dictionary<string, string> GetPreferenceItems(int userId);

		string GetPreference(int userId, string name);

		void SavePreference(int userId, string name, string value); 
	}
}
