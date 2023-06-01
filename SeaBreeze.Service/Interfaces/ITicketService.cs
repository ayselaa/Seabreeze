using SeaBreeze.Domain.Entity.Payment;
using SeaBreeze.Service.DTOS.BeachClub;
using SeaBreeze.Service.DTOS.Order;
using SeaBreeze.Service.DTOS.Ticket;
using static SeaBreeze.Service.Services.PaymentService;

namespace SeaBreeze.Service.Interfaces
{
    public interface ITicketService
    {
        Task<PayriffOrder> BuyTicket(string currentUserId, OrderDto order);
        Task<PayriffOrder> BuyPremiumTicket(string currentUserId, PremiumOrderDto orderDto);
        Task<string> CheckTicketPayment(CheckOrderDto checkOrderDto);
        Task<List<BeachClubTicketDto>> GetUserTickets(string userId);
        Task<TicketStatus> CheckStatus(string tixketId);
        Task<int> GetRoseBarTicketsPerDay(string dateString);
    }
}
