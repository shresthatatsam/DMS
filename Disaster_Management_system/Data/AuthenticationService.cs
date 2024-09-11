//using Disaster_Management;
//using Disaster_Management_system.Data.Interface;
//using Disaster_Management_system.Models;
//using Microsoft.AspNetCore.Http;

//namespace Disaster_Management_system.Data
//{
//    public class AuthenticationService : IAuthenticationService
//    {
//        private readonly ApplicationDbContext _context;
//        private readonly IHttpContextAccessor _httpContextAccessor;

//        public AuthenticationService(ApplicationDbContext context, IHttpContextAccessor httpContextAccessor)
//        {
//            _context = context;
//            _httpContextAccessor = httpContextAccessor;
//        }
//        //public Task<AuthenticationResult> LoginAsync(string username, string password)
//        //{
//        //   var userdata = _context.Victims.Where(x => x.ContactNumber == username && x.Password == password).FirstOrDefault();

//        //    if (username == userdata.ContactNumber && password == userdata.Password) // Replace with actual validation logic
//        //    {
//        //        _httpContextAccessor.HttpContext.Session.SetString("VictimId", userdata.Id.ToString());

//        //        return Task.FromResult(new AuthenticationResult { Succeeded = true });
//        //    }
//        //    return Task.FromResult(new AuthenticationResult { Succeeded = false });

//        //}
//    }
//}
