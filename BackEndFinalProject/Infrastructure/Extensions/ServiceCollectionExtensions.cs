using AspNetCore.IServiceCollection.AddIUrlHelper;
using BackEndFinalProject.Database;
using BackEndFinalProject.Infrastructure.Configurations;
using BackEndFinalProject.Options;
using BackEndFinalProject.Services.Abstracts;
using BackEndFinalProject.Services.Concretes;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;

namespace BackEndFinalProject.Infrastructure.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static void ConfigureServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                .AddCookie(o =>
                {
                    o.Cookie.Name = "Identity";
                    o.ExpireTimeSpan = TimeSpan.FromMinutes(20);
                    o.LoginPath = "/auth/login";
                    o.AccessDeniedPath = "/admin/auth/login";
                });

            services.AddHttpContextAccessor();
            
            services.ConfigureMvc();

            services.AddUrlHelper();

            services.ConfigureDatabase(configuration);

            services.ConfigureOptions(configuration);

            services.ConfigureFluentValidatios(configuration);

            services.RegisterCustomServices(configuration);
        }
    }
}
