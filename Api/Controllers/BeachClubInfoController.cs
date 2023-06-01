using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SeaBreeze.Domain.Constants;
using SeaBreeze.Service.Interfaces;

namespace Api.Controllers
{
    public class BeachClubInfoController : BaseController
    {

        private readonly ITicketService _ticketService;

        public BeachClubInfoController(ITicketService ticketService)
        {
            _ticketService = ticketService;
        }

        [HttpGet]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<IActionResult> GetBeachClubInfo()
        {
            DateTime currentDate = DateTime.UtcNow.AddHours(4);
            string formattedDate = currentDate.ToString("dd.MM.yyyy");

            int soldRoseBarTickets = await _ticketService.GetRoseBarTicketsPerDay(formattedDate);


            BeachClubInfo beachClubInfo = new BeachClubInfo()
            {
                TicketPrice = Constants.TicketPrice,
                TicketEnsure = Constants.InsurancePrice,
                RoseBar = Constants.RoseBarPrice,
                PremiumTicketPrice = Constants.PremiumTicketPrice,
                PremiumTicketEnsure = Constants.PremiumInsurancePrice,
                DiscountForNextDay = Constants.DiscountPercentage,
                RoseBarCapecity = Constants.RoseBarCapacity,
                SoldRoseBarTickets = soldRoseBarTickets
            };

            return Ok(beachClubInfo);
        }



    }


    public class BeachClubInfo
    {
        public decimal TicketPrice { get; set; }
        public decimal TicketEnsure { get; set; }
        public decimal RoseBar { get; set; }
        public decimal PremiumTicketPrice { get; set; }
        public decimal PremiumTicketEnsure { get; set; }
        public decimal DiscountForNextDay { get; set; }
        public int RoseBarCapecity { get; set; }
        public int SoldRoseBarTickets { get; set; }
    }
}
