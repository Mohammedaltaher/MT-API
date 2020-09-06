
using AggriPortal.API.Contracts.Response;
using System;
using System.Collections.Generic;

namespace  AggriPortal.API.Resources
{
    public class PolicyRequestDto
    {

        public string ClientName { get; set; }
        public int? InsuranceCompanyId { get; set; }
        public string PolicyRequestRefId { get; set; }
        public string QuotationRequestRefId { get; set; }
        public string InsuranceQuotationId { get; set; }
        public long? VehicleId { get; set; }
        public long? InsuredId { get; set; }
        public int? ProductTypeId { get; set; }
        public int? VehiclePlateNumber { get; set; }
        public DateTime? DateFrom { get; set; }
        public DateTime? DateTo { get; set; }
        public int? PageNumber { get; set; }
        public int? PageSize { get; set; }


    }
    public class PoliciesMotorResponseDto : BaseResponse
    {
        public IEnumerable<PoliciesMotorDto> Data { get; set; }
        public int? TotalRecord { get; set; }

    }
    public class PoliciesMotorDetailsResponseDto : BaseResponse
    {
        public Guid Id { get; set; }
        public string PolicyReferenceId { get; set; }
        
        public string QuoteReferenceId { get; set; }
        public string PolicyNumber { get; set; }
        public PolicyInsuredInfoDto InsuredInfo { get; set; }
        public PolicyVehicleInfoDto VehicleInfo { get; set; }
        public InsuranceCompanyDto InsuranceCompany { get; set; }
        public PolicyProductDto Product { get; set; }
        public List<PolicyLinkDto> Links { get; set; }
    }
    
    public class PoliciesMotorDto
    {
        public Guid Id { get; set; }
        public string FullName { get; set; }
        public string FullNameAr { get; set; }
        public string InsuranceCompanyName { get; set; }
        public string InsuranceCompanyNameAr { get; set; }
        public string ProductTypeName { get; set; }
        public string ProductTypeNameAr { get; set; }
        public string PolicyNumber { get; set; }
        public DateTime PolicyIssueDate { get; set; }
        public DateTime PolicyEffectiveDate { get; set; }
        public DateTime PolicyExpiryDate { get; set; }
        public decimal VehicleSumInsured { get; set; }
        public decimal DeductibleAmount { get; set; }
        public decimal TotalPremium { get; set; }
        public decimal TotalVATAmount { get; set; }
        public decimal TotalCompCommission { get; set; }
        public decimal CompCommissionPerc { get; set; }
        public decimal TotalCompCommissionVATAmount { get; set; }
        public decimal CompCommissionVATPerc { get; set; }
        public bool IsPolicyFileSent { get; set; }
        public string PolicyFilePath { get; set; }
        public string PolicyFile { get; set; }
        public bool IsNajmUpdated { get; set; }
        public DateTime? NajmUpdatedDate { get; set; }
        public string NajmVehicleReferenceId { get; set; }
        public int ExpiryingIn { get; set; }
        public DateTime CreatedDate { get; set; }
        public string CreatedBy { get; set; }

    }

    public class PolicyProductDto
    {
        public string Name { get; set; }
        public string NameAr { get; set; }
        public DateTime PolicyIssueDate { get; set; }
        public DateTime PolicyEffectiveDate { get; set; }
        public DateTime PolicyExpiryDate { get; set; }
        public ProductDeductibleDto Deductibles { get; set; }
        public List<ProductBenefitDto> Benefits { get; set; }

    }
    public class PolicyInsuredInfoDto
    {
        public long IdentityNumber { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string FirstNameAr { get; set; }
        public string MiddleNameAr { get; set; }
        public string LastNameAr { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
    }

    public class PolicyVehicleInfoDto
    {
        public long VehicleId { get; set; }
        public int PlateNumber { get; set; }
        public string PlateFirstLetter { get; set; }
        public string PlateSecondLetter { get; set; }
        public string PlateThirdLetter { get; set; }
        public int ModelYear { get; set; }
        public string Maker { get; set; }
        public string Model { get; set; }
    }

    public class PolicyLinkDto
    {
        public string Name { get; set; }
        public string Url { get; set; }
    }
}
