using System.Collections.Generic;
using System.Threading.Tasks;
using JiraRestClient.Net.Domain;

namespace JiraRestClient.Net.Core
{
    public interface IIssueClient
    {
        Task<Issue> GetIssueByKeyAsync(string key);

        Task<Issue> GetIssueByKeyAsync(string key, List<string> fields, List<string> expand);
    }
}