# JiraRestClient.NETCore

A RestClient for Jira REST API V2 using .NetStandard2.0

 

## Usage

### Dependency injection integration
**IServiceCollection/IServiceProvider**
```C#
// Namespace of the extension method
#using JiraRestClient.Net.DependencyInjection;

// The place where you configure your IServiceProvider/IServiceCollection container
public RegisterMyStuff(IServiceCollection services, IConfiguration configuration) {
    services.AddJiraRestClientServices(configuration);
} 
```
Once registered you can simply inject IIssueClient, IProjectClient, ISearchClient, IUserClient or ISystemClient e.g.:

```C#
public Example(IIssueClient issueClient) {
    this.issueClient = issueClient;
} 
```

**Connection configuration**
The configuration is loaded from the appsettings.json. Add your custom configuration.
```json
{
  "JiraRestClient": {
    "BaseUri": "https://yourJiraUrl.com/",   
    "UserName": "user",   
    "Password": "1234"   
  }
}
```