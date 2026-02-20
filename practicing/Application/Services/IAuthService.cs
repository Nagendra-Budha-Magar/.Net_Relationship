using Microsoft.AspNetCore.Identity;

namespace practicing.Application.Services
{
    public interface IAuthService
    {
        Task<IdentityUser> Register(IdentityUser user, string password, string role);
        Task<string> login(string username, string password);
    }
}
