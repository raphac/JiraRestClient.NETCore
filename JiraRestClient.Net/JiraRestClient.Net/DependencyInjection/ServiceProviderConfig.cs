using System;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using JiraRestClient.Net.Core;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace JiraRestClient.Net.DependencyInjection
{
    public static class ServiceProviderConfig
    {
        public static IServiceCollection AddJiraRestClientServices(this IServiceCollection services,
            IConfiguration configuration)
        {
            var serviceClientConfiguration = configuration.GetAndValidateServiceClientConfiguration(JiraRestClientOptions.JiraRestClient);
            services.Configure<JiraRestClientOptions>(serviceClientConfiguration);
            services.AddHttpClient<IIssueClient, IssueClient>((serviceProvider, client) => ConfigureHttpClient(client, serviceProvider.GetService<IOptions<JiraRestClientOptions>>().Value));
            services.AddHttpClient<IProjectClient, ProjectClient>((serviceProvider, client) => ConfigureHttpClient(client, serviceProvider.GetService<IOptions<JiraRestClientOptions>>().Value));
            services.AddHttpClient<ISearchClient, SearchClient>((serviceProvider, client) => ConfigureHttpClient(client, serviceProvider.GetService<IOptions<JiraRestClientOptions>>().Value));
            services.AddHttpClient<IUserClient, UserClient>((serviceProvider, client) => ConfigureHttpClient(client, serviceProvider.GetService<IOptions<JiraRestClientOptions>>().Value));
            services.AddHttpClient<ISystemClient, SystemClient>((serviceProvider, client) => ConfigureHttpClient(client, serviceProvider.GetService<IOptions<JiraRestClientOptions>>().Value));
            return services;
        }

        public static void ConfigureHttpClient(HttpClient client, JiraRestClientOptions jiraRestClientOptions)
        {
            var bytes = Encoding.ASCII.GetBytes(jiraRestClientOptions.UserName + ":" + jiraRestClientOptions.Password);
            var token = Convert.ToBase64String(bytes);
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", token);
            client.BaseAddress = new Uri(jiraRestClientOptions.BaseUri);
        }

        private static IConfigurationSection GetAndValidateServiceClientConfiguration(this IConfiguration configuration, string sectionKey)
        {
            var jiraRestClientConfiguration = configuration.GetSection(sectionKey);
            if (!jiraRestClientConfiguration.GetChildren().Any())
            {
                throw new ArgumentException($"Provide configuration for {nameof(JiraRestClientOptions)} in section {sectionKey}.", nameof(sectionKey));
            }

            var jiraRestClientOptions = jiraRestClientConfiguration.Get<JiraRestClientOptions>();
            if (string.IsNullOrEmpty(jiraRestClientOptions.BaseUri) || !Uri.TryCreate(jiraRestClientOptions.BaseUri, UriKind.Absolute, out _))
            {
                throw new ArgumentException($"Provide valid {nameof(JiraRestClientOptions.BaseUri)} for {nameof(JiraRestClientOptions)} in section {sectionKey}.", nameof(sectionKey));
            }
            
            if (string.IsNullOrEmpty(jiraRestClientOptions.UserName))
            {
                throw new ArgumentException($"Provide valid {nameof(JiraRestClientOptions.UserName)} for {nameof(JiraRestClientOptions)} in section {sectionKey}.", nameof(sectionKey));
            }
            
            if (string.IsNullOrEmpty(jiraRestClientOptions.Password))
            {
                throw new ArgumentException($"Provide valid {nameof(JiraRestClientOptions.Password)} for {nameof(JiraRestClientOptions)} in section {sectionKey}.", nameof(sectionKey));
            }

            return jiraRestClientConfiguration;
        }
    }
}