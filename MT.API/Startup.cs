using AggriPortal.API.Extensions;
using AggriPortal.API.Installers;
using AggriPortal.API.Options;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using AggriPortal.API.Helper.Middlewares;
using System.Reflection;
using AggriPortal.API.Security.Permission;

namespace  AggriPortal.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.InstallServicesInAssembly(Configuration);
            
        }
        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler(new ExceptionHandlerOptions
                {
                    ExceptionHandler = new JsonExceptionMiddleware(env).Invoke
                });
                //app.UseHsts();
            }
            app.UseCors("AggriPortalPolicy");
            app.UseRequestLocalization();
            app.UseStaticFiles();
            app.UseHttpsRedirection();
            app.UseAuthentication();
            app.UseAuthorization();
            app.UseRequestResponseLogging();
            SwaggerOption swaggerOptions = new SwaggerOption();
            Configuration.GetSection(nameof(SwaggerOption)).Bind(swaggerOptions);


            /// Config Swagger.
            app.UseSwagger(option => { option.RouteTemplate = swaggerOptions.JsonRoute; });
            app.UseSwaggerUI(options => { options.SwaggerEndpoint(swaggerOptions.UIEndpoint, swaggerOptions.Description); });
            //app.UseExceptionHandler();
#pragma warning disable MVC1005 // Cannot use UseMvc with Endpoint Routing.
            app.UseMvc();
#pragma warning restore MVC1005 // Cannot use UseMvc with Endpoint Routing.
        }
    }
}
