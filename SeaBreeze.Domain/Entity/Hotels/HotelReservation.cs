using SeaBreeze.Domain.Entity.Users;

namespace SeaBreeze.Domain.Entity.Hotels;

public class HotelReservation
{
    public string Id { get; set; }
    public string From { get; set; }
    public string To { get; set; }
    public Hotel Hotel { get; set; }
    public DateTime BuyTime { get; set; }
    public decimal Price { get; set; }
    public AppUser User { get; set; }
    public Status Status { get; set; }
}

public enum Status
{
    New,
    Accepted,
    Decline,
}
