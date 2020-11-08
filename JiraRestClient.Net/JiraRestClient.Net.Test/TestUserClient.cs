using System.Threading.Tasks;
using FluentAssertions;
using JiraRestClient.Net.Core;
using JiraRestClient.Net.DependencyInjection;
using Microsoft.Extensions.Options;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace JiraRestClient.Net.Test
{
    [TestClass]
    public class TestUserClient : BaseTest
    {

        [TestMethod]
        public async Task TestGetLoggedInUser()
        {
            var userClient = new UserClient(HttpClient, new OptionsWrapper<JiraRestClientOptions>(JiraRestClientOptions));
            var user = await userClient.GetLoggedInUserAsync();
            user.Should().NotBeNull();
        }

        [TestMethod]
        public async Task TestGetUserByUsername()
        {
            var userClient = new UserClient(HttpClient, new OptionsWrapper<JiraRestClientOptions>(JiraRestClientOptions));
            var user = await userClient.GetUserByUsernameAsync(Username);
            user.Should().NotBeNull();
        }
    }
}