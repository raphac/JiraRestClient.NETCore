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
    public class ProjectClient : BaseClient
    {
        public ProjectClient(JiraRestClient jiraRestClient) : base(jiraRestClient)
        {
        }

        public async Task<Project> GetProjectByKeyAsync(string key)
        {
            var restUriBuilder = UriHelper.BuildPath(BaseUri, RestPathConstants.PROJECT);
            restUriBuilder.Query = RestParamConstants.PROJECT + "=" + key;
            var completeUri = restUriBuilder.ToString();
            var stream = await Client.GetStringAsync(completeUri);
            return JsonSerializer.Deserialize<Project>(stream);
        }

        public async Task<List<Project>> GetAllProjectsAsync()
        {
            var restUriBuilder = UriHelper.BuildPath(BaseUri, RestPathConstants.PROJECT);
            var stream = await Client.GetStringAsync(restUriBuilder.ToString());
            return JsonSerializer.Deserialize<List<Project>>(stream);
        }

        public async Task<List<Version>> GetProjectVersionsAsync(string key){
            var restUriBuilder = UriHelper.BuildPath(BaseUri, RestPathConstants.PROJECT, key, RestPathConstants.VERSIONS);
            var stream = await Client.GetStringAsync(restUriBuilder.ToString());
            return JsonSerializer.Deserialize<List<Version>>(stream);
        }

        public async Task<List<Component>> GetProjectComponentsAsync(string key){
            var restUriBuilder = UriHelper.BuildPath(BaseUri, RestPathConstants.PROJECT, key, RestPathConstants.COMPONENTS);
            var stream = await Client.GetStringAsync(restUriBuilder.ToString());
            return JsonSerializer.Deserialize<List<Component>>(stream);
        }
    }
}