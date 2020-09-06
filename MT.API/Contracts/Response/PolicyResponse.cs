using System;

namespace  AggriPortal.API.Contracts.Response
{
    public class IssuePolicyResponse:BaseResponse
    {
        public string PolicyRequestId { get; set; }
        public string QuotationRequestId { get; set; }
        public int InsuranceCompanyId { get; set; }
        public string PolicyNumber { get; set; }
        public DateTime PolicyIssueDate { get; set; }
        public DateTime PolicyEffectiveDate { get; set; }
        public DateTime PolicyExpiryDate { get; set; }
        public string PolicyFileUrl { get; set; }
        public Byte[] PolicyFile { get; set; }
    }
}
