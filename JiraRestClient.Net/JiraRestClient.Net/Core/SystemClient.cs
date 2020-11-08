using System.Collections.Generic;
using System.Text.Json;
using System.Threading.Tasks;
using JiraRestClient.Net.Domain;
using JiraRestClient.Net.Util;

namespace JiraRestClient.Net.Core
{
    public class SystemClient : BaseClient
    {
        public SystemClient(JiraRestClient jiraRestClient) : base(jiraRestClient)
        {
        }

        public async Task<List<IssueType>> GetIssueTypesAsync()
        {
            var restUriBuilder = UriHelper.BuildPath(BaseUri, RestPathConstants.ISSUETPYES);
            var stream = await Client.GetStringAsync(restUriBuilder.ToString());
            return JsonSerializer.Deserialize<List<IssueType>>(stream);
        }

        public async Task<List<Priority>> GetPrioritiesAsync()
        {
            var restUriBuilder = UriHelper.BuildPath(BaseUri, RestPathConstants.PRIORITY);
            var stream = await Client.GetStringAsync(restUriBuilder.ToString());
            return JsonSerializer.Deserialize<List<Priority>>(stream);
        }

        public async Task<List<Status>> GetStatesAsync()
        {
            var restUriBuilder = UriHelper.BuildPath(BaseUri, RestPathConstants.STATUS);
            var stream = await Client.GetStringAsync(restUriBuilder.ToString());
            return JsonSerializer.Deserialize<List<Status>>(stream);
        }
    }
}