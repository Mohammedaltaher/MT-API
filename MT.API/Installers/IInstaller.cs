using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace  AggriPortal.API.Installers
{
    public interface IInstaller
    {
        void InstallServices(IServiceCollection services, IConfiguration configuration);
    }
}
