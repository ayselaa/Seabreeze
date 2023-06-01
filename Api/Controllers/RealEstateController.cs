using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SeaBreeze.Service.Helpers.CurrentUser;
using SeaBreeze.Service.Interfaces;

namespace Api.Controllers
{
    public class RealEstateController : BaseController
    {
        private readonly IRealEstate _realEstate;
        private readonly ICurrentUser _currentUser;

        public RealEstateController(IRealEstate realEstate, ICurrentUser currentUser)
        {
            _realEstate = realEstate;
            _currentUser = currentUser;
        }


        [HttpGet]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<IActionResult> GetAll()
        {
            var realEstates = await _realEstate.GetAll();
            return Ok(realEstates);
        }


        [HttpGet]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [Route("{Id}")]
        public async Task<IActionResult> GetById(int Id)
        {
            var user = _currentUser.GetCurrentUser();
            var realEsstateDetail = await _realEstate.GetById(user.LangCode, Id);
            return Ok(realEsstateDetail);
        }

    }
}
