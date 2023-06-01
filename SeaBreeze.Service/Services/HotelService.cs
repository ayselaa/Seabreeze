using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using SeaBreeze.Domain;
using SeaBreeze.Domain.Entity.Hotels;
using SeaBreeze.Domain.Entity.Users;
using SeaBreeze.Service.DTOS.Hotel;
using SeaBreeze.Service.Helpers.CurrentUser;
using SeaBreeze.Service.Interfaces;

namespace SeaBreeze.Service.Services
{
    public class HotelService : IHotelService
    {
        private readonly AppDbContext _context;
        private readonly UserManager<AppUser> _userManager;
        private readonly ICurrentUser _currentUser;
        private readonly IEmailService _emailService;

        public HotelService(AppDbContext context, UserManager<AppUser> userManager, ICurrentUser currentUser, IEmailService emailService)
        {
            _context = context;
            _userManager = userManager;
            _currentUser = currentUser;
            _emailService = emailService;
        }


        public async Task<List<GetAllDto>> GetAll()
        {
            var hotels = await _context.Hotels
            .Where(m => m.IsActive)
            .Select(h => new GetAllDto
            {
                Id = h.Id,
                Logo = h.Logo,
                Name = h.Name,
                Image = h.HotelImages.Where(i => i.IsMain).FirstOrDefault().Url
            }).ToListAsync();

            return hotels;
        }


        public async Task<GetHotelDetail> GetById(string lang, int Id)
        {
            var hotelDetail = await _context.Hotels
                .Where(h => h.Id == Id)
                .Select(h => new GetHotelDetail
                {
                    Id = h.Id,
                    Name = h.Name,
                    Logo = h.Logo,
                    PhoneNumber = h.PhoneNumber,
                    Desciription = h.HotelTranslates.FirstOrDefault(ht => ht.LangCode == lang).Description,
                    HotelEssentials = h.Essentials.Select(he => new HotelEssentialDto
                    {
                        ImageUrl = he.ImageUrl,
                        Name = he.Transaltes.FirstOrDefault(het => het.LangCode == lang).Title
                    })
                    .ToList(),
                    HotelGalleries = h.HotelImages.Select(hi => new HotelGalleryDto
                    {
                        IsMain = hi.IsMain,
                        Url = hi.Url
                    })
                    .ToList()
                })
                .FirstOrDefaultAsync();

            return hotelDetail;
        }

        public async Task<bool> ReservHotel(string currentUserId, HotelReservationDto hotelReservationDto)
        {
            var currentUser = await _userManager.FindByIdAsync(currentUserId);
            var hotel = await _context.Hotels.FirstOrDefaultAsync(h => h.Id == hotelReservationDto.HotelId);

            HotelReservation hotelReservation = new HotelReservation
            {
                Id = Guid.NewGuid().ToString(),
                User = currentUser,
                From = hotelReservationDto.From,
                To = hotelReservationDto.To,
                Hotel = hotel,
                BuyTime = DateTime.UtcNow.AddHours(4)
            };


            _emailService.Send(hotel.Email, "Otel Rezervasiyası", $"İstifadəçi : {currentUser.FullName}  " +
                $"  İstifadəçi Nömrəsi :  {currentUser.PhoneNumber}" +
                $"  İstifadəçi epoçtu : {currentUser.Email}" +
                $"  Otel : {hotel.Name}");
            await _context.HotelReservations.AddAsync(hotelReservation);

            return await _context.SaveChangesAsync() > 0;
        }
    }


}
