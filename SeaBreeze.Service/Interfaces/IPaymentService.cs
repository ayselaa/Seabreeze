using SeaBreeze.Domain.Entity.Payment;
using SeaBreeze.Domain.Entity.Users;
using SeaBreeze.Service.DTOS.Order;
using static SeaBreeze.Service.Services.PaymentService;

namespace SeaBreeze.Service.Interfaces
{
    public interface IPaymentService
    {
        Task<PayriffOrder> CreateOrder(AppUser user, OrderDto orderDto, decimal amount);
        Task<string> CheckOrderStatus(CheckOrderDto checkOrderDto);
        Task<PayriffOrder> CreatePremiumOrder(AppUser user, PremiumOrderDto orderDto, decimal amount);
    }
}
