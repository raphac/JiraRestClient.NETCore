using System.Collections.Generic;
using System.Text.Json;
using System.Threading.Tasks;
using JiraRestClient.Net.Domain;
using JiraRestClient.Net.Util;

namespace JiraRestClient.Net.Core
{
    /// <summary>
    /// Client to get Issues
    /// </summary>
    public class IssueClient : BaseClient
    {
        public IssueClient(JiraRestClient jiraRestClient) : base(jiraRestClient)
        {
        }

        /// <summary>
        /// Get a Issue by key
        /// </summary>
        /// <param name="key">The key of the Issue</param>
        /// <returns>A async Task containing the Issue</returns>
        public async Task<Issue> GetIssueByKeyAsync(string key)
        {
            var restUriBuilder = UriHelper.BuildPath(BaseUri, RestPathConstants.ISSUE, key);
            var completeUri = restUriBuilder.ToString();
            var stream = Client.GetStringAsync(completeUri);
            var streamResult = await stream;
            return JsonSerializer.Deserialize<Issue>(streamResult);
        }


        public async Task<Issue> GetIssueByKeyAsync(string key, List<string> fields, List<string> expand)
        {
            var restUriBuilder = UriHelper.BuildPath(BaseUri, RestPathConstants.ISSUE, key);
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
            var stream = await Client.GetStringAsync(completeUri);
            return JsonSerializer.Deserialize<Issue>(stream);
        }
    }
}