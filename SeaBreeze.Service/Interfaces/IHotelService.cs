using SeaBreeze.Service.DTOS.Hotel;

namespace SeaBreeze.Service.Interfaces
{
    public interface IHotelService
    {
        Task<List<GetAllDto>> GetAll();
        Task<GetHotelDetail> GetById(string lang, int Id);
        Task<bool> ReservHotel(string currentUserId, HotelReservationDto hotelReservationDto);
    }
}
