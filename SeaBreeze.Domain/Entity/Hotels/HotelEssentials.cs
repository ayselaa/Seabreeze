using SeaBreeze.Domain.Entity.RealEsstates;

namespace SeaBreeze.Domain.Entity.Hotels
{
    public class HotelEssentials
    {
        public int Id { get; set; }
        public string ImageUrl { get; set; }
        public List<HotelEssentialTranslate> Transaltes { get; set; }
        public List<Hotel> Hotels { get; set; }
        public List<RealEstate> RealEstates { get; set; }
    }
}
