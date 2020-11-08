using System.Collections.Generic;
using System.Threading.Tasks;
using FluentAssertions;
using JiraRestClient.Net.Core;
using JiraRestClient.Net.Jql;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace JiraRestClient.Net.Test
{
    [TestClass]
    public class TestIssueClient :BaseTest
    {
        [TestMethod]
        public async Task TestGetIssueByKey()
        {
            var issue = await new IssueClient(HttpClient).GetIssueByKeyAsync(IssuekeyToSearch);
            issue.Should().NotBeNull();
        }

        [TestMethod]
        public async Task TestGetIssueByKeyWithFields()
        {
            var fields = new List<string> {EField.Summary.Field, EField.Description.Field};
            var expands = new List<string>
            {
                EField.Renderedfields.Field, EField.Transitions.Field, EField.Changelog.Field
            };
            var issue = await new IssueClient(HttpClient).GetIssueByKeyAsync(IssuekeyToSearch, fields, expands);
            issue.Should().NotBeNull();
            issue.Fields.Summary.Should().NotBeNull();
            issue.Fields.Description.Should().NotBeNull();
            issue.RenderedFields.Description.Should().NotBeNull();
        }
    }
}