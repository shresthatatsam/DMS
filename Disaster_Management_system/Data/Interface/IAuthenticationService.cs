using Disaster_Management_system.Models;

namespace Disaster_Management_system.Data.Interface
{
    public interface IAuthenticationService
    {
        Task<AuthenticationResult> LoginAsync(string username, string password);
    }

}
