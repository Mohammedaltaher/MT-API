
using AggriPortal.API.Contracts.Response;
using System;
using System.Collections.Generic;

namespace  AggriPortal.API.Resources
{
    public class ClientPoliciesRequestDto
    {
        public Guid ClientId { get; set; }
        public int? PageNumber { get; set; }
        public int? PageSize { get; set; }


    }

    public  class ClientPoliciesResponseDto : BaseResponse
    {
        public IEnumerable<ClientPoliciesDto> Data { get; set; }
        public int? TotalRecord { get; set; }

    }
    public class ClientPoliciesDto
    {
        public Guid Id { get; set; }
        public string ClientName { get;  set; }
        public string ClientNameAr { get;  set; }
        public string InsuranceCompanyName { get; set; }
        public string InsuranceCompanyNameAr { get; set; }
        public string PolicyRequestRefId { get; set; }
        public string QuotationRequestRefId { get; set; }
        public string ProductTypeName { get; set; }
        public string ProductTypeNameAr { get; set; }
        public string PolicyNumber { get; set; }
        public DateTime PolicyIssueDate { get; set; }
        public DateTime PolicyEffectiveDate { get; set; }
        public DateTime PolicyExpiryDate { get; set; }
        public decimal VehicleSumInsured { get; set; }
        public decimal DeductibleAmount { get; set; }
        public decimal TotalPremium { get; set; }
        public bool IsPolicyFileSent { get; set; }
        public string PolicyFilePath { get; set; }
        public string PolicyFile { get; set; }
        public int ExpiryingIn { get; set; }
        public bool IsNajmUpdated { get; set; }
        public DateTime? NajmUpdatedDate { get; set; }
        public string NajmVehicleReferenceId { get; set; }
        public DateTime CreatedDate { get; set; }
        public string CreatedBy { get; set; }

    }
}
