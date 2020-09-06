
using AggriPortal.API.Contracts.Response;
using System;
using System.Collections.Generic;

namespace  AggriPortal.API.Resources
{
   public  class PolicieInvoiceResponseDto : BaseResponse
    {
        public string PolicyReferenceId { get; set; }
        public string QuoteReferenceId { get; set; }
        public string PolicyNumber { get; set; }
        public DateTime InvoiceDate { get; set; }
        public PolicyInsuredInfoDto InsuredInfo { get; set; }
        public PolicyVehicleInfoDto VehicleInfo { get; set; }
        public InsuranceCompanyDto InsuranceCompany { get; set; }
        public PolicyProductDto Product { get; set; }
        public List<PolicyLinkDto> Links { get; set; }
    }
}
