using System.Collections.Generic;
using System.Transactions;
using MvcDemo.Dao.Database;
using MvcDemo.Domain;
using MvcDemo.Domain.Enums;
using Orion.API.Models;
using Xunit;

namespace MvcDemo.Dao.Impl.Tests
{
	public class RoleDaoTests
	{


		private RoleDao _roleDao;

		public RoleDaoTests()
		{
			_roleDao = new RoleDao(new SmsDataContext());
		}



		[Fact]
		public void GetNameItems_NotNullTest()
		{
			var result = _roleDao.GetNameItems();
			Assert.NotNull(result);
		}



		[Theory]
		[InlineData(null)]
		[InlineData("Ad")]
		public void GetPagination_NotNullTest(string keyword)
		{
			var result = _roleDao.GetPagination(keyword, new PageParams<RoleSort?>{
				PageIndex  = 1,
				PageSize   = 20,
				OrderField = RoleSort.RoleId, 
				Descending = true,
			});
			Assert.NotNull(result);
		}



		[Theory]
		[InlineData(1)]
		public void GetById_NotNullTest(int roleId)
		{
			var result = _roleDao.GetById(roleId);
			Assert.NotNull(result);
		}





		public static IEnumerable<object[]> Save_EqualTest_Data()
		{
			yield return new object[] { new RoleDomain {
				RoleName = "Test",
				Status = UseStatus.Enable,
				UserIds = new List<int>{1},
			}};
		}
		 

		[Theory]
		[MemberData("Save_EqualTest_Data")]
		public void Save_EqualTest(RoleDomain domain)
		{
			using (var tx = new TransactionScope())
			{
				int id = _roleDao.Save(domain);
				RoleDomain data = _roleDao.GetById(id);

				Assert.Equal(domain.RoleName, data.RoleName);
				Assert.Equal(domain.Status, data.Status);
				Assert.Equal(domain.UserIds, data.UserIds);
			}

		}



	}
}
