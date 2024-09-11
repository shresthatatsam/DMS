using Disaster_Management;
using Disaster_Management_system.Data.Interface;
using Disaster_Management_system.Models;

namespace Disaster_Management_system.Data
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly ApplicationDbContext _context;

        public AuthenticationService(ApplicationDbContext context)
        {
            _context = context;
        }
        public Task<AuthenticationResult> LoginAsync(string username, string password)
        {
           var userdata = _context.Victims.Where(x => x.ContactNumber == username && x.Password == password).FirstOrDefault();

            if (username == userdata.ContactNumber && password == userdata.Password) // Replace with actual validation logic
            {
                return Task.FromResult(new AuthenticationResult { Succeeded = true });
            }
            return Task.FromResult(new AuthenticationResult { Succeeded = false });

        }
    }
}
