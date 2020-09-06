using AggriPortal.API.Contracts.Response;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Primitives;
using System;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace  AggriPortal.API.Services
{
    public interface IUserDetectionService
    {
        string GetUserIpAddress();
        string GetUserBrowser();
        string GetAcceptLanguage();
        Task<UserGeoLocationResponse> GetUserGeoLocation(string ipAddress);
    }
    public class UserDetectionService:IUserDetectionService
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private IHttpContextAccessor _accessor;
        public UserDetectionService(IHttpContextAccessor accessor, IHttpClientFactory httpClientFactory)
        {
            _accessor = accessor;
            _httpClientFactory = httpClientFactory;
        }

        public string GetUserIpAddress()
        {
            string ip = string.Empty;
            // RemoteIpAddress is always null in DNX RC1 Update1 (bug).
            if (string.IsNullOrWhiteSpace(ip) && _accessor.HttpContext?.Connection?.RemoteIpAddress != null)
                ip = _accessor.HttpContext.Connection.RemoteIpAddress.ToString();
            return ip;
        }
        public string GetUserBrowser()
        {
            var userAgent = _accessor.HttpContext.Request.Headers["User-Agent"].FirstOrDefault();
            return userAgent ?? string.Empty;
        }

        public string GetAcceptLanguage()
        {
            var acceptLang = _accessor.HttpContext.Request.Headers["Accept-Language"].FirstOrDefault();
            return acceptLang;
        }

        public async Task<UserGeoLocationResponse> GetUserGeoLocation(string ipAddress)
        {
            string key = "fefdad615eaf8d609c70961f721680ab";
            UserGeoLocationResponse result = new UserGeoLocationResponse();
            var client = _httpClientFactory.CreateClient();
            client.BaseAddress = new Uri("http://api.ipstack.com");
            var end_point = string.Format("/{0}?access_key={1}", ipAddress, key);
            var response = await client.GetAsync(end_point);
            if (response.IsSuccessStatusCode)
            {
                var stringData = await response.Content.ReadAsStringAsync();
                result = JsonSerializer.Deserialize<UserGeoLocationResponse>(stringData, new JsonSerializerOptions
                {
                    PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                    WriteIndented = true
                });
                //result = JsonConvert.DeserializeObject<UserGeoLocationResponse>(stringData);
                result.IsSuccess = true;
                result.StatusCode = 200;
                result.ResponseMessage = "Request has been completed successfully";
            }
            else
            {
                result.IsSuccess = false;
                result.StatusCode = (int)response.StatusCode;
                result.ResponseMessage = response.ReasonPhrase.ToString();
            }
            return result;
        }
        private static T GetHeaderValueAs<T>(IHttpContextAccessor _httpAccessor, string headerName)
        {
            StringValues values;

            if (_httpAccessor.HttpContext?.Request?.Headers?.TryGetValue(headerName, out values) ?? false)
            {
                string rawValues = values.ToString();   // writes out as Csv when there are multiple.

                if (rawValues.Length > 0)
                    return (T)Convert.ChangeType(values.ToString(), typeof(T));
            }
            return default(T);
        }


    }
}
