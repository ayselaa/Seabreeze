using SeaBreeze.Service.DTOS.Account;
using SeaBreeze.Service.DTOS.Consumer;
using SeaBreeze.Service.DTOS.User;

namespace SeaBreeze.Service.Interfaces
{
    public interface IAccountService
    {
        Task<string> RegisterConsumer(RegisterConsumerDto consumer);
        Task<string> RegisterResident(RegisterResidentDto resident);
        Task<string> Login(UserLoginDto loginDto);
        Task<string> LoginResident(UserLoginDto loginDto);

        Task<string> ChangeLanguage(string userId, string langCode);
        Task<bool> DeleteAccount(string currentUserId);
        Task<GetUserInfoDto> GetUserInfo(string userId);
        Task<string> ChangeUserPass(string userId, ChangePasswordDto passwordDto);
        Task<string> ConfirmUSer(string userId, string phoneConfirmToken);
    }
}
