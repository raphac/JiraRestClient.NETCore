using System;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using JiraRestClient.Net.Jql;
using JiraRestClient.Net.Util;
using Newtonsoft.Json.Linq;

namespace JiraRestClient.Net.Core
{
    public class SearchClient : ISearchClient
    {
        protected readonly HttpClient HttpClient;

        public SearchClient(HttpClient httpClient)
        {
            HttpClient = httpClient;
        }

        public async Task<JqlSearchResult> SearchIssuesAsync(JqlSearchBean jqlSearchBean)
        {
            var uri = UriHelper.BuildPath(HttpClient.BaseAddress, RestPathConstants.SEARCH);
            uri = UriHelper.AddQuery(uri, "jql",jqlSearchBean.Jql);
            return JsonSerializer.Deserialize<JqlSearchResult>(await SearchIssuesAsync(uri));
        }

        public async Task<dynamic> SearchIssuesDynamicAsync(JqlSearchBean jqlSearchBean)
        {
            var uri = UriHelper.BuildPath(HttpClient.BaseAddress, RestPathConstants.SEARCH);
            uri = UriHelper.AddQuery(uri, "jql",jqlSearchBean.Jql);
            return JObject.Parse(await SearchIssuesAsync(uri));
        }
        
        public async Task<dynamic> SearchIssuesDynamicAsync(string restPath, string query)
        {
            var uri = UriHelper.BuildPath(HttpClient.BaseAddress, restPath);
            uri.Query = query;
            return JObject.Parse(await SearchIssuesAsync(uri));
        }
        
        private async Task<string> SearchIssuesAsync(UriBuilder uri)
        {
            var response = await HttpClient.GetAsync(uri.ToString());
            var content = await response.Content.ReadAsStringAsync();
            return ReplaceCustomFieldNames(content);
        }
        
        protected virtual string ReplaceCustomFieldNames(string content)
        {
            return content;
        }
    }
}