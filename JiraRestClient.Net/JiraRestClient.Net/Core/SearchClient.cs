using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Threading.Tasks;
using JiraRestClient.Net.Jql;
using JiraRestClient.Net.Util;
using Newtonsoft.Json.Linq;

namespace JiraRestClient.Net.Core
{
    public class SearchClient : BaseClient
    {
        private readonly IDictionary<string, string> _newStringByStringToReplace;

        public SearchClient(JiraRestClient jiraRestClient, IDictionary<string, string> newStringByStringToReplace) : base(jiraRestClient)
        {
            _newStringByStringToReplace = newStringByStringToReplace;
        }

        public async Task<JqlSearchResult> SearchIssuesAsync(JqlSearchBean jqlSearchBean)
        {
            var uri = UriHelper.BuildPath(BaseUri, RestPathConstants.SEARCH);
            uri = UriHelper.AddQuery(uri, "jql",jqlSearchBean.Jql);
            return JsonSerializer.Deserialize<JqlSearchResult>(await SearchIssuesAsync(uri));
        }

        public async Task<dynamic> SearchIssuesDynamicAsync(JqlSearchBean jqlSearchBean)
        {
            var uri = UriHelper.BuildPath(BaseUri, RestPathConstants.SEARCH);
            uri = UriHelper.AddQuery(uri, "jql",jqlSearchBean.Jql);
            return JObject.Parse(await SearchIssuesAsync(uri));
        }
        
        public async Task<dynamic> SearchIssuesDynamicAsync(string restPath, string query)
        {
            var uri = UriHelper.BuildPath(BaseUri, restPath);
            uri.Query = query;
            return JObject.Parse(await SearchIssuesAsync(uri));
        }
        
        private async Task<string> SearchIssuesAsync(UriBuilder uri)
        {
            var response = await Client.GetAsync(uri.ToString());
            var content = await response.Content.ReadAsStringAsync();
            return ReplaceCustomFieldNames(content);
        }
        
        private string ReplaceCustomFieldNames(string content)
        {
            foreach (var keyValuePair in _newStringByStringToReplace)
            {
                content = content.Replace(keyValuePair.Key, keyValuePair.Value);
            }

            return content;
        }
    }
}