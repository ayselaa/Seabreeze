
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SeaBreeze.Service.DTOS.Account;
using SeaBreeze.Service.DTOS.Consumer;
using SeaBreeze.Service.DTOS.User;
using SeaBreeze.Service.Helpers.CurrentUser;
using SeaBreeze.Service.Interfaces;

namespace Api.Controllers
{
    public class AccountController : BaseController
    {
        private readonly IAccountService _accountService;
        private readonly ICurrentUser _currentUser;

        public AccountController(IAccountService accountService, ICurrentUser currentUser)
        {
            _accountService = accountService;
            _currentUser = currentUser;
        }

        [HttpPost]
        public async Task<IActionResult> RegisterConsumer(RegisterConsumerDto consumer)
        {
            return Ok(await _accountService.RegisterConsumer(consumer));
        }

        [HttpPost]
        public async Task<IActionResult> RegisterResident(RegisterResidentDto resident)
        {
            await _accountService.RegisterResident(resident);
            return Ok(new { message = "User registered successfully" });
        }

        [HttpPost]
        public async Task<IActionResult> LoginConsumer(UserLoginDto loginDto)
        {
            return Ok(await _accountService.Login(loginDto));
        }

        [HttpPost]
        public async Task<IActionResult> LoginResident(UserLoginDto loginDto)
        {
            return Ok(await _accountService.LoginResident(loginDto));
        }


        [HttpPost]
        [Route("{langCode}")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<IActionResult> ChangeUserLanguage([FromRoute] string langCode)
        {
            var currentUser = _currentUser.GetCurrentUser();

            return Ok(await _accountService.ChangeLanguage(currentUser.UserId, langCode));
        }

        [HttpDelete]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<IActionResult> DeleteAccount()
        {
            var currentUser = _currentUser.GetCurrentUser();

            await _accountService.DeleteAccount(currentUser.UserId);

            return Ok();
        }

        [HttpGet]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Consumer,Admin")]
        public async Task<IActionResult> GetUserInfo()
        {
            var currentUser = _currentUser.GetCurrentUser();
            return Ok(await _accountService.GetUserInfo(currentUser.UserId));
        }

        [HttpPost]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Consumer,Admin")]
        public async Task<IActionResult> ChangePassword(ChangePasswordDto passwordDto)
        {
            var currentUser = _currentUser.GetCurrentUser();

 
            return Ok(await _accountService.ChangeUserPass(currentUser.UserId, passwordDto));
        }

        [HttpPost]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "UnConfirmedUser")]
        public async Task<IActionResult> ConfirmUser(string code)
        {
            var currentUser = _currentUser.GetCurrentUser();
            return Ok(await _accountService.ConfirmUSer(currentUser.UserId, code));
        }
    }
}
