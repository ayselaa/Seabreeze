using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using SeaBreeze.Domain;
using SeaBreeze.Domain.Entity.Payment;
using SeaBreeze.Domain.Entity.Tickets;
using SeaBreeze.Domain.Entity.Users;
using SeaBreeze.Service.DTOS.BeachClub;
//using System.IO.InvalidDataException;
using SeaBreeze.Service.DTOS.Order;
using SeaBreeze.Service.DTOS.Ticket;
using SeaBreeze.Service.Exceptions;
using SeaBreeze.Service.Helpers;
using SeaBreeze.Service.Helpers.TicketValidation;
using SeaBreeze.Service.Interfaces;
using System.Globalization;
using static SeaBreeze.Service.Services.PaymentService;
//using Microsoft.AspNet.Identity;

namespace SeaBreeze.Service.Services
{
    public class TicketService : ITicketService
    {
        private readonly AppDbContext _context;
        private readonly TicketValidation _validation;
        private readonly PriceCalculator _calculator;
        private readonly UserManager<AppUser> _userManager;
        private readonly IPaymentService _paymentService;



        public TicketService(AppDbContext context, TicketValidation validation, PriceCalculator calculator, UserManager<AppUser> userManager, IPaymentService paymentService)
        {
            _context = context;
            _validation = validation;
            _calculator = calculator;
            _userManager = userManager;
            _paymentService = paymentService;
        }

        public async Task<PayriffOrder> BuyPremiumTicket(string currentUserId, PremiumOrderDto orderDto)
        {
            var user = await _userManager.FindByIdAsync(currentUserId);

            var existingTicket = await _context.BeachClubTickets
                .SingleOrDefaultAsync(it => it.FIN == orderDto.Fin);

            if (existingTicket != null && existingTicket.IsPremium)
            {
                throw new TicketAlreadyExistException("Qeyd olunmus FIN-e uygun bilet artiq var.");
            }


            var payriffOrder = await _paymentService.CreatePremiumOrder(user, orderDto, _calculator.CalculatePremiumPrice(orderDto.IsPremiumInsured));

            var beachClubTicket = new BeachClubTicket
            {
                Price = _calculator.CalculatePremiumPrice(orderDto.IsPremiumInsured),
                IsActive = true,
                IsRoseBar = false,
                Id = Guid.NewGuid().ToString(),
                Name = user.FullName,
                FIN = orderDto.Fin,
                Season = "2023",
                IsInsured = orderDto.IsPremiumInsured,
                IsPremium = true
            };

            var beachClubOrder = new BeachClubOrder
            {
                Tickets = new List<BeachClubTicket> { beachClubTicket },
                Id = Guid.NewGuid().ToString(),
                CreatedAt = DateTime.UtcNow.AddHours(4),
                TransactionId = Guid.NewGuid().ToString(),
                TotalPrice = beachClubTicket.Price,
                PayriffOrder = payriffOrder
            };




            using var transaction = _context.Database.BeginTransaction();
            try
            {
                if (existingTicket != null)
                {
                    _context.BeachClubTickets.Remove(existingTicket);
                }

                _context.BeachClubOrders.Add(beachClubOrder);
                await _context.SaveChangesAsync();

                transaction.Commit();
            }
            catch (Exception)
            {
                transaction.Rollback();
                throw;
            }

            return payriffOrder;
        }

        public async Task<PayriffOrder> BuyTicket(string currentUserId, OrderDto order)
        {
            var user = await _userManager.FindByIdAsync(currentUserId);
            System.DateOnly date;

            if (System.DateOnly.TryParseExact(order.OrderDate, "dd.MM.yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out date))
            {
                System.DateOnly toDay = System.DateOnly.FromDateTime(DateTime.Now);
                bool isForToday = toDay == date;

                var totalAmount = order.Count * _calculator.CalculatePrice(order.IsInsured, order.IsRosebar, isForToday);

                if (order.Count == 0)
                {
                    throw new Exception("Say daxil edin");
                }
                //decimal roseBarPrice = order.IsRosebar && isForToday ? 30 : 25;
                //decimal beachClubPrice = isForToday ? 20 : 18;
                List<BeachClubTicket> beachClubTickets = Enumerable.Range(0, order.Count)
                    .Select(_ => new BeachClubTicket
                    {
                        Id = Guid.NewGuid().ToString(),
                        Price = _calculator.CalculatePrice(order.IsInsured, order.IsRosebar, isForToday),
                        IsActive = true,
                        CreatedAt = DateTime.UtcNow.AddHours(4),
                        IsRoseBar = order.IsRosebar,
                        IsPremium = false,
                        Season = "2023",
                        IsInsured = order.IsInsured,
                        ValidTime = date,
                        //RoseBarPrice= roseBarPrice,
                        //BeachClubPrice= beachClubPrice     
                    })
                    .ToList();

                var payriffOrder = await _paymentService.CreateOrder(user, order, totalAmount);

                BeachClubOrder beachClubOrder = new BeachClubOrder
                {
                    Id = Guid.NewGuid().ToString(),
                    AppUser = user,
                    CreatedAt = DateTime.UtcNow.AddHours(4),
                    TransactionId = Guid.NewGuid().ToString(),
                    Tickets = beachClubTickets,
                    TotalPrice = totalAmount,
                    PayriffOrder = payriffOrder
                };

                await _context.BeachClubOrders.AddAsync(beachClubOrder);
                await _context.SaveChangesAsync();


                return payriffOrder;
            }
            else
            {
                throw new Exception("Add current date");
            }



        }

        public async Task<string> CheckTicketPayment(CheckOrderDto checkOrderDto)
        {
            var status = await _paymentService.CheckOrderStatus(checkOrderDto);
            return status;
        }


        public async Task<List<BeachClubTicketDto>> GetUserTickets(string userId)
        {
            var currentDate = DateOnly.FromDateTime(DateTime.UtcNow.AddHours(4));

            var userTickets = await _context.BeachClubTickets
                                            .Where(bct =>
                                                bct.BeachClubOrder.AppUser.Id == userId &&
                                               !bct.IsUsed &&
                                                bct.BeachClubOrder.PayriffOrder.status == "APPROVED" &&
                                                bct.ValidTime >= currentDate)
                                            .Select(bct => new BeachClubTicketDto
                                            {
                                                Id = bct.Id,
                                                Date = bct.ValidTime.ToString("dd.MM.yyyy"),
                                                IsEnsured = bct.IsInsured,
                                                IsPremium = bct.IsPremium,
                                                IsRoseBar = bct.IsRoseBar
                                            })
                                            .ToListAsync();

            return userTickets;
        }


        public async Task<TicketStatus> CheckStatus(string tixketId)
        {
            var ticket = await _context.BeachClubTickets.Where(m => m.Id == tixketId).FirstOrDefaultAsync();
            System.DateOnly currentDate = System.DateOnly.FromDateTime(DateTime.Now);

            if (ticket is not null)
            {

                if (ticket.ValidTime != currentDate)
                {
                    throw new Exception("Bilet seçildiyi gün üçün keçərlidir.");
                }

                if (ticket.IsUsed)
                {
                    throw new Exception("Bilet istifadə olunub");
                }


                TicketStatus ticketStatus = new TicketStatus
                {
                    IsEnsured = ticket.IsInsured,
                    IsPremium = ticket.IsPremium,
                    IsValidDay = ticket.ValidTime == currentDate,
                    RoseBar = ticket.IsRoseBar,
                    Used = ticket.IsUsed,
                    Date = ticket.ValidTime.ToString()
                };

                ticket.IsUsed = true;
                ticket.UsedTime = DateTime.UtcNow.AddHours(4);

                _context.BeachClubTickets.Update(ticket);

                return ticketStatus;
            }
            else
            {
                throw new Exception("Tiket tapılmadı");
            }

        }

        public async Task<int> GetRoseBarTicketsPerDay(string dateString)
        {
            System.DateOnly date;

            if ((System.DateOnly.TryParseExact(dateString, "dd.MM.yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out date)))
            {
                int roseBarTicketsCount = _context.BeachClubTickets.Where(bct => bct.IsRoseBar && bct.BeachClubOrder.PayriffOrder.status == "APPROVED" && bct.ValidTime == date).Count();
                return roseBarTicketsCount;
            }
            else
            {
                throw new Exception("Düzgün tarix daxil edin");
            }

        }
    }
}

