using SeaBreeze.Domain.Entity.Hotels;

namespace SeaBreeze.Domain.Entity.RealEsstates
{
    public class RealEstate
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string Logo { get; set; }
        public List<RealEstateTranslate> RealEstateTranslates { get; set; }
        public List<HotelEssentials> Essentials { get; set; }
        public List<Gallery> Galleries { get; set; }
        public List<Detail> RealEstateDetails { get; set; }
        public List<FeatureRealEstate> FeatureRealEstates { get; set; }
    }
}
