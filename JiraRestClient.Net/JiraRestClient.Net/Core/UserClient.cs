using System.Text.Json;
using System.Threading.Tasks;
using JiraRestClient.Net.Domain;
using JiraRestClient.Net.Util;

namespace JiraRestClient.Net.Core
{
    public class UserClient : BaseClient
    {
        public UserClient(JiraRestClient jiraRestClient) : base(jiraRestClient)
        {
        }

        public async Task<User> GetLoggedInUserAsync()
        {        
            var restUriBuilder = UriHelper.BuildPath(BaseUri, RestPathConstants.USER);
            restUriBuilder.Query = "username=" + Username;
            var completeUri = restUriBuilder.ToString();
            var stream = await Client.GetStringAsync(completeUri);
            return  JsonSerializer.Deserialize<User>(stream);
        }

        public async Task<User> GetUserByUsernameAsync(string username){
             var restUriBuilder = UriHelper.BuildPath(BaseUri, RestPathConstants.USER);
            restUriBuilder.Query = "username=" + username;
            var completeUri = restUriBuilder.ToString();
            var stream = await Client.GetStringAsync(completeUri);
            return  JsonSerializer.Deserialize<User>(stream);
        }
    }
}