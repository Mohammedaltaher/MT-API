
using AggriPortal.API.Contracts.Response;
using System;
using System.Collections.Generic;

namespace  AggriPortal.API.Resources
{
    public class SMSLogRequestDto
    {
        public string SmsTo { get; set; }
        public string Status { get; set; }
        public DateTime? DateFrom { get; set; }
        public DateTime? DateTo { get; set; }
        public int? PageNumber { get; set; }
        public int? PageSize { get; set; }
    }
    public  class SMSLogResponseDto : BaseResponse
    {
        public IEnumerable<SMSLogDto> Data { get; set; }
        public int? TotalRecord { get; set; }

    }
    public class SMSLogDto
    {
        public string SenderId { get; set; }
        public string SmsTo { get; set; }
        public string SmsMessage { get; set; }
        public string Status { get; set; }
        public string ResultMessage { get; set; }
        public DateTime CreatedDate { get; set; }
        public string CreatedBy { get; set; }
    }
}
