
using AggriPortal.API.Contracts.Response;
using System;
using System.Collections.Generic;

namespace  AggriPortal.API.Resources
{
    public class APILogHistoryRequestDto
    {
        public string Method { get; set; }
        public int? StatusCode { get; set; }
        public DateTime? DateFrom { get; set; }
        public DateTime? DateTo { get; set; }
        public int? PageNumber { get; set; }
        public int? PageSize { get; set; }
    }
    public  class APILogHistoryResponseDto : BaseResponse
    {
        public IEnumerable<APILogHistoryDto> Data { get; set; }
        public int? TotalRecord { get; set; }

    }
    public class APILogHistoryDto
    {
        public string Method { get; set; }
        public string Schema { get; set; }
        public string Host { get; set; }
        public string Path { get; set; }
        public string QueryString { get; set; }
        public string RequestBody { get; set; }
        public string ResponseBody { get; set; }
        public int StatusCode { get; set; }
        public DateTime CreatedDate { get; set; }
        public string CreatedBy { get; set; }
    }
}
