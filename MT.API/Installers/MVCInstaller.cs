using FluentValidation.AspNetCore;
using AggriPortal.API.Options;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Collections.Generic;
using Microsoft.OpenApi.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using AggriPortal.API.Helper.Validation;
using AutoMapper;
using AggriPortal.API.Helper.Security.Tokens;
using Microsoft.IdentityModel.Logging;
using AggriPortal.API.Services;
using System.Globalization;
using Microsoft.AspNetCore.Localization;
using AggriPortal.API.Globalizations;
using AggriPortal.API.Security.Permission;
using System.Reflection;

namespace  AggriPortal.API.Installers
{
    public class MVCInstaller : IInstaller
    {
        public bool RequireHttpsMetadata { get; private set; }

        public void InstallServices(IServiceCollection services, IConfiguration configuration)
        {
            IdentityModelEventSource.ShowPII = true;
            services.Configure<FormOptions>(options =>
            {
                options.KeyLengthLimit = 5 * 1024;
            });
            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });

            // Add Cors
            services.AddCors(options => {
                options.AddPolicy("AggriPortalPolicy", builder =>
                builder
                .AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader()
                );
            });
           
            // Add globalization
            services.AddLocalization();
            services.Configure<RequestLocalizationOptions>(options => 
            {
                var supportedCultures = new List<CultureInfo>
                {
                    new CultureInfo("en-US"),
                    new CultureInfo("ar-SA")
                };
                options.DefaultRequestCulture = new RequestCulture("ar-SA");
                options.SupportedCultures = supportedCultures;
                options.SupportedUICultures = supportedCultures;
                options.RequestCultureProviders.Clear();
                //options.RequestCultureProviders.Add(new  AcceptLanguageHeaderRequestCultureProvider());
                options.RequestCultureProviders.Add(new MyCustomRequestCultureProvider());
                // use this line when to you want to get lang from url.
                //options.RequestCultureProviders.Add(new RouteValueRequestCultureProvider(supportedCultures));
            });
            
            // Add AutoMapper
            services.AddAutoMapper(typeof(Startup));
            
            // Add MVC
            services.AddMvc(options => { 
                options.EnableEndpointRouting = false;
                //options.Filters.Add(typeof(ModelStateFeatureFilter));
            }).AddFluentValidation(config => config.RegisterValidatorsFromAssemblyContaining<Startup>())
                    .AddDataAnnotationsLocalization()
                    .SetCompatibilityVersion(CompatibilityVersion.Version_3_0);

            // Add Custom Entity Validation 
            services.Configure<ApiBehaviorOptions>(options =>
            {
                options.InvalidModelStateResponseFactory = ctx => new ValidationErrorResult();
            });

            // Add HttpContextAccessor to get the user ip.
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            // Add Options snapshot here
            #region Option Pattrens
            services.AddOptions();
            var tokenOption = configuration.GetSection("TokenOption").Get<TokenOption>();
            services.Configure<TokenOption>(configuration.GetSection("TokenOption"));

            var signingConfigurations = new SigningConfigurations();
            services.AddSingleton(signingConfigurations);

            services.Configure<SmtpOptions>(configuration.GetSection(nameof(SmtpOptions)));
            services.AddTransient<IMessagerService, MessagerService>();
            #endregion

            // Add Bearer authentication.
            #region Bearer authentication.
            var key = Encoding.ASCII.GetBytes(tokenOption.Secret);
            services.AddAuthentication(option =>
            {
                option.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                option.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
                option.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(option =>
            {
                RequireHttpsMetadata = false;
                option.SaveToken = true;
                option.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = signingConfigurations.Key,
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidIssuer = tokenOption.Issuer,
                    ValidAudience = tokenOption.Audience
                };
            });
           
            #endregion
            #region Bearer swagger configuration.
            services.AddSwaggerGen(option =>
            {
                option.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "Insurance Aggrigator(Admin API)",
                    Version = "v1"
                });

                var security = new Dictionary<string, IEnumerable<string>>
                {
                    { "Bearer", new string[0] }
                };



                option.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Name = "Authorization",
                    Description = "JWt Auth using bearer scheme",
                    In =  ParameterLocation.Header,
                    Type = SecuritySchemeType.ApiKey
                });

                option.AddSecurityRequirement( new OpenApiSecurityRequirement 
                {
                    { new OpenApiSecurityScheme { Reference = new OpenApiReference 
                        {
                            Id = "Bearer",
                            Type = ReferenceType.SecurityScheme
                        }
                    }, new List<string>() }
                });
            });
            #endregion
        }
    }
}
