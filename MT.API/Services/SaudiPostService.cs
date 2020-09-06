using AggriPortal.API.Contracts.Response;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text.Json;

namespace  AggriPortal.API.Services
{
    public class SaudiPostService
    {
        public HttpClient Client { get; }
        public SaudiPostService(HttpClient client)
        {
            client.BaseAddress = new Uri("http://localhost");
            Client = client;
        }
        public AllSaudiPostResponse AllAddresses()
        {
            AllSaudiPostResponse result = new AllSaudiPostResponse();
            try
            {
                string jsonDb = Path.Combine(Directory.GetCurrentDirectory(), $"wwwroot\\Db\\SaudiPost.json");
                using (StreamReader r = new StreamReader(jsonDb))
                {
                    string json = r.ReadToEnd();
                    result.Data = JsonSerializer.Deserialize<List<SaudiPostInfo>>(json, new JsonSerializerOptions
                    {
                        PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                        WriteIndented = true
                    });
                }
                result.IsSuccess = true;
                result.StatusCode = 200;
                result.ResponseMessage = "Request has been completed successfully.";
            }
            catch (Exception ex)
            {

                result.IsSuccess = false;
                result.StatusCode = 500;
                result.ResponseMessage = ex.Message.ToString();
            }
            return result;
        }
        
        /// <summary>
        /// Get Address by national ID.
        /// </summary>
        /// <param name="nationalID"></param>
        /// <returns></returns>
        public SaudiPostResponse GetInsuredSaudiAddress(long nationalID)
        {
            var response = this.AllAddresses();
            if (!response.IsSuccess)
            {
                return new SaudiPostResponse { IsSuccess = false, StatusCode = 500, ResponseMessage = "Error! can't connect to saudi post service" };
            }
            var data = response.Data.Where(p => p.InsuredId == nationalID).FirstOrDefault();
            if (data != null)
            {
                return new SaudiPostResponse { Data = data, IsSuccess = true, StatusCode = 200, ResponseMessage = "Resquest has been completed successfully." };
            }
            else
            {
                return new SaudiPostResponse { IsSuccess = false, StatusCode = 404, ResponseMessage = "Not found." };
            }
        }
    }
}
