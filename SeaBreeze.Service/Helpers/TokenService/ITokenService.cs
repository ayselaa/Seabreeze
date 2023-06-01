using SeaBreeze.Domain.Entity.Users;

namespace SeaBreeze.Service.Helpers.TokenService
{
    public interface ITokenService
    {
        string CreateToken(AppUser user, IList<string> roles);
    }
}
