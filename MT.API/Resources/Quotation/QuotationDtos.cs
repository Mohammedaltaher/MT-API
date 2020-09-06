using AggriPortal.API.Contracts.Response;
using System;
using System.Collections.Generic;

namespace  AggriPortal.API.Resources
{
    public class QuotationRequestDto
    {
        public long? InsuredIdentityNumber { get; set; }
        public int? InsuredNationalityId { get; set; }
        public string InsuredFirstName { get; set; }
        public string InsuredFirstNameAr { get; set; }
        public int? VehiclePlateNumber { get; set; }
        public int? StatusId { get; set; }
        public DateTime? DateFrom { get; set; }
        public DateTime? DateTo { get; set; }
        public int? PageNumber { get; set; }
        public int? PageSize { get; set; }


    }
    public class QuotationResponseDto : BaseResponse
    {
        public InsuredInfoDto InsuredInfo { get; set; }
        public VehicleInfoDto VehicleInfo { get; set; }
        public List<QuoteDto> Quotes { get; set; }
    }
    public class InsuredInfoDto
    {
        public string ClientId { get; set; }
        public long IdentityNumber { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string FirstNameAr { get; set; }
        public string MiddleNameAr { get; set; }
        public string LastNameAr { get; set; }
        public string BirthDate { get; set; }
    }
    public class VehicleInfoDto
    {
        public long VehicleId { get; set; }
        public decimal SumInsured { get; set; }
        public int PlateNumber { get; set; }
        public string PlateFirstLetter { get; set; }
        public string PlateSecondLetter { get; set; }
        public string PlateThirdLetter { get; set; }
        public string PlateFirstLetterAr { get; set; }
        public string PlateSecondLetterAr { get; set; }
        public string PlateThirdLetterAr { get; set; }
        public string ColorAr { get; set; }
        public int ModelYear { get; set; }
        public string Maker { get; set; }
        public string MakerLogo { get; set; }
        public string Model { get; set; }
        public string DrivingCity { get; set; }
        public string DrivingCityAr { get; set; }
        public string RepairMethod { get; set; }
        public string RepairMethodAr { get; set; }
    }
    public class QuoteDto
    {
        public Guid QuotationReqtId { get; set; }
        public string RequestReferenceId { get; set; }
        public int InsuranceCompanyId { get; set; }
        public InsuranceCompanyDto InsuranceCompany { get; set; }
        public string QuotationId { get; set; }
        public DateTime QuotationStartDate { get; set; }
        public DateTime QuotationEndDate { get; set; }
        public List<QuotationProductDto> Products { get; set; }
    }
    public class QuotationProductDto
    {
        public Guid QuotationProductId { get; set; }
        public int ProductTypeId { get; set; }
        public string Name { get; set; }
        public string NameAr { get; set; }
        public DateTime PolicyEffectiveDate { get; set; }
        public DateTime PolicyExpiryDate { get; set; }
        public List<ProductDeductibleDto> Deductibles { get; set; }
        public List<ProductBenefitDto> Benefits { get; set; }
        
    }
    public class ProductDeductibleDto
    {
        public decimal DeductibleValue { get; set; }
        public decimal TotalPremium { get; set; }
        public decimal MaxLiability { get; set; }
        public List<ProductPremiumBreakdownDto> PremiumBreakdowns { get; set; }
        public List<ProductDiscountDto> Discounts { get; set; }
    }
    public class ProductBenefitDto
    {
        public int BenefitId { get; set; }
        public int BenefitTypeId { get; set; }
        public string Name { get; set; }
        public string NameAr { get; set; }
        public decimal BenefitAmount { get; set; }
        public decimal BenefitVATAmount { get; set; }
    }
    public class ProductPremiumBreakdownDto
    {
        public int BreakdownTypeId { get; set; }
        public string Name { get; set; }
        public string NameAr { get; set; }
        public double BreakdownPercentage { get; set; }
        public double BreakdownAmount { get; set; }
    }
    public class ProductDiscountDto
    {
        public int DiscountTypeId { get; set; }
        public string Name { get; set; }
        public string NameAr { get; set; }
        public double DiscountPercentage { get; set; }
        public double DiscountAmount { get; set; }
        public int? NCDFreeYears { get; set; }
    }

}
