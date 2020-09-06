using AggriPortal.API.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace  AggriPortal.API.Installers
{
    public class ClientInstaller : IInstaller
    {
        public void InstallServices(IServiceCollection services, IConfiguration configuration)
        {
            services.AddHttpClient("smsClient", client =>
            {
                client.BaseAddress = new Uri("http://api.otsdc.com/wrapper/");
            });
            services.AddHttpClient("InsurComp1", client =>
            {
                client.BaseAddress = new Uri("https://insurcomp1.oasisaggrapi.com/api/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Add("Accept", "application/json");
                client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Basic", "MTox");
            });
            services.AddHttpClient("InsurComp2", client =>
            {
                client.BaseAddress = new Uri("https://insurcomp2.oasisaggrapi.com/api/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Add("Accept", "application/json");
                client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Basic", "MTox");
            });
            services.AddHttpClient("InsurComp3", client =>
            {
                client.BaseAddress = new Uri("https://insurcomp3.oasisaggrapi.com/api/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Add("Accept", "application/json");
                client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Basic", "MTox");
            });
            services.AddHttpClient<YakeenService>();
            services.AddHttpClient<SaudiPostService>();
        }
    }
}
