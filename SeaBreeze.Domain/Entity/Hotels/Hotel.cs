namespace SeaBreeze.Domain.Entity.Hotels
{
    public class Hotel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Logo { get; set; }
        public string PhoneNumber { get; set; }
        public bool IsActive { get; set; }
        public decimal? Price { get; set; }
        public string Email { get; set; }

        public List<HotelTranslate> HotelTranslates { get; set; }
        public List<HotelEssentials> Essentials { get; set; }
        public List<HotelImages> HotelImages { get; set; }
    }
}
