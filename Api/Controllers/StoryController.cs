using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SeaBreeze.Service.Helpers.CurrentUser;
using SeaBreeze.Service.Interfaces;

namespace Api.Controllers
{
    public class StoryController : BaseController
    {
        private readonly IStoryService _storyService;
        private readonly ICurrentUser _currentUser;

        public StoryController(IStoryService storyService, ICurrentUser currentUser)
        {
            _storyService = storyService;
            _currentUser = currentUser;
        }


        [HttpGet]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<IActionResult> GetAll()
        {
            var stories = await _storyService.GetAll();
            return Ok(stories);
        }

        [HttpGet]
        [Route("{Id}")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<IActionResult> GetById([FromRoute] int Id)
        {
            var user = _currentUser.GetCurrentUser();
            var story = await _storyService.GetDetail(user.LangCode, Id);
            return Ok(story);
        }
    }
}
