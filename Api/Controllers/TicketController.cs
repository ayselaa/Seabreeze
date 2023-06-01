using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SeaBreeze.Service.DTOS.Order;
using SeaBreeze.Service.Helpers.CurrentUser;
using SeaBreeze.Service.Interfaces;
using static SeaBreeze.Service.Services.PaymentService;

namespace Api.Controllers
{
    //[Authorize]
    public class TicketController : BaseController
    {
        private readonly ITicketService _ticketService;
        private readonly ICurrentUser _currentUser;
        private readonly IPaymentService _paymentService;

        public TicketController(ITicketService ticketService, ICurrentUser currentUser, IPaymentService paymentService)
        {
            _ticketService = ticketService;
            _currentUser = currentUser;
            _paymentService = paymentService;
        }

        [HttpPost]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<IActionResult> BuyTicket(OrderDto order)
        {
            var user = _currentUser.GetCurrentUser();
            var payRiffOrder = await _ticketService.BuyTicket(user.UserId, order);
            return Ok(payRiffOrder);
        }

        [HttpPost]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<IActionResult> BuyTicketPremium(PremiumOrderDto orderDto)
        {
            var user = _currentUser.GetCurrentUser();
            var order = await _ticketService.BuyPremiumTicket(user.UserId, orderDto);
            return Ok(order);
        }

        [HttpPost]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<IActionResult> CheckOrderStatus(CheckOrderDto checkOrderDto)
        {
            var result = await _ticketService.CheckTicketPayment(checkOrderDto);
            return Ok(result);
        }


        [HttpGet]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<IActionResult> UserTickets()
        {
            var user = _currentUser.GetCurrentUser();

            var tickets = await _ticketService.GetUserTickets(user.UserId);

            return Ok(tickets);
        }


        [HttpGet]
        [Route("{ticketId}")]
        public async Task<IActionResult> CheckTicket(string ticketId)
        {
            return Ok(await _ticketService.CheckStatus(ticketId));
        }


        [HttpGet]
        [Route("{dateString}")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<IActionResult> GetRoseBarTicketsPerDay([FromRoute] string dateString)
        {
            return Ok(await _ticketService.GetRoseBarTicketsPerDay(dateString));
        }

    }
}
