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
    public class ProjectClient : IProjectClient
    {
        protected readonly HttpClient HttpClient;

        public ProjectClient(HttpClient httpClient)
        {
            HttpClient = httpClient;
        }

        public async Task<Project> GetProjectByKeyAsync(string key)
        {
            var restUriBuilder = UriHelper.BuildPath(HttpClient.BaseAddress, RestPathConstants.PROJECT);
            restUriBuilder.Query = RestParamConstants.PROJECT + "=" + key;
            var completeUri = restUriBuilder.ToString();
            var stream = await HttpClient.GetStringAsync(completeUri);
            return JsonSerializer.Deserialize<Project>(stream);
        }

        public async Task<List<Project>> GetAllProjectsAsync()
        {
            var restUriBuilder = UriHelper.BuildPath(HttpClient.BaseAddress, RestPathConstants.PROJECT);
            var stream = await HttpClient.GetStringAsync(restUriBuilder.ToString());
            return JsonSerializer.Deserialize<List<Project>>(stream);
        }

        public async Task<List<Version>> GetProjectVersionsAsync(string key){
            var restUriBuilder = UriHelper.BuildPath(HttpClient.BaseAddress, RestPathConstants.PROJECT, key, RestPathConstants.VERSIONS);
            var stream = await HttpClient.GetStringAsync(restUriBuilder.ToString());
            return JsonSerializer.Deserialize<List<Version>>(stream);
        }

        public async Task<List<Component>> GetProjectComponentsAsync(string key){
            var restUriBuilder = UriHelper.BuildPath(HttpClient.BaseAddress, RestPathConstants.PROJECT, key, RestPathConstants.COMPONENTS);
            var stream = await HttpClient.GetStringAsync(restUriBuilder.ToString());
            return JsonSerializer.Deserialize<List<Component>>(stream);
        }
    }
}