using System.Net.Http;
using JiraRestClient.Net.DependencyInjection;

namespace JiraRestClient.Net.Test
{
    public abstract class BaseTest
    {
        protected readonly string Uri = "https://localhost:2990/";

        protected const string Username = "admin";

        protected const string Password = "admin";

        protected const string ProjectKey = "DEMO";

        protected const string IssuekeyToSearch = "DEMO-1";

        protected readonly HttpClient HttpClient;
        
        protected readonly JiraRestClientOptions JiraRestClientOptions;

        public BaseTest()
        {
            HttpClient = new HttpClient();
            JiraRestClientOptions = new JiraRestClientOptions
            {
                BaseUri = Uri,
                Password = Password,
                UserName = Username
            };
            ServiceProviderConfig.ConfigureHttpClient(HttpClient, JiraRestClientOptions);
        }
    }
}