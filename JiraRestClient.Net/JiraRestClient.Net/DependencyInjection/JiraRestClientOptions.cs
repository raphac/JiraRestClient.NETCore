namespace JiraRestClient.Net.DependencyInjection
{
    public class JiraRestClientOptions
    {
        public const string JiraRestClient = "JiraRestClient";

        public string BaseUri { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}