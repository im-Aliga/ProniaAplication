﻿
using FluentValidation.AspNetCore;
using FluentValidation;
using Microsoft.EntityFrameworkCore;

namespace BackEndFinalProject.Infrastructure.Configurations
{
    public static class FluentValidationConfigurations
    {
        public static void ConfigureFluentValidatios(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddFluentValidationAutoValidation();
            services.AddValidatorsFromAssemblyContaining<Program>();
        }
    }
}
