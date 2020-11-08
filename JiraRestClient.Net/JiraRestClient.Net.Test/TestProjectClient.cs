using System.Threading.Tasks;
using FluentAssertions;
using JiraRestClient.Net.Core;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace JiraRestClient.Net.Test
{
    [TestClass]
    public class TestProjectClient :BaseTest
    {
        [TestMethod]
        public async Task TestGetAllProjects(){
            var task = await new ProjectClient(HttpClient).GetAllProjectsAsync();
            task.Should().NotBeNullOrEmpty();
        }

        [TestMethod]
        public async Task TestProjectByKey(){
            var project = await new ProjectClient(HttpClient).GetProjectByKeyAsync(ProjectKey);
            project.Should().NotBeNull();
            project.Key.Should().Be(ProjectKey);
        }
    }
}