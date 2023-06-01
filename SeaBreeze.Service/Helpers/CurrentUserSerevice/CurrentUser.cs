using Microsoft.AspNetCore.Http;
using SeaBreeze.Service.DTOS.User;
using System.Security.Claims;

namespace SeaBreeze.Service.Helpers.CurrentUser
{
    public class CurrentUser : ICurrentUser
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        public CurrentUser(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public CurrentUserDto GetCurrentUser()
        {
            var user = _httpContextAccessor.HttpContext.User;
            var userId = user.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier).Value;
            var userLang = user.Claims.FirstOrDefault(x => x.Type == ClaimTypes.UserData).Value;
            //var entity = await _accountService.GetUser(userId);
            //var dto = _mapper.Map<CurrentUserInfoDto>(entity);
            //dto.LangCode = entity.DeviceLang;
            //return dto;

            return new CurrentUserDto { UserId = userId, LangCode = userLang };
        }
    }
}
