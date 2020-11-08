using System.Threading.Tasks;
using JiraRestClient.Net.Domain;

namespace JiraRestClient.Net.Core
{
    public interface IUserClient
    {
        Task<User> GetLoggedInUserAsync();
        Task<User> GetUserByUsernameAsync(string username);
    }
}