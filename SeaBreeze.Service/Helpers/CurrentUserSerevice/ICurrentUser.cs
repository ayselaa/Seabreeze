using SeaBreeze.Service.DTOS.User;

namespace SeaBreeze.Service.Helpers.CurrentUser
{
    public interface ICurrentUser
    {
        CurrentUserDto GetCurrentUser();
    }
}
