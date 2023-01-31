
using BackEndFinalProject.Services.Abstracts;
using BackEndFinalProject.Services.Concretes;
using DemoApplication.Services.Concretes;
using Microsoft.EntityFrameworkCore;

namespace BackEndFinalProject.Infrastructure.Configurations
{
    public static class RegisterCustomServicesConfigurations
    {
        public static void RegisterCustomServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IEmailService, SMTPService>();
            services.AddScoped<IFileService, FileService>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IUserActivationService, UserActivationService>();
            services.AddScoped<IBasketService, BasketService>();
            services.AddScoped<IOrderService, OrderService>();
        }
    }
}
