using Dashboard.Areas.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SeaBreeze.Domain;
using SeaBreeze.Domain.Entity.Tickets;

namespace Dashboard.Areas.Admin.Controllers
{
    [Area("admin")]
    public class PaymentController : Controller
    {
        private readonly AppDbContext _context;
        public PaymentController(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            List<BeachClubTicket> tickets = _context.BeachClubTickets
                                            .Include(ticket => ticket.BeachClubOrder)
                                            .ThenInclude(order => order.AppUser)
                                            .ToList();
            List<BeachClubTicketVM> data = GetDatas(tickets);
            return View(data);
        }

        private List<BeachClubTicketVM> GetDatas(List<BeachClubTicket> tick)
        {
            List<BeachClubTicketVM> data = new List<BeachClubTicketVM>();
            foreach (var ticket in tick)
            {
                BeachClubTicketVM ticketVM = new ()
                {
                    UserFullName = ticket.BeachClubOrder?.AppUser?.FullName,
                    TotalPrice = ticket.Price,
                    ValidTime = ticket.ValidTime,
                    //RoseBarPrice= ticket.RoseBarPrice,
                    //BeachClubPrice = ticket.BeachClubPrice
                };  
                data.Add(ticketVM);
            }
            return data;
        }
    }
}
