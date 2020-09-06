using AggriPortal.API.Persistence;
using AggriPortal.API.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using AggriPortal.API.Domain.Models;
using AggriPortal.API.Helper.Security.Hashing;
using AggriPortal.API.Helper.Security.Tokens;
using AggriPortal.API.Globalizations;

namespace  AggriPortal.API.Installers
{
    public class DataInstaller : IInstaller
    {
        public void InstallServices(IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<AppDbContext>( options => options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"), sqlOptions=> sqlOptions.EnableRetryOnFailure()),ServiceLifetime.Transient);

            // Add User Identity Configuration.
            #region User Identity Configuration
            services.AddIdentity<ApplicationUser, ApplicationRole>()
                     .AddErrorDescriber<LocalizedIdentityErrorDescriber>()
                    .AddEntityFrameworkStores<AppDbContext>()
            .AddDefaultTokenProviders();  // add seprated config below to token provider

            services.Configure<DataProtectionTokenProviderOptions>(options =>
            {
                options.TokenLifespan = TimeSpan.FromHours(8);
            });
            
            // Configure Identity
            services.Configure<IdentityOptions>(options =>
            {
                // Password settings
                options.Password.RequireDigit = true;
                options.Password.RequiredLength = 8;
                options.Password.RequireNonAlphanumeric = true;
                options.Password.RequireUppercase = true;
                options.Password.RequireLowercase = true;
            });
            #endregion

            // Add Dependancy Injection Here.
            #region Dependancy Injections
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IIdentityService, IdentityService>();
            services.AddScoped<IAuthenticationService, AuthenticationService>();
            services.AddScoped<IGatewayService, GatewayService>();
            services.AddScoped<IHasher, Hasher>();
            services.AddScoped<ITokenHandler, TokenHandler>();
            services.AddSingleton<IUserDetectionService, UserDetectionService>();
           // services.AddSingleton<IPaymentService, PaymentService>();
            services.AddScoped<IQuotationService, QuotationService>();
            #endregion
        }
    }
}
