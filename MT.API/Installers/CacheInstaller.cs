using AggriPortal.API.Helper.Cache;
using AggriPortal.API.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace  AggriPortal.API.Installers
{
    public class CacheInstaller : IInstaller
    {
        public void InstallServices(IServiceCollection services, IConfiguration configuration)
        {
            var redisCacheSetting = new RedisCacheSetting();
            configuration.GetSection(nameof(RedisCacheSetting)).Bind(redisCacheSetting);
            services.AddSingleton(redisCacheSetting);

            if (!redisCacheSetting.Enabled)
            {
                return;
            }

            services.AddDistributedSqlServerCache(option => {
                option.ConnectionString = configuration.GetConnectionString("DefaultConnection");
                option.SchemaName = "dbo";
                option.TableName = "Cache";
            });
            services.AddSingleton<IResponseCacheService, ResponseCacheService>();
        }
    }
}
