using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using JiraRestClient.Net.Domain;
using JiraRestClient.Net.Util;

namespace JiraRestClient.Net.Core
{
    /// <summary>
    /// Client to get Issues
    /// </summary>
    public class IssueClient : IIssueClient
    {
        protected readonly HttpClient HttpClient;

        public IssueClient(HttpClient httpClient)
        {
            HttpClient = httpClient;
        }

        public async Task<Issue> GetIssueByKeyAsync(string key)
        {
            var restUriBuilder = UriHelper.BuildPath(HttpClient.BaseAddress, RestPathConstants.ISSUE, key);
            var completeUri = restUriBuilder.ToString();
            var stream = HttpClient.GetStringAsync(completeUri);
            var streamResult = await stream;
            return JsonSerializer.Deserialize<Issue>(streamResult);
        }

        public async Task<Issue> GetIssueByKeyAsync(string key, List<string> fields, List<string> expand)
        {
            var restUriBuilder = UriHelper.BuildPath(HttpClient.BaseAddress, RestPathConstants.ISSUE, key);
            if(fields != null && fields.Count > 0)
            {
                var fieldsParam = string.Join(",", fields);
                UriHelper.AddQuery(restUriBuilder, RestParamConstants.FIELDS, fieldsParam);
            }

            if(expand != null && expand.Count > 0)
            {
                var expandParam = string.Join(",", expand);
                UriHelper.AddQuery(restUriBuilder, RestParamConstants.EXPAND, expandParam);
            }

            var completeUri = restUriBuilder.ToString();
            var stream = await HttpClient.GetStringAsync(completeUri);
            return JsonSerializer.Deserialize<Issue>(stream);
        }
    }
}