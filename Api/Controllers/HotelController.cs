using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SeaBreeze.Service.DTOS.Hotel;
using SeaBreeze.Service.Helpers.CurrentUser;
using SeaBreeze.Service.Interfaces;

namespace Api.Controllers
{
    public class HotelController : BaseController
    {
        private readonly IHotelService _hotelService;
        private readonly ICurrentUser _currentUser;


        public HotelController(IHotelService hotelService, ICurrentUser currentUser)
        {
            _hotelService = hotelService;
            _currentUser = currentUser;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _hotelService.GetAll();
            return Ok(result);
        }


        [HttpGet]
        [Route("{Id}")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<IActionResult> GetById(int Id)
        {
            var user = _currentUser.GetCurrentUser();
            var hotelDetail = await _hotelService.GetById(user.LangCode, Id);
            return Ok(hotelDetail);
        }

        [HttpPost]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<IActionResult> ReservHotel([FromBody] HotelReservationDto reservationDto)
        {
            var user = _currentUser.GetCurrentUser();
            return Ok(await _hotelService.ReservHotel(user.UserId, reservationDto));
        }
    }
}
