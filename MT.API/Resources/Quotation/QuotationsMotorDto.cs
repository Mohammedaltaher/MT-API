
using AggriPortal.API.Contracts.Response;
using System;
using System.Collections.Generic;

namespace  AggriPortal.API.Resources
{
   public  class QuotationsMotorResponseDto : BaseResponse
    {
        public IEnumerable<ClientQuotationsMotorDto> Data { get; set; }
        public int? TotalRecord { get; set; }


    }
    public class QuotationsMotorDetailsResponseDto : BaseResponse
    {
        public Guid ReferenceId { get; set; }
        public InsuredInfoDto InsuredInfo { get; set; }
        public VehicleInfoDto VehicleInfo { get; set; }
        public PreviewQuoteDto QuoteInfo { get; set; }
        public IEnumerable<VechicleDriversDto> VehicleDrivers { get; set; }

    }
    public class ClientQuotationsMotorDto
    {
        public Guid Id { get; set; }
        public DateTime QuotationStartDate { get; set; }
        public DateTime QuotationEndDate { get; set; }
        public decimal MaxLiability { get; set; }
        public decimal DeductibleValue { get; set; }
        public decimal TotalPremium { get; set; }
        public int StatusId { get; set; }

        //Insured
        public long InsuredIdentityNumber { get; set; }
        public string InsuredBirthDate { get; set; }
        public string InsuredFirstName { get; set; }
        public string InsuredMiddleName { get; set; }
        public string InsuredLastName { get; set; }
        public string InsuredFirstNameAr { get; set; }
        public string InsuredMiddleNameAr { get; set; }
        public string InsuredLastNameAr { get; set; }
        public int? ChildrenUnder16Years { get; set; }
        public string InsuredStreet { get; set; }
        public string InsuredDistrict { get; set; }
        public string InsuredCity { get; set; }
        public int? InsuredPostalCode { get; set; }
        public int? InsuredAdditionalNumber { get; set; }
        //Vehicle
        public string VehiclePlateFirstLetterName { get; set; }
        public string VehiclePlateFirstLetterNameAr { get; set; }
        public string VehiclePlateSecondLetterName { get; set; }
        public string VehiclePlateThirdLetterName { get; set; }
        public string VehiclePlateThirdLetterNameAr { get; set; }
        public string VehicleMakerName { get; set; }
        public string VehicleMakerNameAr { get; set; }
        public string VehicleModelName { get; set; }
        public string VehicleModelNameAr { get; set; }
        public string VehicleMajorColorName { get; set; }
        public string VehicleMajorColorNameAr { get; set; }
        public string VehicleBodyTypeName { get; set; }
        public string VehicleBodyTypeNameAr { get; set; }
        public string VehicleRegistrationCityName { get; set; }
        public string VehicleRegistrationCityNameAr { get; set; }
        public string VehicleUseName { get; set; }
        public string VehicleUseNameAr { get; set; }
        public string VehicleTransmissionTypeName { get; set; }
        public string VehicleTransmissionTypeNameAr { get; set; }
        public string VehicleAxleWeightName { get; set; }
        public string VehicleAxleWeightNameAr { get; set; }
        public int VehiclePlateNumber { get; set; }
        public string VehicleChassisNumber { get; set; }
        public string VehicleOwnerName { get; set; }
        public long? VehicleOwnerIdentityNumber { get; set; }
        public int VehicleModelYear { get; set; }
        public int? VehicleCylinders { get; set; }
        public int? VehicleWeight { get; set; }
        public int? VehicleCapacity { get; set; }
        public bool IsVehicleOwnerTransfer { get; set; }
        public string VehicleModificationDetails { get; set; }
        public int? NCDFreeYearId { get; set; }
        public string NCDReference { get; set; }
        /// <summary>
        /// Insert vehicle specification Id as 1,2,3
        /// </summary>
        public string VehicleSpecifications { get; set; }
        public bool IsExternalLogin { get; set; }
        public DateTime CreatedDate { get; set; }
        public string CreatedBy { get; set; }

       
    }
    public class PreviewQuoteDto
    {
        public Guid QuotationReqtId { get; set; }
        public int InsuranceCompanyId { get; set; }
        public InsuranceCompanyDto InsuranceCompany { get; set; }
        public string QuoteReferenceId { get; set; }
        public DateTime QuotationStartDate { get; set; }
        public DateTime QuotationEndDate { get; set; }
        public PreviewQuoteProductDto Product { get; set; }
    }
    public class PreviewQuoteProductDto
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
