namespace SeaBreeze.Service.DTOS.Hotel
{
    public class GetHotelDetail
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<HotelEssentialDto> HotelEssentials { get; set; }
        public string? Desciription { get; set; }
        public string? Logo { get; set; }
        public string? PhoneNumber { get; set; }
        public List<HotelGalleryDto> HotelGalleries { get; set; }

    }
}
