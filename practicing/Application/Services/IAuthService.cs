using Microsoft.AspNetCore.Identity;

namespace practicing.Application.Services
{
    public interface IAuthService
    {
        Task<IdentityUser> Register(IdentityUser user, string password, string role);
        Task<bool> UserExist(string username);
        Task<string> Login(string username, string password);
    }
}
