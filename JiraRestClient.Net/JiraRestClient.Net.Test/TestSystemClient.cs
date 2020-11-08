using System.Threading.Tasks;
using FluentAssertions;
using JiraRestClient.Net.Core;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace JiraRestClient.Net.Test
{
    [TestClass]
    public class TestSystemClient : BaseTest
    {

        [TestMethod]
        public async Task TestGetIssueTypes()
        {           
            var issueTypes = await new SystemClient(HttpClient).GetIssueTypesAsync();
            issueTypes.Should().NotBeNullOrEmpty();
        }

        [TestMethod]
        public async Task TestGetPriorities(){
            var priorities = await new SystemClient(HttpClient).GetPrioritiesAsync();
            priorities.Should().NotBeNullOrEmpty();
        }
    }
}