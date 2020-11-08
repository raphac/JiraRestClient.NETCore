using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using JiraRestClient.Net.Domain;
using JiraRestClient.Net.Util;

namespace JiraRestClient.Net.Core
{
    public class SystemClient : ISystemClient
    {
        protected readonly HttpClient HttpClient;

        public SystemClient(HttpClient httpClient)
        {
            HttpClient = httpClient;
        }

        public async Task<List<IssueType>> GetIssueTypesAsync()
        {
            var restUriBuilder = UriHelper.BuildPath(HttpClient.BaseAddress, RestPathConstants.ISSUETPYES);
            var stream = await HttpClient.GetStringAsync(restUriBuilder.ToString());
            return JsonSerializer.Deserialize<List<IssueType>>(stream);
        }

        public async Task<List<Priority>> GetPrioritiesAsync()
        {
            var restUriBuilder = UriHelper.BuildPath(HttpClient.BaseAddress, RestPathConstants.PRIORITY);
            var stream = await HttpClient.GetStringAsync(restUriBuilder.ToString());
            return JsonSerializer.Deserialize<List<Priority>>(stream);
        }

        public async Task<List<Status>> GetStatesAsync()
        {
            var restUriBuilder = UriHelper.BuildPath(HttpClient.BaseAddress, RestPathConstants.STATUS);
            var stream = await HttpClient.GetStringAsync(restUriBuilder.ToString());
            return JsonSerializer.Deserialize<List<Status>>(stream);
        }
    }
}