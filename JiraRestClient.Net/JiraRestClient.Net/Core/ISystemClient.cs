using System.Collections.Generic;
using System.Threading.Tasks;
using JiraRestClient.Net.Domain;

namespace JiraRestClient.Net.Core
{
    public interface ISystemClient
    {
        Task<List<IssueType>> GetIssueTypesAsync();
        Task<List<Priority>> GetPrioritiesAsync();
        Task<List<Status>> GetStatesAsync();
    }
}