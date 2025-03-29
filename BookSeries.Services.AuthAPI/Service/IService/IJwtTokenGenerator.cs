using Bookservie.Services.AuthAPI.Models;

namespace Bookservie.Services.AuthAPI.Service.IService
{
    public interface IJwtTokenGenerator
    {
        string GenerateToken(ApplicationUser applicationUser, IEnumerable<string> roles);

    }
}
