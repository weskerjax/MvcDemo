using System.Collections.Generic;
using Moq;
using MvcDemo.Dao;
using MvcDemo.Domain;
using Orion.API;
using Orion.API.Models;
using Xunit;

namespace MvcDemo.Service.Impl.Tests
{
	public class RoleServiceTests
    {

        public static IEnumerable<object[]> Save_ValidationTest_Data()
        {
            yield return new object[] { new RoleDomain(){
                RoleName = null,
                Status = UseStatus.Enable,
            }};
            yield return new object[] { new RoleDomain(){
                RoleName = "",
                Status = UseStatus.Enable,
            }};
            yield return new object[] { new RoleDomain(){
                RoleName = "GGG",
                Status = UseStatus.Disable,
                UserIds = new List<int>{1},
            }};
        }


        [Theory]
        [MemberData("Save_ValidationTest_Data")]
        public void Save_ValidationTest(RoleDomain domain)
        {
            var mock = new Mock<IRoleDao>();
            var roleService = new RoleService(mock.Object);
            Assert.Throws<OrionException>(() => roleService.Save(domain));
        }


    }
}
