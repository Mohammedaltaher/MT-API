using AutoMapper;
using AggriPortal.API.Contracts.Request;
using AggriPortal.API.Contracts.Response;
using AggriPortal.API.Domain.Models;
using AggriPortal.API.Domain.ServiceModels;
using System.Linq;
using AggriPortal.API.Resources;

namespace  AggriPortal.API.Helper.Mapping
{
    public class ResourceToDomainProfile : Profile
    {
          
        public ResourceToDomainProfile()
        {
            CreateMap<UserGeoLocationResponse, ApplicationUserLoginHistory>()
                .ForMember(p => p.IPAddress, opt => opt.MapFrom(x => x.IP))
                .ForMember(p => p.CountryCode, opt => opt.MapFrom(x => x.Country_code))
                .ForMember(p => p.CountryName, opt => opt.MapFrom(x => x.Country_name))
                .ForMember(p => p.City, opt => opt.MapFrom(x => x.City))
                .ForMember(p => p.RegionCode, opt => opt.MapFrom(x => x.Region_code))
                .ForMember(p => p.RegionName, opt => opt.MapFrom(x => x.Region_name))
                .ForMember(p => p.ZipCode, opt => opt.MapFrom(x => x.Zip));

            // Mapping from yakeen services to  entity.
            CreateMap<YakeenInsuredInfo, Client>();
            CreateMap<YakeenInsuredInfo, QuotationsMotorRequestVehicleDriver>();

            CreateMap<YakeenVehicleInfo, ClientVehicle>();
            CreateMap<SaudiPostResponse, Client>();
                
            CreateMap<SaudiPostInfo, Client>()
                .ForMember(m => m.SaudiAddressCity, opt => opt.MapFrom(p => p.City));
            CreateMap<VehicleSpecificationDto, AggriPortal.API.Contracts.Request.VehicleSpecification>();
            // Mapping From UI Quotation Request to InsureQuotation Request.
            CreateMap<UserQuotationRequestDto, InsureQuotationRequest>();
                

            CreateMap<DriverDto, Driver>();
            CreateMap<DriverMedicalConditionDto, DriverMedicalCondition>();
            CreateMap<DriverLicenseDto, DriverLicense>();
            CreateMap<DriverViolationDto, DriverViolation>();

            // Mapping from Contract to Entity
            CreateMap<InsureQuotationRequest, Client>()
                .ForMember(m => m.FirstName, opt => opt.MapFrom(p => p.InsuredFirstName))
                .ForMember(m => m.MiddleName, opt => opt.MapFrom(p => p.InsuredMiddleName))
                .ForMember(m => m.LastName, opt => opt.MapFrom(p => p.InsuredLastName))
                .ForMember(m => m.FirstNameAr, opt => opt.MapFrom(p => p.InsuredFirstNameAr))
                .ForMember(m => m.MiddleNameAr, opt => opt.MapFrom(p => p.InsuredMiddleNameAr))
                .ForMember(m => m.LastNameAr, opt => opt.MapFrom(p => p.InsuredLastNameAr))
                .ForMember(m => m.IdentityTypeId, opt => opt.MapFrom(p => p.InsuredIdentityTypeId))
                .ForMember(m => m.IdentityNumber, opt => opt.MapFrom(p => p.InsuredIdentityNumber))
                .ForMember(m => m.BirthDate, opt => opt.MapFrom(p => p.InsuredBirthDate))
                .ForMember(m => m.NationalityId, opt => opt.MapFrom(p => p.InsuredNationalityId))
                .ForMember(m => m.IdentityIssuePlaceId, opt => opt.MapFrom(p => p.InsuredIdentityIssuePlaceId))
                .ForMember(m => m.SocialStatusId, opt => opt.MapFrom(p => p.InsuredSocialStatusId))
                .ForMember(m => m.OccupationId, opt => opt.MapFrom(p => p.InsuredOccupationId))
                .ForMember(m => m.EducationLevelId, opt => opt.MapFrom(p => p.InsuredEducationLevelId));

            CreateMap<InsureQuotationRequest, QuotationsMotorRequest>()
                .ForMember(p => p.VehicleSpecifications, opt => opt.MapFrom(a => a.VehicleSpecifications.Count() > 0 ? string.Join(",", a.VehicleSpecifications.Select(p=>p.VehicleSpecificationId)) : null))
                .ForMember(p => p.QuotationsMotorRequestVehicleDrivers, opt => opt.MapFrom(a => a.Drivers));
                
            CreateMap<DriverLicense, QuotationsMotorRequestVehicleDriverLicense>();
            CreateMap<NajmAccidentDetails, QuotationsMotorRequestVehicleDriverAccident>();
            CreateMap<Driver, QuotationsMotorRequestVehicleDriver>()
                .ForMember(p=>p.NCDFreeYearsId, opt=>opt.MapFrom(a=>a.NCDFreeYears))
                .ForMember(p => p.MedicalConditions, opt => opt.MapFrom(a => a.MedicalConditions.Count() > 0 ? string.Join(",", a.MedicalConditions.Select(x => x.MedicalConditionId)) : null))
                .ForMember(p => p.DriverViolations, opt => opt.MapFrom(a => a.DriverViolations.Count() > 0 ? string.Join(",", a.DriverViolations.Select(x => x.ViolationId)) : null))
                .ForMember(p => p.QuotationsMotorRequestVehicleDriverLicenses, opt => opt.MapFrom(a => a.DriverLicenses))
                .ForMember(p => p.QuotationsMotorRequestVehicleDriverAccidents, opt => opt.MapFrom(a => a.NajmAccidentsDetails));

            
             

            CreateMap<AggriPortal.API.Contracts.Response.Benefit, QuotationsMotorResponseProductBenefit>();
            CreateMap<AggriPortal.API.Contracts.Response.PremiumBreakdown, ProductPremiumBreakdown>();
            CreateMap<AggriPortal.API.Contracts.Response.PremiumDiscount, ProductDiscount>();
           
            CreateMap<AggriPortal.API.Contracts.Response.Deductible, QuotationsMotorResponseProductDeductible>()
                .ForMember(p => p.PremiumBreakdowns, opt => opt.MapFrom(a => a.PremiumBreakdowns))
                .ForMember(p => p.Discounts, opt => opt.MapFrom(a => a.Discounts));

            CreateMap<Product, QuotationsMotorResponseProduct>()
                .ForMember(p => p.QuotationsMotorResponseProductBenefits, opt => opt.MapFrom(a => a.Benefits))
                .ForMember(p => p.QuotationsMotorResponseProductDeductibles, opt => opt.MapFrom(a => a.Deductibles));

            CreateMap<InsureQuotationResponse, QuotationsMotorResponse>()
                .ForMember(p => p.RequestReferenceId, opt => opt.MapFrom(a => a.QuotationRequestId))
                .ForMember(p => p.QuotationsMotorResponseProducts, opt => opt.MapFrom(a => a.Products));



            CreateMap<ProductBenefitDto, ClientQuotationMotorBenefit>();
            CreateMap<ProductPremiumBreakdownDto, ClientQuotationMotorPremiumBreakdown>();
            CreateMap<ProductDiscountDto, ClientQuotationMotorDiscount>();

           

            /// Mapping For Policy Request
            /// 

            #region Api Portal
            CreateMap<UpdateClientRequestDto, Client>();
            CreateMap<UpdateAccountRequestDto, ApplicationUser>();
            #endregion

        }
    }
}
 