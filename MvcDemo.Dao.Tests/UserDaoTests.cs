using System.Collections.Generic;
using System.Transactions;
using MvcDemo.Dao.Database;
using MvcDemo.Domain;
using MvcDemo.Domain.Enums;
using Orion.API.Models;
using Xunit;

namespace MvcDemo.Dao.Impl.Tests
{
	public class UserDaoTests
	{

		private UserDao _userDao;

		public UserDaoTests ()
		{
			_userDao = new UserDao(new SmsDataContext());
		}



		[Fact]
		public void GetNameItems_NotNullTest()
		{
			var result = _userDao.GetNameItems();
			Assert.NotNull(result);
		}



		[Fact]
		public void GetFullNameItems_NotNullTest()
		{
			var result = _userDao.GetFullNameItems();
			Assert.NotNull(result);
		}

		



		[Theory]
		[InlineData(null)]
		[InlineData("Ad")]
		public void GetPagination_NotNullTest(string keyword)
		{
			var result = _userDao.GetPagination(keyword, new PageParams<UserSort?>{
				PageIndex  = 1,
				PageSize   = 20,
				OrderField = UserSort.UserId, 
				Descending = true,
			});
			Assert.NotNull(result);
		}





		[Theory]
		[InlineData(1)]
		public void GetById_NotNullTest(int id)
		{
			var result = _userDao.GetById(id);
			Assert.NotNull(result);
		}



		[Theory]
		[InlineData("admin")]
		public void GetByAccount_NotNullTest(string account)
		{
			var result = _userDao.GetByAccount(account);
			Assert.NotNull(result);            
		}









		public static IEnumerable<object[]> Save_SuccessTest_Data()
		{
			yield return new object[] { new UserDomain {
				Account = "a",
				UserName =  "a",
				Email = "a",
				Status = UseStatus.Enable,
			}};
		}


		[Theory]
		[MemberData("Save_SuccessTest_Data")]
		public void Save_SuccessTest(UserDomain domain)
		{
			using (var tx = new TransactionScope())
			{
				_userDao.Save(domain);
				Assert.True(true);
			}
		}







		[Theory]
		[InlineData(1)]
		public void GetPasswordTest(int userId)
		{
			var result = _userDao.GetPassword(userId);
			Assert.NotNull(result);            
		}


		[Theory]
		[InlineData(1)]
		public void SetPasswordTest(int userId)
		{
			using (var tx = new TransactionScope())
			{
				string passwd = _userDao.GetPassword(userId);
				_userDao.SetPassword(userId, passwd);
				var result = _userDao.GetPassword(userId);
				Assert.Equal(passwd, result);
			}
		}





		[Theory]
		[InlineData(1)]
		public void GetSelfActTest(int userId)
		{
			var result = _userDao.GetSelfAct(userId);
			Assert.NotNull(result);
		}



		[Theory]
		[InlineData(1)]
		public void SetSelfActTest(int userId)
		{
			var domain = _userDao.GetSelfAct(userId);
			_userDao.SetSelfAct(domain);
			Assert.True(true);
		}



		[Fact]
		public void AddSignInRecordTest()
		{
			using (var tx = new TransactionScope())
			{
				_userDao.AddSignInRecord(
					"test",
					"255.255.255.255",
					"site",
					"success",
					""
				);
				Assert.True(true);
			}
		}



	}
}
