using System.Threading.Tasks;
using FluentAssertions;
using JiraRestClient.Net.Core;
using JiraRestClient.Net.Jql;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace JiraRestClient.Net.Test
{
    [TestClass]
    public class TestSearchClient : BaseTest
    {
        [TestMethod]
        public async Task TestSearchIssues()
        {
            var jsb = new JqlSearchBean();
            var jql = JqlBuilder.Create().AddCondition(EField.Project, EOperator.EQUALS, "WEBUI")
                    .And().AddCondition(EField.Status, EOperator.EQUALS, JqlConstants.StatusInProgress)
                    .OrderBy(SortOrder.Asc, EField.Created);
            jsb.Jql = jql;
            jsb.AddField(EField.IssueKey, EField.Status, EField.Due, EField.Summary, EField.IssueType, EField.Priority, EField.Updated, EField.Transitions);
            jsb.AddExpand(EField.Transitions);
            var result = await new SearchClient(HttpClient).SearchIssuesAsync(jsb);
            result.Should().NotBeNull();
        }
    }
}