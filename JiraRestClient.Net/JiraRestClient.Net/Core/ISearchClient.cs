using System.Threading.Tasks;
using JiraRestClient.Net.Jql;

namespace JiraRestClient.Net.Core
{
    public interface ISearchClient
    {
        Task<JqlSearchResult> SearchIssuesAsync(JqlSearchBean jqlSearchBean);
        Task<dynamic> SearchIssuesDynamicAsync(JqlSearchBean jqlSearchBean);
        Task<dynamic> SearchIssuesDynamicAsync(string restPath, string query);
    }
}