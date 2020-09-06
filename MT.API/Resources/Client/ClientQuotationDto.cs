
using AggriPortal.API.Contracts.Response;
using System;
using System.Collections.Generic;

namespace  AggriPortal.API.Resources
{
    public class ClientQuotationRequestDto
    {
        public Guid ClientId { get; set; }
        public int? PageNumber { get; set; }
        public int? PageSize { get; set; } 
    }
    public class ClientQuotationResponseDto : BaseResponse
    {
        public IEnumerable<PreviewClientQuoteResponseDto> Data { get; set; }
    }
    public class PreviewClientQuoteResponseDto  
    {
        public Guid ReferenceId { get; set; }
        public InsuredInfoDto InsuredInfo { get; set; }
        public VehicleInfoDto VehicleInfo { get; set; }
      ///  public IEnumerable<PreviewVehicleDriverDto> VehicleDrivers { get; set; }
    }

    public class PreviewClientVehicleDriverDto
    {
        public int TypeId { get; set; }
        public long IdentityNumber { get; set; }
        public string FullName { get; set; }
        public string FullNameAr { get; set; }
        public string BirthDate { get; set; }
        public int? DrivingPercentageId { get; set; }
    }
    public class PreviewClientQuoteDto
    {
        public Guid QuotationReqtId { get; set; }
        public int InsuranceCompanyId { get; set; }
        public InsuranceCompanyDto InsuranceCompany { get; set; }
        public string QuoteReferenceId { get; set; }
        public DateTime QuotationStartDate { get; set; }
        public DateTime QuotationEndDate { get; set; }
    }

    public class PreviewClientQuoteProductDto
    {
        public Guid QuotationProductId { get; set; }
        public int ProductTypeId { get; set; }
        public string Name { get; set; }
        public string NameAr { get; set; }
        public DateTime PolicyEffectiveDate { get; set; }
        public DateTime PolicyExpiryDate { get; set; }
        public ProductDeductibleDto Deductibles { get; set; }
        public List<ProductBenefitDto> Benefits { get; set; }

    }

}

