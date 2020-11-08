using System.Threading.Tasks;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace JiraRestClient.Net.Test
{
    [TestClass]
    public class TestUserClient : BaseTest
    {

        [TestMethod]
        public async Task TestGetLoggedInUser()
        {
            var userClient = RestClient.UserClient;
            var user = await userClient.GetLoggedInUserAsync();
            user.Should().NotBeNull();
        }

        [TestMethod]
        public async Task TestGetUserByUsername()
        {
            var userClient = RestClient.UserClient;
            var user = await userClient.GetUserByUsernameAsync(Username);
            user.Should().NotBeNull();
        }
    }
}