using AggriPortal.API.Contracts.Response;
using AggriPortal.API.Domain.ServiceModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace  AggriPortal.API.Services
{
    public class YakeenService
    {
        public HttpClient Client { get; }

        public YakeenService(HttpClient client)
        {
            client.BaseAddress = new Uri("http://localhost");
            Client = client;
        }

        /// <summary>
        /// Get insured basic data by national ID / Iqama No. and birth date
        /// </summary>
        /// <param name="nationalId"></param>
        /// <returns></returns>
        public async Task<YakeenInsuredInfoResponse> GetInsuredInfoByNatId(long nationalId)
        {
            var response = await Client.GetAsync("http://localhost");
            response.EnsureSuccessStatusCode();
            using var responseStream = await response.Content.ReadAsStreamAsync();
            return await JsonSerializer.DeserializeAsync<YakeenInsuredInfoResponse>(responseStream);
        }

        /// <summary>
        /// Get vehicle information by squence number.
        /// </summary>
        /// <param name="squenceNo"></param>
        /// <returns></returns>
        public async Task<YakeenVehicleInfoResponse> GetVehicleInfoBySquenceNo(int squenceNo)
        {
            var response = await Client.GetAsync("http://localhost");
            response.EnsureSuccessStatusCode();
            using var responseStream = await response.Content.ReadAsStreamAsync();
            return await JsonSerializer.DeserializeAsync<YakeenVehicleInfoResponse>(responseStream);
        }

        public AllYakeenVehicleInfoResponse GetVehicles()
        {
            AllYakeenVehicleInfoResponse result = new AllYakeenVehicleInfoResponse();
            try
            {
                string jsonDb = Path.Combine(Directory.GetCurrentDirectory(), $"wwwroot\\Db\\Vehicles.json");
                using (StreamReader r = new StreamReader(jsonDb))
                {
                    string json = r.ReadToEnd();
                    result.Data = JsonSerializer.Deserialize<List<YakeenVehicleInfo>>(json, new JsonSerializerOptions
                    {
                        PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                        WriteIndented = true
                    });
                }
                result.IsSuccess = true;
                result.StatusCode = 200;
                result.ResponseMessage = "Request completed successfully";
            }
            catch (Exception ex)
            {

                result.IsSuccess = false;
                result.StatusCode = 500;
                result.ResponseMessage = ex.Message.ToString();
            }
            return result;
        }

        public YakeenVehicleInfoResponse GetVehicleBySquNo(long squenceNo)
        {
            var response = this.GetVehicles();
            if (!response.IsSuccess)
            {
                return new YakeenVehicleInfoResponse { IsSuccess = false, StatusCode = 500, ResponseMessage = "Error! can't connect to yakken service" };
            }
            var data = response.Data.Where(p => p.VehicleId == squenceNo).FirstOrDefault();
            if(data == null)
            {
                return new YakeenVehicleInfoResponse { IsSuccess = false, StatusCode = 400, ResponseMessage = "الرجاء التحقق من الرقم المتسلسل للمركبة " };
            }
            return  new YakeenVehicleInfoResponse {Data = data,IsSuccess = true,StatusCode = 200,ResponseMessage = "Request completed successfully."};
        }

        public AllYakeenInsuredInfoResponse GetInsuredData()
        {
            AllYakeenInsuredInfoResponse result = new AllYakeenInsuredInfoResponse();
            try
            {
                string jsonDb = Path.Combine(Directory.GetCurrentDirectory(), $"wwwroot\\Db\\Insured.json");
                using (StreamReader r = new StreamReader(jsonDb))
                {
                    string json = r.ReadToEnd();
                    result.Data = JsonSerializer.Deserialize<List<YakeenInsuredInfo>>(json, new JsonSerializerOptions
                    {
                        PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                        WriteIndented = true
                    });
                }
                result.IsSuccess = true;
                result.StatusCode = 200;
                result.ResponseMessage = "Request completed successfully.";
            }
            catch (Exception ex)
            {

                result.IsSuccess = false;
                result.StatusCode = 500;
                result.ResponseMessage = ex.Message.ToString();
            }
            return result;
        }

        public YakeenInsuredInfoResponse GetInsuredData(long natId, string birthDate)
        {
            var response = this.GetInsuredData();
            if (!response.IsSuccess)
            {
                return new YakeenInsuredInfoResponse { IsSuccess = false, StatusCode = 500, ResponseMessage = "Error! can't connect to yakken service" };
            }

            Func<YakeenInsuredInfo, bool> exp = (t) => true;
            int identityTypeId = Convert.ToInt32(natId.ToString().Substring(0,1));
            switch (identityTypeId)
            {
                case 1:
                    exp = h => h.IdentityNumber == natId && h.DateOfBirthH == birthDate;
                    break;
                case 2:
                    exp = g => g.IdentityNumber == natId && g.DateOfBirthG == birthDate;
                    break;
                default:
                    break;
            }
            var data = response.Data.Where(exp).FirstOrDefault();
            if(data != null)
            {
                return  new YakeenInsuredInfoResponse {Data = data,IsSuccess = true,StatusCode = 200,ResponseMessage = "Resquest completed successfully."};
            }
            else
            {
                return new YakeenInsuredInfoResponse { IsSuccess = false, StatusCode = 400, ResponseMessage = "Not found." };
            }
            
        }
    }
}
