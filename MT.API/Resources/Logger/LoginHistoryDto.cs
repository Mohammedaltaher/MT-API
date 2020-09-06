
using AggriPortal.API.Contracts.Response;
using System;
using System.Collections.Generic;

namespace  AggriPortal.API.Resources
{
    public class LoginHistoryRequestDto
    {
        public Guid ClientId { get; set; }
        public int? PageNumber { get; set; }
        public int? PageSize { get; set; }


    }
    public  class LoginHistoryResponseDto : BaseResponse
    {
        public IEnumerable<ClientLoginHistoryDto> Data { get; set; }
        public int? TotalRecord { get; set; }

    }
    public class ClientLoginHistoryDto
    {
        public string Id { get; set; }
        public string ApplicationUserId { get; set; }
        public string IPAddress { get; set; }
        public string Browser { get; set; }
        public string OS { get; set; }
        public string CountryCode { get; set; }
        public string CountryName { get; set; }
        public string RegionCode { get; set; }
        public string RegionName { get; set; }
        public string City { get; set; }
        public string ZipCode { get; set; }
        public string TimeZone { get; set; }
        public string Latitude { get; set; }
        public string Longitude { get; set; }
        public DateTime CreatedDate { get; set; }
        public string CreatedBy { get; set; }


    }
}
