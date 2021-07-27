using Microsoft.AspNetCore.Identity;

namespace MyOnlineStoreAPI.Configuration
{
    public interface ITokenService
    {
        string CreateToken(IdentityUser user);
    }
}