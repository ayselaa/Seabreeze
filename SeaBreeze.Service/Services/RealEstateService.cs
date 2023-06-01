using Microsoft.EntityFrameworkCore;
using SeaBreeze.Domain;
using SeaBreeze.Service.DTOS.Hotel;
using SeaBreeze.Service.DTOS.RealEstate;
using SeaBreeze.Service.Interfaces;

namespace SeaBreeze.Service.Services
{
    public class RealEstateService : IRealEstate
    {
        private readonly AppDbContext _context;


        public RealEstateService(AppDbContext context)
        {
            _context = context;
        }



        public async Task<List<RealEstateGetAllDto>> GetAll()
        {
            var realEstates = await _context.RealEstates.Select(re => new RealEstateGetAllDto
            {
                Id = re.Id,
                Name = re.Name,
                Logo = re.Logo,
                Image = re.Galleries.FirstOrDefault(rei => rei.IsMain).ImageUrl
            })
            .ToListAsync();

            return realEstates;
        }


        public async Task<GetHotelDetail> GetById(string lang, int Id)
        {
            var hotelDetail = await _context.RealEstates
               .Where(h => h.Id == Id)
               .Select(h => new GetHotelDetail
               {
                   Id = h.Id,
                   Name = h.Name,
                   Logo = h.Logo,
                   PhoneNumber = h.PhoneNumber,
                   Desciription = h.RealEstateTranslates.FirstOrDefault(ht => ht.LangCode == lang).Desciription,
                   HotelEssentials = h.Essentials.Select(he => new HotelEssentialDto
                   {
                       ImageUrl = he.ImageUrl,
                       Name = he.Transaltes.FirstOrDefault(het => het.LangCode == lang).Title
                   })
                   .ToList(),
                   HotelGalleries = h.Galleries.Select(hi => new HotelGalleryDto
                   {
                       IsMain = hi.IsMain,
                       Url = hi.ImageUrl
                   })
                   .ToList()
               })
               .FirstOrDefaultAsync();

            return hotelDetail;
        }
    }
}
