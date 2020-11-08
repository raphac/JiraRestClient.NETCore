using System.Collections.Generic;
using System.Threading.Tasks;
using JiraRestClient.Net.Domain;

namespace JiraRestClient.Net.Core
{
    public interface IProjectClient
    {
        Task<Project> GetProjectByKeyAsync(string key);
        Task<List<Project>> GetAllProjectsAsync();
        Task<List<Version>> GetProjectVersionsAsync(string key);
        Task<List<Component>> GetProjectComponentsAsync(string key);
    }
}