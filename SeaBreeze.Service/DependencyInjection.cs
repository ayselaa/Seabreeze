using Microsoft.Extensions.DependencyInjection;
using SeaBreeze.Service.Helpers;
using SeaBreeze.Service.Helpers.CurrentUser;
using SeaBreeze.Service.Helpers.TicketValidation;
using SeaBreeze.Service.Helpers.TokenService;
using SeaBreeze.Service.Interfaces;
using SeaBreeze.Service.Services;

namespace SeaBreeze.Service
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddServiceLayer(this IServiceCollection services)
        {
            services.AddScoped<IAccountService, AccountService>();
            services.AddScoped<ITokenService, TokenService>();
            services.AddScoped<ICurrentUser, CurrentUser>();
            services.AddScoped<TicketValidation, TicketValidation>();
            services.AddScoped<PriceCalculator, PriceCalculator>();
            services.AddScoped<ITicketService, TicketService>();
            services.AddScoped<IStoryService, StoryService>();
            services.AddScoped<IEmailService, EMailService>();
            services.AddScoped<EmailSettings>();
            services.AddScoped<IRealEstate, RealEstateService>();

            services.AddScoped<IHotelService, HotelService>();
            services.AddScoped<IPaymentService, PaymentService>();
            services.AddScoped<ILocalizing, LocalizingService>();

            return services;
        }
    }
}
