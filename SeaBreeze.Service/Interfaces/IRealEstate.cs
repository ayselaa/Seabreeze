using SeaBreeze.Service.DTOS.Hotel;
using SeaBreeze.Service.DTOS.RealEstate;

namespace SeaBreeze.Service.Interfaces
{
    public interface IRealEstate
    {
        Task<List<RealEstateGetAllDto>> GetAll();
        Task<GetHotelDetail> GetById(string lang, int Id);
    }
}
