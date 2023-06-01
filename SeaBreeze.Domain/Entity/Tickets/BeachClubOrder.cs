using SeaBreeze.Domain.Entity.Payment;
using SeaBreeze.Domain.Entity.Users;

namespace SeaBreeze.Domain.Entity.Tickets
{
    public class BeachClubOrder
    {
        public string Id { get; set; }
        public AppUser AppUser { get; set; }
        public DateTime CreatedAt { get; set; }
        public decimal TotalPrice { get; set; }
        public string TransactionId { get; set; }
        public List<BeachClubTicket> Tickets { get; set; }
        public PayriffOrder PayriffOrder { get; set; }
    }
}
