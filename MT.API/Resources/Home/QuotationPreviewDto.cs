
using AggriPortal.API.Contracts.Response;
using System;
using System.Collections.Generic;

namespace  AggriPortal.API.Resources
{
    public class QuotationPreviewResponseDto :BaseResponse
    {
        public QoutationDetailsDto QoutationDetails { get; set; }
        public  QoutationClinetDetailsDto QoutationClinetDetails { get; set; }
        public IEnumerable< VechicleDriversDto> VechicleDrivers { get; set; }
        public IEnumerable<QoutationBenefitDto> qoutationBenefit { get; set; }
    }
    public class QoutationDetailsDto
    {
        public string Id { get; set; }
        public DateTime PolicyEffectiveDate { get; set; }
        public string ProductTypeName { get; set; }
        public string ProductTypeNameAr { get; set; }
        public string VehicleModelName { get; set; }
        public string VehicleModelNameAr { get; set; }
        public string VehicleColorName { get; set; }
        public string VehicleColorNameAr { get; set; }
        public long VehicleId { get; set; }
        public string DrivingCityNameAr { get; set; }
        public string DrivingCityName { get; set; }
        public string VehicleRepairMethodNameAr { get; set; }
        public string VehicleRepairMethodName { get; set; }
        public string InsuranceCompanyName { get; set; }
        public string InsuranceCompanyNameAr { get; set; }
        public string InsuranceCompanyPhone { get; set; }
        public string InsuranceCompanyEmail { get; set; }
    }
    public class QoutationClinetDetailsDto
    {
        public string Id { get; set; }
        public string FullName { get; set; }
        public string FullNameAr { get; set; }
        public string BirthDate { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
    }
    
    public class QoutationAttachmentsDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string NameAr { get; set; }
    }
    public class QoutationBenefitDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string NameAr { get; set; }
        public decimal? BenefitAmount { get; set; }
        
    }

}

