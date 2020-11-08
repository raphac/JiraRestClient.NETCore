using System.Threading.Tasks;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace JiraRestClient.Net.Test
{
    [TestClass]
    public class TestProjectClient :BaseTest
    {
        [TestMethod]
        public async Task TestGetAllProjects(){
            var task = await RestClient.ProjectClient.GetAllProjectsAsync();
            task.Should().NotBeNullOrEmpty();
        }

        [TestMethod]
        public async Task TestProjectByKey(){
            var project = await RestClient.ProjectClient.GetProjectByKeyAsync(ProjectKey);
            project.Should().NotBeNull();
            project.Key.Should().Be(ProjectKey);
        }
    }
}