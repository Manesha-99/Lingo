using Microsoft.AspNetCore.Identity;

namespace Lingo.Repositories
{
    public interface ITokenRepository
    {
        string CreateJWTToken(IdentityUser user, List<string> roles);
    }
}
