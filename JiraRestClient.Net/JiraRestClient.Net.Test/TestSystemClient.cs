using System.Threading.Tasks;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace JiraRestClient.Net.Test
{
    [TestClass]
    public class TestSystemClient : BaseTest
    {

        [TestMethod]
        public async Task TestGetIssueTypes()
        {           
            var issueTypes = await RestClient.SystemClient.GetIssueTypesAsync();
            issueTypes.Should().NotBeNullOrEmpty();
        }

        [TestMethod]
        public async Task TestGetPriorities(){
            var priorities = await RestClient.SystemClient.GetPrioritiesAsync();
            priorities.Should().NotBeNullOrEmpty();
        }
    }
}