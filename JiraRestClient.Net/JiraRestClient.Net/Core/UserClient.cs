using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using JiraRestClient.Net.DependencyInjection;
using JiraRestClient.Net.Domain;
using JiraRestClient.Net.Util;
using Microsoft.Extensions.Options;

namespace JiraRestClient.Net.Core
{
    public class UserClient : IUserClient
    {
        protected readonly HttpClient HttpClient;
        protected readonly IOptions<JiraRestClientOptions> JiraRectClientOptions;
        
        public UserClient(HttpClient httpClient, IOptions<JiraRestClientOptions> jiraRectClientOptions)
        {
            HttpClient = httpClient;
            JiraRectClientOptions = jiraRectClientOptions;
        }

        public async Task<User> GetLoggedInUserAsync()
        {        
            var restUriBuilder = UriHelper.BuildPath(HttpClient.BaseAddress, RestPathConstants.USER);
            restUriBuilder.Query = "username=" + JiraRectClientOptions.Value.UserName;
            var completeUri = restUriBuilder.ToString();
            var stream = await HttpClient.GetStringAsync(completeUri);
            return  JsonSerializer.Deserialize<User>(stream);
        }

        public async Task<User> GetUserByUsernameAsync(string username){
             var restUriBuilder = UriHelper.BuildPath(HttpClient.BaseAddress, RestPathConstants.USER);
            restUriBuilder.Query = "username=" + username;
            var completeUri = restUriBuilder.ToString();
            var stream = await HttpClient.GetStringAsync(completeUri);
            return  JsonSerializer.Deserialize<User>(stream);
        }
    }
}