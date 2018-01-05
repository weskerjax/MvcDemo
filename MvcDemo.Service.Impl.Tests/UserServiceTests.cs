using System.Collections.Generic;
using Moq;
using MvcDemo.Dao;
using MvcDemo.Domain;
using Orion.API;
using Orion.API.Models;
using Xunit;

namespace MvcDemo.Service.Impl.Tests
{
	public class UserServiceTests
	{



		public static IEnumerable<object[]> Save_ValidationTest_Data()
		{
			yield return new object[] { new UserDomain(){
				Account = null,
				UserName =  null,
				Email = null,
			}};
			yield return new object[] { new UserDomain(){
				Account = "a",
				UserName =  null,
				Email = null,
			}};
			yield return new object[] { new UserDomain(){
				Account = "a",
				UserName =  "a",
				Email = null,
			}};
			yield return new object[] { new UserDomain(){
				Account = "a",
				UserName =  "a",
				Email = "a",
			}};
		}


		[Theory]
		[MemberData("Save_ValidationTest_Data")]
		public void Save_ValidationTest(UserDomain domain)
		{
			var mock = new Mock<IUserDao>();
			mock.Setup(y => y.GetByAccount(It.IsAny<string>())).Returns(new UserDomain { Status = UseStatus.Enable });

			var userService = new UserService(mock.Object, new PasswordSHA256Handle());
			Assert.Throws<OrionException>(() => userService.Save(domain));
		}



		[Fact]
		public void CheckPassword_NullValueTest()
		{
			var mock = new Mock<IUserDao>();
			mock.Setup(y => y.GetByAccount(It.IsAny<string>())).Returns((UserDomain)null);

			var userService = new UserService(mock.Object, new PasswordSHA256Handle());
			Assert.Throws<OrionException>(() => userService.CheckPassword("admin", "1234"));
		}

		[Fact]
		public void CheckPassword_AccoutCloseTest()
		{
			var mock = new Mock<IUserDao>();
			mock.Setup(y => y.GetByAccount(It.IsAny<string>())).Returns(new UserDomain { Status = UseStatus.Disable });

			var userService = new UserService(mock.Object, new PasswordSHA256Handle());
			Assert.Throws<OrionException>(() => userService.CheckPassword("", ""));
		}


		[Fact]
		public void CheckPassword_FailTest()
		{
			var mock = new Mock<IUserDao>();
			mock.Setup(y => y.GetByAccount(It.IsAny<string>())).Returns(new UserDomain { Status = UseStatus.Enable });
			mock.Setup(y => y.GetPassword(It.IsAny<int>())).Returns("");

			var userService = new UserService(mock.Object, new PasswordSHA256Handle());
			Assert.Throws<OrionException>(() => userService.CheckPassword("admin", "1234"));
		}


		[Theory]
		[InlineData("1234")]
		public void CheckPassword_SuccessTest(string passwd)
		{
			var passwdHandle = new PasswordSHA256Handle();
			var mock = new Mock<IUserDao>();
			mock.Setup(y => y.GetByAccount(It.IsAny<string>())).Returns(new UserDomain { UserId = 1, Status = UseStatus.Enable });
			mock.Setup(y => y.GetPassword(It.IsAny<int>())).Returns(passwdHandle.Encrypt(passwd));

			var userService = new UserService(mock.Object, passwdHandle);
			int userId = userService.CheckPassword("admin", passwd);
			Assert.Equal(1, userId);
		}




		[Theory]
		[InlineData("1234")]
		[InlineData("abcdefg")]
		[InlineData("ABCDEFG")]
		public void SetPassword_FailTest(string password)
		{
			var mock = new Mock<IUserDao>();
			var userService = new UserService(mock.Object, new PasswordSHA256Handle());
			Assert.Throws<OrionException>(() => userService.SetPassword(1, password));
		}




		public static IEnumerable<object[]> GetHoldActList_MergeTest_Data()
		{
			yield return new object[] { new UserActDomain(){
				RoleActList = new List<string> { "1", "2" },
				AllowActList =  new List<string> { "2", "3" },
				DenyActList = new List<string>(),
			}};
		}

		[Theory]
		[MemberData("GetHoldActList_MergeTest_Data")]
		public void GetHoldActList_MergeTest(UserActDomain domain)
		{
			var mock = new Mock<IUserDao>();
			mock.Setup(y => y.GetSelfAct(It.IsAny<int>())).Returns(domain);

			var userService = new UserService(mock.Object, new PasswordSHA256Handle());
			var holdList = userService.GetHoldActList(1);

			foreach (var act in domain.RoleActList)
			{
				Assert.Contains(act,holdList);		 
			}
			foreach (var act in domain.AllowActList)
			{
				Assert.Contains(act,holdList);		 
			}
		}




		public static IEnumerable<object[]> GetHoldActList_DenyTest_Data()
		{
			yield return new object[] { new UserActDomain(){
				RoleActList = new List<string> { "1", "2" },
				AllowActList =  new List<string>(),
				DenyActList = new List<string> { "2", "3" },
			}};
		}

		[Theory]
		[MemberData("GetHoldActList_DenyTest_Data")]
		public void GetHoldActList_DenyTest(UserActDomain domain)
		{
			var mock = new Mock<IUserDao>();
			mock.Setup(y => y.GetSelfAct(It.IsAny<int>())).Returns(domain);

			var userService = new UserService(mock.Object, new PasswordSHA256Handle());
			var holdList = userService.GetHoldActList(1);

			foreach (var act in domain.DenyActList)
			{
				Assert.False(holdList.Contains(act));
			}
		}



	}
}
