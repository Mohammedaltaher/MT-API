using System;

namespace  AggriPortal.API.Domain.Models
{
    public class SMSLog
    {
        public Guid Id { get; set; }
        public string SenderId { get; set; }
        public string SmsTo { get; set; }
        public string SmsMessage { get; set; }
        public string Status { get; set; }
        public string ResultMessage { get; set; }
        public DateTime CreatedDate { get; set; }
        public string CreatedBy { get; set; }
    }
}
