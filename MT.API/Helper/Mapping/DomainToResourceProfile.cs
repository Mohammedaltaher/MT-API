using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using AggriPortal.API.Contracts.Request;
using AggriPortal.API.Contracts.Response;
using AggriPortal.API.Domain.Models;
using AggriPortal.API.Domain.ServiceModels;
using AggriPortal.API.Helper.Security.Tokens;
using AggriPortal.API.Resources;
using AggriPortal.API.Domain.Dtos;
using System.Security.Claims;
using AggriPortal.API.Domain.Enums;

namespace  AggriPortal.API.Helper.Mapping
{
    public class DomainToResourceProfile : Profile
    {
        public DomainToResourceProfile()
        {
            #region Master Tables
            CreateMap<VehicleMaker, VehicleMakerDto>();
            CreateMap<VehicleModel, VehicleModelDto>();
            CreateMap<Region, RegionDto>();
            CreateMap<City, CityDto>();
            CreateMap<VehicleUse, VehicleUseDto>();
            CreateMap<TransmissionType, TransmissionTypeDto>();
            #endregion

            #region Authentication
            CreateMap<AccessToken, AccessTokenDto>()
                .ForMember(a => a.AccessToken, opt => opt.MapFrom(a => a.Token))
                .ForMember(a => a.RefreshToken, opt => opt.MapFrom(a => a.RefreshToken.Token))
                .ForMember(a => a.Expiration, opt => opt.MapFrom(a => a.Expiration))
                .ForMember(a => a.IsSuccess, opt => opt.MapFrom(a => !string.IsNullOrEmpty(a.Token)))
                .ForMember(a => a.StatusCode, opt => opt.MapFrom(a => !string.IsNullOrEmpty(a.Token) ? 200 : 500));
            //.ForMember(a => a.ResponseMessage, opt => opt.MapFrom(a => "Token generated successfully"));
            #endregion

            #region Yakken Service
            CreateMap<Client, InsuredInfo>()
                .ForMember(p => p.ReferenceId, opt => opt.MapFrom(x => x.Id));

            CreateMap<YakeenInsuredInfo, InsuredInfo>();

            CreateMap<QuotationsMotorRequestVehicleDriverLicense, DriverLicenseDto>();

            CreateMap<QuotationsMotorRequestVehicleDriver, Driver>()
                .ForMember(d => d.MedicalConditions, opt => opt.MapFrom(vd => ToDriverMedicalConditionsList(vd.MedicalConditions)))
                .ForMember(d => d.DriverViolations, opt => opt.MapFrom(vd => ToDriverViolationsList(vd.DriverViolations)))
                .ForMember(d => d.DriverLicenses, opt => opt.MapFrom(vd => vd.QuotationsMotorRequestVehicleDriverLicenses))
                .ForMember(d => d.NajmAccidentsDetails, opt => opt.MapFrom(vd => vd.QuotationsMotorRequestVehicleDriverAccidents));


            #endregion

            #region Quotation 
            //Quotation Request to Insurance Company
            CreateMap<Client, InsureQuotationRequest>()
                .ForMember(m => m.InsuredFirstName, opt => opt.MapFrom(p => p.FirstName))
                .ForMember(m => m.InsuredMiddleName, opt => opt.MapFrom(p => p.MiddleName))
                .ForMember(m => m.InsuredLastName, opt => opt.MapFrom(p => p.LastName))
                .ForMember(m => m.InsuredFirstNameAr, opt => opt.MapFrom(p => p.FirstNameAr))
                .ForMember(m => m.InsuredMiddleNameAr, opt => opt.MapFrom(p => p.MiddleNameAr))
                .ForMember(m => m.InsuredLastNameAr, opt => opt.MapFrom(p => p.LastNameAr))
                .ForMember(m => m.InsuredIdentityTypeId, opt => opt.MapFrom(p => p.IdentityTypeId))
                .ForMember(m => m.InsuredIdentityNumber, opt => opt.MapFrom(p => p.IdentityNumber))
                .ForMember(m => m.InsuredBirthDate, opt => opt.MapFrom(p => p.BirthDate))
                .ForMember(m => m.InsuredNationalityId, opt => opt.MapFrom(p => p.NationalityId))
                .ForMember(m => m.InsuredIdentityIssuePlaceId, opt => opt.MapFrom(p => p.IdentityIssuePlaceId))
                .ForMember(m => m.InsuredSocialStatusId, opt => opt.MapFrom(p => p.SocialStatusId))
                .ForMember(m => m.InsuredOccupationId, opt => opt.MapFrom(p => p.OccupationId))
                .ForMember(m => m.InsuredEducationLevelId, opt => opt.MapFrom(p => p.EducationLevelId))
                .ForMember(m => m.ChildrenUnder16Years, opt => opt.MapFrom(p => p.ChildrenUnder16Years))
                .ForMember(m => m.InsuredBuildingNumber, opt => opt.MapFrom(p => p.BuildingNumber))
                .ForMember(m => m.InsuredStreet, opt => opt.MapFrom(p => p.Street))
                .ForMember(m => m.InsuredDistrict, opt => opt.MapFrom(p => p.District))
                .ForMember(m => m.InsuredCity, opt => opt.MapFrom(p => p.SaudiAddressCity))
                .ForMember(m => m.InsuredAdditionalNumber, opt => opt.MapFrom(p => p.AdditionalNumber))
                .ForMember(m => m.InsuredPostalCode, opt => opt.MapFrom(p => p.PostalCode));

            CreateMap<ClientVehicle, InsureQuotationRequest>()
                .ForMember(dto => dto.VehicleSpecifications, opt => opt.MapFrom(x => ToVehicleSpecificationList(x.VehicleSpecifications)));

            CreateMap<InsuranceCompany, InsuranceCompanyDto>()
                .ForMember(p => p.Description, opt => opt.MapFrom(x => x.AboutCompany))
                .ForMember(p => p.DescriptionAr, opt => opt.MapFrom(x => x.AboutCompanyAr));

            CreateMap<QuotationsMotorResponseProductBenefit, ProductBenefitDto>()
                .ForMember(p => p.Name, opt => opt.MapFrom(x => x.Benefit.Name))
                .ForMember(p => p.NameAr, opt => opt.MapFrom(x => x.Benefit.NameAr));

            CreateMap<ProductPremiumBreakdown, ProductPremiumBreakdownDto>()
                .ForMember(p => p.Name, opt => opt.MapFrom(x => x.PremiumBreakdown.Name))
                .ForMember(p => p.NameAr, opt => opt.MapFrom(x => x.PremiumBreakdown.NameAr));

            CreateMap<ProductDiscount, ProductDiscountDto>()
                .ForMember(p => p.Name, opt => opt.MapFrom(x => x.DiscountType.Name))
                .ForMember(p => p.NameAr, opt => opt.MapFrom(x => x.DiscountType.NameAr));
            CreateMap<QuotationsMotorResponseProductDeductible, ProductDeductibleDto>()
               .ForMember(p => p.PremiumBreakdowns, opt => opt.MapFrom(p => p.PremiumBreakdowns))
               .ForMember(p => p.Discounts, opt => opt.MapFrom(p => p.Discounts));

            CreateMap<QuotationsMotorResponseProduct, QuotationProductDto>()
                .ForMember(p => p.QuotationProductId, opt => opt.MapFrom(x => x.Id))
                .ForMember(p => p.Name, opt => opt.MapFrom(x => x.ProductType.Name))
                .ForMember(p => p.NameAr, opt => opt.MapFrom(x => x.ProductType.NameAr))
                .ForMember(p => p.Deductibles, opt => opt.MapFrom(x => x.QuotationsMotorResponseProductDeductibles))
                .ForMember(p => p.Benefits, opt => opt.MapFrom(x => x.QuotationsMotorResponseProductBenefits));

           


            CreateMap<QuotationsMotorResponse, QuoteDto>()
                .ForMember(p => p.InsuranceCompany, opt => opt.MapFrom(x => x.InsuranceCompany))
                .ForMember(p => p.Products, opt => opt.MapFrom(x => x.QuotationsMotorResponseProducts));


            CreateMap<ClientQuotationMotorPremiumBreakdown, ProductPremiumBreakdownDto>()
                .ForMember(p => p.Name, opt => opt.MapFrom(x => x.PremiumBreakdown.Name))
                .ForMember(p => p.NameAr, opt => opt.MapFrom(x => x.PremiumBreakdown.NameAr));

            CreateMap<ClientQuotationMotorDiscount, ProductDiscountDto>()
                .ForMember(p => p.Name, opt => opt.MapFrom(x => x.DiscountType.Name))
                .ForMember(p => p.NameAr, opt => opt.MapFrom(x => x.DiscountType.NameAr));

            CreateMap<ClientQuotationMotorBenefit, ProductBenefitDto>()
                .ForMember(p => p.Name, opt => opt.MapFrom(x => x.Benefit.Name))
                .ForMember(p => p.NameAr, opt => opt.MapFrom(x => x.Benefit.NameAr));


            CreateMap<Client, InsuredInfoDto>();


            CreateMap<QuotationsMotorRequest, InsuredInfoDto>()
                .ForMember(p => p.ClientId, opt => opt.MapFrom(x => x.ClientId.HasValue ? x.ClientId.ToString() : null))
                .ForMember(p => p.IdentityNumber, opt => opt.MapFrom(m => m.InsuredIdentityNumber))
                .ForMember(p => p.FirstName, opt => opt.MapFrom(m => m.InsuredFirstName))
                .ForMember(p => p.MiddleName, opt => opt.MapFrom(m => m.InsuredMiddleName))
                .ForMember(p => p.LastName, opt => opt.MapFrom(m => m.InsuredLastName))
                .ForMember(p => p.FirstNameAr, opt => opt.MapFrom(m => m.InsuredFirstNameAr))
                .ForMember(p => p.MiddleNameAr, opt => opt.MapFrom(m => m.InsuredMiddleNameAr))
                .ForMember(p => p.LastNameAr, opt => opt.MapFrom(m => m.InsuredLastNameAr));

            CreateMap<QuotationsMotorRequest, VehicleInfoDto>()
                .ForMember(p => p.VehicleId, opt => opt.MapFrom(m => m.VehicleId))
                .ForMember(p => p.PlateNumber, opt => opt.MapFrom(m => m.VehiclePlateNumber))
                .ForMember(p => p.PlateFirstLetter, opt => opt.MapFrom(m => m.VehiclePlateFirstLetter.Name))
                .ForMember(p => p.PlateSecondLetter, opt => opt.MapFrom(m => m.VehiclePlateSecondLetter.Name))
                .ForMember(p => p.PlateThirdLetter, opt => opt.MapFrom(m => m.VehiclePlateThirsdLetter.Name))
                .ForMember(p => p.PlateFirstLetterAr, opt => opt.MapFrom(m => m.VehiclePlateFirstLetter.NameAr))
                .ForMember(p => p.PlateSecondLetterAr, opt => opt.MapFrom(m => m.VehiclePlateSecondLetter.NameAr))
                .ForMember(p => p.PlateThirdLetterAr, opt => opt.MapFrom(m => m.VehiclePlateThirsdLetter.NameAr))
                .ForMember(p => p.ColorAr, opt => opt.MapFrom(m => m.VehicleMajorColor.NameAr))
                .ForMember(p => p.ModelYear, opt => opt.MapFrom(m => m.VehicleModelYear))
                .ForMember(p => p.Maker, opt => opt.MapFrom(m => m.VehicleMaker.NameAr))
                .ForMember(p => p.MakerLogo, opt => opt.MapFrom(m => m.VehicleMaker.Logo))
                .ForMember(p => p.Model, opt => opt.MapFrom(m => m.VehicleModel.NameAr))
                .ForMember(p => p.DrivingCity, opt => opt.MapFrom(m => m.DrivingCity.Name))
                .ForMember(p => p.DrivingCityAr, opt => opt.MapFrom(m => m.DrivingCity.NameAr))
                .ForMember(p => p.RepairMethod, opt => opt.MapFrom(m => m.VehicleRepairMethod.Name))
                .ForMember(p => p.RepairMethodAr, opt => opt.MapFrom(m => m.VehicleRepairMethod.NameAr))
                .ForMember(p => p.SumInsured, opt => opt.MapFrom(m => m.VehicleSumInsured));

            #endregion

            

            #region Profile
            CreateMap<ClientVehicle, ProfileVehicleDto>()
                .ForMember(p => p.InsuredIdentityNumber, opt => opt.MapFrom(x => x.Client.IdentityNumber))
                .ForMember(p => p.VehiclePlateFirstLetterAr, opt => opt.MapFrom(x => x.VehiclePlateFirstLetter.NameAr))
                .ForMember(p => p.VehiclePlateSecondLetterAr, opt => opt.MapFrom(x => x.VehiclePlateSecondLetter.NameAr))
                .ForMember(p => p.VehiclePlateThirdLetterAr, opt => opt.MapFrom(x => x.VehiclePlateThirsdLetter.NameAr))
                .ForMember(p => p.VehiclePlateFirstLetter, opt => opt.MapFrom(x => x.VehiclePlateFirstLetter.Name))
                .ForMember(p => p.VehiclePlateSecondLetter, opt => opt.MapFrom(x => x.VehiclePlateSecondLetter.Name))
                .ForMember(p => p.VehiclePlateThirdLetter, opt => opt.MapFrom(x => x.VehiclePlateThirsdLetter.Name))
                .ForMember(p => p.VehicleModelAr, opt => opt.MapFrom(x => x.VehicleModel.NameAr))
                .ForMember(p => p.VehicleModel, opt => opt.MapFrom(x => x.VehicleModel.Name))
                .ForMember(p => p.VehicleMakerAr, opt => opt.MapFrom(x => x.VehicleMaker.NameAr))
                .ForMember(p => p.VehicleMaker, opt => opt.MapFrom(x => x.VehicleMaker.Name))
                .ForMember(p => p.VehicleLogo, opt => opt.MapFrom(x => x.VehicleMaker.Logo))
                .ForMember(p => p.VehicleMajorColorAr, opt => opt.MapFrom(x => x.VehicleMajorColor.NameAr))
                .ForMember(p => p.VehicleMajorColor, opt => opt.MapFrom(x => x.VehicleMajorColor.Name));

            CreateMap<ClientQuotationMotor, ProfileSavedQuoteDto>()
                .ForMember(p => p.InsurCompany, opt => opt.MapFrom(x => x.InsuranceCompany.Name))
                .ForMember(p => p.InsurCompanyAr, opt => opt.MapFrom(x => x.InsuranceCompany.NameAr))
                .ForMember(p => p.VehicleId, opt => opt.MapFrom(x => x.QuotationsMotorRequest.VehicleId))
                .ForMember(p => p.VehiclePlateFirstLetterAr, opt => opt.MapFrom(x => x.QuotationsMotorRequest.VehiclePlateFirstLetter.NameAr))
                .ForMember(p => p.VehiclePlateSecondLetterAr, opt => opt.MapFrom(x => x.QuotationsMotorRequest.VehiclePlateSecondLetter.NameAr))
                .ForMember(p => p.VehiclePlateThirdLetterAr, opt => opt.MapFrom(x => x.QuotationsMotorRequest.VehiclePlateThirsdLetter.NameAr))
                .ForMember(p => p.VehiclePlateFirstLetter, opt => opt.MapFrom(x => x.QuotationsMotorRequest.VehiclePlateFirstLetter.Name))
                .ForMember(p => p.VehiclePlateSecondLetter, opt => opt.MapFrom(x => x.QuotationsMotorRequest.VehiclePlateSecondLetter.Name))
                .ForMember(p => p.VehiclePlateThirdLetter, opt => opt.MapFrom(x => x.QuotationsMotorRequest.VehiclePlateThirsdLetter.Name))
                .ForMember(p => p.VehicleModelYear, opt => opt.MapFrom(x => x.QuotationsMotorRequest.VehicleModelYear))
                .ForMember(p => p.VehicleModelAr, opt => opt.MapFrom(x => x.QuotationsMotorRequest.VehicleModel.NameAr))
                .ForMember(p => p.VehicleMakerAr, opt => opt.MapFrom(x => x.QuotationsMotorRequest.VehicleMaker.NameAr))
                .ForMember(p => p.VehicleLogo, opt => opt.MapFrom(x => x.QuotationsMotorRequest.VehicleMaker.Logo))
                .ForMember(p => p.VehicleMajorColorAr, opt => opt.MapFrom(x => x.QuotationsMotorRequest.VehicleMajorColor.NameAr))
                .ForMember(p => p.VehicleMajorColor, opt => opt.MapFrom(x => x.QuotationsMotorRequest.VehicleMajorColor.Name));

            CreateMap<PoliciesMotor, ProfilePoliciesMotorDto>()
                .ForMember(p => p.InsuranceCompany, opt => opt.MapFrom(x => x.InsuranceCompany.Name))
                .ForMember(p => p.InsuranceCompanyAr, opt => opt.MapFrom(x => x.InsuranceCompany.NameAr))
                .ForMember(p => p.ProductType, opt => opt.MapFrom(x => x.ProductType.Name))
                .ForMember(p => p.ProductTypeAr, opt => opt.MapFrom(x => x.ProductType.NameAr));

            CreateMap<Client, ProfileIdentitiesDto>()
                .ForMember(p => p.ClientId, opt => opt.MapFrom(x => x.Id))
                .ForMember(p => p.FullName, opt => opt.MapFrom(x => string.Join(" ", x.FirstName, x.MiddleName, x.LastName)))
                .ForMember(p => p.FullNameAr, opt => opt.MapFrom(x => string.Join(" ", x.FirstNameAr, x.MiddleNameAr, x.LastNameAr)));
            #endregion


            #region Policy Request
            CreateMap<Client, PolicyInsuredInfoDto>();
            CreateMap<ClientQuotationMotorBenefit, Contracts.Response.Benefit>();
            CreateMap<PolicyRequest, IssuePolicyRequest>()
                .ForMember(p => p.PolicyRequestId, opt => opt.MapFrom(x => x.PolicyRequestRefId))
                .ForMember(p => p.QuotationRequestId, opt => opt.MapFrom(x => x.QuotationRequestRefId))
                .ForMember(p => p.QuotationId, opt => opt.MapFrom(x => x.InsurQuotationId))
                .ForMember(p => p.InsuranceCompanyId, opt => opt.MapFrom(x => x.InsuranceCompanyId))
                .ForMember(p => p.InsuredMobileNo, opt => opt.MapFrom(x => x.InsuredMobileNumber))
                .ForMember(p => p.InsuredEmail, opt => opt.MapFrom(x => x.InsuredEmail))
                .ForMember(p => p.InsuredIBAN, opt => opt.MapFrom(x => x.InsuredIBAN))
                .ForMember(p => p.InsuredBankId, opt => opt.MapFrom(x => x.InsuredBankId))
                .ForMember(p => p.PaymentMethodId, opt => opt.MapFrom(x => x.PaymentMethodId))
                .ForMember(p => p.IsPaymentSuccess, opt => opt.MapFrom(x => x.IsPaymentSuccess))
                .ForMember(p => p.PaymentAmount, opt => opt.MapFrom(x => x.PaymentAmount))
                .ForMember(p => p.PaymentInvoiceId, opt => opt.MapFrom(x => x.PaymentInvoiceId));

            CreateMap<QuotationsMotorRequest, PolicyVehicleInfoDto>()
                .ForMember(p => p.VehicleId, opt => opt.MapFrom(m => m.VehicleId))
                .ForMember(p => p.PlateNumber, opt => opt.MapFrom(m => m.VehiclePlateNumber))
                .ForMember(p => p.PlateFirstLetter, opt => opt.MapFrom(m => m.VehiclePlateFirstLetter.NameAr))
                .ForMember(p => p.PlateSecondLetter, opt => opt.MapFrom(m => m.VehiclePlateSecondLetter.NameAr))
                .ForMember(p => p.PlateThirdLetter, opt => opt.MapFrom(m => m.VehiclePlateThirsdLetter.NameAr))
                .ForMember(p => p.ModelYear, opt => opt.MapFrom(m => m.VehicleModelYear))
                .ForMember(p => p.Maker, opt => opt.MapFrom(m => m.VehicleMaker.NameAr))
                .ForMember(p => p.Model, opt => opt.MapFrom(m => m.VehicleModel.NameAr));

            #endregion

            #region Portal.API
            CreateMap<APILogHistory, APILogHistoryDto>();
            CreateMap<SMSLog, SMSLogDto>();

            CreateMap<ApplicationUser, ApplicationUserDto>()
                ;


            CreateMap<Client, ClientDto>()
                .ForMember(p => p.IdentityTypeName, opt => opt.MapFrom(x => x.IdentityType.Name))
                .ForMember(p => p.IdentityTypeNameAr, opt => opt.MapFrom(x => x.IdentityType.NameAr))
                .ForMember(p => p.NationalityName, opt => opt.MapFrom(x => x.Nationality.Name))
                .ForMember(p => p.NationalityNameAr, opt => opt.MapFrom(x => x.Nationality.NameAr))
                .ForMember(p => p.EducationLevelName, opt => opt.MapFrom(x => x.EducationLevel.Name))
                .ForMember(p => p.EducationLevelNameAr, opt => opt.MapFrom(x => x.EducationLevel.NameAr))
                .ForMember(p => p.IdentityIssuePlaceName, opt => opt.MapFrom(x => x.IdentityIssuePlace.Name))
                .ForMember(p => p.IdentityIssuePlaceNameAr, opt => opt.MapFrom(x => x.IdentityIssuePlace.NameAr))
                .ForMember(p => p.GenderName, opt => opt.MapFrom(x => x.Gender.Name))
                .ForMember(p => p.GenderNameAr, opt => opt.MapFrom(x => x.Gender.NameAr))
                .ForMember(p => p.WorkCityName, opt => opt.MapFrom(x => x.WorkCity.Name))
                .ForMember(p => p.WorkCityNameAr, opt => opt.MapFrom(x => x.WorkCity.NameAr))
                .ForMember(p => p.SocialStatusName, opt => opt.MapFrom(x => x.SocialStatus.Name))
                .ForMember(p => p.CreatedBy, opt => opt.MapFrom(x => x.ApplicationUser.Email))
                .ForMember(p => p.TotalPolicies, opt => opt.MapFrom(x => x.PolicyRequests.Count()))

                .ForMember(p => p.TotalPreviewedQuotes, opt => opt.MapFrom(x => x.ClientQuotationMotors.Where(k => k.StatusId == (int)ClientQuotationStatusEnum.Previewed).Count()))
                 .ForMember(p => p.TotalSavedQuotes, opt => opt.MapFrom(x => x.ClientQuotationMotors.Where(k => k.StatusId == (int)ClientQuotationStatusEnum.Saved).Count()))

                .ForMember(p => p.SocialStatusNameAr, opt => opt.MapFrom(x => x.SocialStatus.NameAr));

            CreateMap<Client, QoutationClinetDetailsDto>()
               .ForMember(p => p.FullName, opt => opt.MapFrom(x => x.FirstName + " " + x.MiddleName + " " + x.LastName))
               .ForMember(p => p.FullNameAr, opt => opt.MapFrom(x => x.FirstNameAr + " " + x.MiddleNameAr + " " + x.LastNameAr))
               .ForMember(p => p.Email, opt => opt.MapFrom(x => x.Email))
               .ForMember(p => p.BirthDate, opt => opt.MapFrom(x => x.BirthDate))
               .ForMember(p => p.PhoneNumber, opt => opt.MapFrom(x => x.PhoneNumber));

            CreateMap<ClientVehicle, ClientVehicleDto>()
                .ForMember(p => p.VehiclePlateFirstLetterName, opt => opt.MapFrom(x => x.VehiclePlateFirstLetter.Name))
                .ForMember(p => p.VehiclePlateFirstLetterNameAr, opt => opt.MapFrom(x => x.VehiclePlateFirstLetter.NameAr))
                .ForMember(p => p.VehiclePlateSecondLetterName, opt => opt.MapFrom(x => x.VehiclePlateSecondLetter.Name))
                .ForMember(p => p.VehiclePlateFirstLetterNameAr, opt => opt.MapFrom(x => x.VehiclePlateSecondLetter.NameAr))
                .ForMember(p => p.VehiclePlateThirdLetterName, opt => opt.MapFrom(x => x.VehiclePlateThirsdLetter.Name))
                .ForMember(p => p.VehiclePlateThirdLetterNameAr, opt => opt.MapFrom(x => x.VehiclePlateThirsdLetter.NameAr))
                .ForMember(p => p.VehicleMakerName, opt => opt.MapFrom(x => x.VehicleMaker.Name))
                .ForMember(p => p.VehicleMakerNameAr, opt => opt.MapFrom(x => x.VehicleMaker.NameAr))
                .ForMember(p => p.VehicleMakerLogo, opt => opt.MapFrom(x => x.VehicleMaker.Logo))
                .ForMember(p => p.VehicleModelName, opt => opt.MapFrom(x => x.VehicleModel.Name))
                .ForMember(p => p.VehicleModelNameAr, opt => opt.MapFrom(x => x.VehicleModel.NameAr))
                .ForMember(p => p.VehicleMajorColorName, opt => opt.MapFrom(x => x.VehicleMajorColor.Name))
                .ForMember(p => p.VehicleMajorColorNameAr, opt => opt.MapFrom(x => x.VehicleMajorColor.NameAr))
                .ForMember(p => p.VehicleBodyTypeName, opt => opt.MapFrom(x => x.VehicleBodyType.Name))
                .ForMember(p => p.VehicleBodyTypeNameAr, opt => opt.MapFrom(x => x.VehicleBodyType.NameAr))
                .ForMember(p => p.VehicleIdTypeName, opt => opt.MapFrom(x => x.VehicleIdType.Name))
                .ForMember(p => p.VehicleIdTypeNameAr, opt => opt.MapFrom(x => x.VehicleIdType.NameAr))

                .ForMember(p => p.VehicleRepairMethodName, opt => opt.MapFrom(x => x.VehicleRepairMethod.Name))
                .ForMember(p => p.VehicleRepairMethodNameAr, opt => opt.MapFrom(x => x.VehicleRepairMethod.NameAr))

                .ForMember(p => p.VehicleRegistrationCityName, opt => opt.MapFrom(x => x.VehicleRegistrationCity.Name))
                .ForMember(p => p.VehicleRegistrationCityNameAr, opt => opt.MapFrom(x => x.VehicleRegistrationCity.NameAr))
                .ForMember(p => p.VehicleUseName, opt => opt.MapFrom(x => x.VehicleUse.Name))
                .ForMember(p => p.VehicleUseNameAr, opt => opt.MapFrom(x => x.VehicleUse.NameAr))
                .ForMember(p => p.VehicleTransmissionTypeName, opt => opt.MapFrom(x => x.VehicleTransmissionType.Name))
                .ForMember(p => p.VehicleTransmissionTypeNameAr, opt => opt.MapFrom(x => x.VehicleTransmissionType.NameAr))
                .ForMember(p => p.VehicleAxleWeightName, opt => opt.MapFrom(x => x.VehicleAxleWeight.Name))
                .ForMember(p => p.VehicleAxleWeightNameAr, opt => opt.MapFrom(x => x.VehicleAxleWeight.NameAr))
                .ForMember(p => p.CreatedBy, opt => opt.MapFrom(x => x.Client.ApplicationUser.Email))
                .ForMember(p => p.VehicleSpecification, opt => opt.MapFrom(x => ToVehicleSpecification(x.VehicleSpecifications)));


            CreateMap<PoliciesMotor, PoliciesMotorDto>()
                .ForMember(p => p.InsuranceCompanyName, opt => opt.MapFrom(x => x.InsuranceCompany.Name))
                .ForMember(p => p.InsuranceCompanyNameAr, opt => opt.MapFrom(x => x.InsuranceCompany.NameAr))
               .ForMember(p => p.FullName, opt => opt.MapFrom(x => x.Client.FirstName + " " + x.Client.MiddleName + " " + x.Client.LastName))
               .ForMember(p => p.FullNameAr, opt => opt.MapFrom(x => x.Client.FirstNameAr + " " + x.Client.MiddleNameAr + " " + x.Client.LastNameAr))
                .ForMember(p => p.ProductTypeName, opt => opt.MapFrom(x => x.ProductType.Name))
                .ForMember(p => p.ProductTypeNameAr, opt => opt.MapFrom(x => x.ProductType.NameAr))
                .ForMember(p => p.ExpiryingIn, opt => opt.MapFrom(x => (x.PolicyExpiryDate - DateTime.Now).TotalDays))
                .ForMember(p => p.CreatedBy, opt => opt.MapFrom(x => x.Client.ApplicationUser.Email));

            CreateMap<PoliciesMotor, ClientPoliciesDto>()
               .ForMember(p => p.InsuranceCompanyName, opt => opt.MapFrom(x => x.InsuranceCompany.Name))
               .ForMember(p => p.InsuranceCompanyNameAr, opt => opt.MapFrom(x => x.InsuranceCompany.NameAr))
               .ForMember(p => p.ProductTypeName, opt => opt.MapFrom(x => x.ProductType.Name))
               .ForMember(p => p.ProductTypeNameAr, opt => opt.MapFrom(x => x.ProductType.NameAr))
               .ForMember(p => p.CreatedBy, opt => opt.MapFrom(x => x.Client.ApplicationUser.Email))
              .ForMember(p => p.ClientName, opt => opt.MapFrom(x => x.Client.FirstName + " " + x.Client.MiddleName + " " + x.Client.LastName))
               .ForMember(p => p.ClientNameAr, opt => opt.MapFrom(x => x.Client.FirstNameAr + " " + x.Client.MiddleNameAr + " " + x.Client.LastNameAr))
              .ForMember(p => p.ExpiryingIn, opt => opt.MapFrom(x => (x.PolicyExpiryDate - DateTime.Now).TotalDays));

            CreateMap<ApplicationUserLoginHistory, ClientLoginHistoryDto>();
            CreateMap<ClientQuotationMotor, ClientQuotationsMotorDto>()
                .ForMember(p => p.InsuredFirstName, opt => opt.MapFrom(x => x.QuotationsMotorRequest.InsuredFirstName))
                .ForMember(p => p.InsuredFirstNameAr, opt => opt.MapFrom(x => x.QuotationsMotorRequest.InsuredFirstNameAr))
                .ForMember(p => p.InsuredMiddleName, opt => opt.MapFrom(x => x.QuotationsMotorRequest.InsuredMiddleName))
                .ForMember(p => p.InsuredMiddleNameAr, opt => opt.MapFrom(x => x.QuotationsMotorRequest.InsuredMiddleNameAr))
                .ForMember(p => p.InsuredLastName, opt => opt.MapFrom(x => x.QuotationsMotorRequest.InsuredLastName))
                .ForMember(p => p.InsuredLastNameAr, opt => opt.MapFrom(x => x.QuotationsMotorRequest.InsuredLastNameAr))
                .ForMember(p => p.ChildrenUnder16Years, opt => opt.MapFrom(x => x.QuotationsMotorRequest.ChildrenUnder16Years))
                .ForMember(p => p.InsuredStreet, opt => opt.MapFrom(x => x.QuotationsMotorRequest.ChildrenUnder16Years))
                .ForMember(p => p.InsuredDistrict, opt => opt.MapFrom(x => x.QuotationsMotorRequest.InsuredDistrict))
                .ForMember(p => p.InsuredCity, opt => opt.MapFrom(x => x.QuotationsMotorRequest.InsuredCity))
                .ForMember(p => p.InsuredPostalCode, opt => opt.MapFrom(x => x.QuotationsMotorRequest.InsuredPostalCode))
                .ForMember(p => p.InsuredAdditionalNumber, opt => opt.MapFrom(x => x.QuotationsMotorRequest.InsuredAdditionalNumber))
                .ForMember(p => p.VehicleRegistrationCityName, opt => opt.MapFrom(x => x.QuotationsMotorRequest.VehicleRegistrationCity.Name))
                .ForMember(p => p.VehicleRegistrationCityNameAr, opt => opt.MapFrom(x => x.QuotationsMotorRequest.VehicleRegistrationCity.NameAr))
                .ForMember(p => p.VehiclePlateNumber, opt => opt.MapFrom(x => x.QuotationsMotorRequest.VehiclePlateNumber))
                .ForMember(p => p.VehicleChassisNumber, opt => opt.MapFrom(x => x.QuotationsMotorRequest.VehicleChassisNumber))
                .ForMember(p => p.VehicleOwnerName, opt => opt.MapFrom(x => x.QuotationsMotorRequest.VehicleOwnerName))
                .ForMember(p => p.VehicleOwnerIdentityNumber, opt => opt.MapFrom(x => x.QuotationsMotorRequest.VehicleOwnerIdentityNumber))
                .ForMember(p => p.VehicleModelYear, opt => opt.MapFrom(x => x.QuotationsMotorRequest.VehicleModelYear))
                .ForMember(p => p.VehicleCylinders, opt => opt.MapFrom(x => x.QuotationsMotorRequest.VehicleCylinders))
                .ForMember(p => p.VehicleWeight, opt => opt.MapFrom(x => x.QuotationsMotorRequest.VehicleWeight))
                .ForMember(p => p.VehicleCapacity, opt => opt.MapFrom(x => x.QuotationsMotorRequest.VehicleCapacity))
                .ForMember(p => p.IsVehicleOwnerTransfer, opt => opt.MapFrom(x => x.QuotationsMotorRequest.IsVehicleOwnerTransfer))
                .ForMember(p => p.VehicleModificationDetails, opt => opt.MapFrom(x => x.QuotationsMotorRequest.VehicleModificationDetails))
                .ForMember(p => p.NCDFreeYearId, opt => opt.MapFrom(x => x.QuotationsMotorRequest.NCDFreeYearId))
                .ForMember(p => p.NCDReference, opt => opt.MapFrom(x => x.QuotationsMotorRequest.NCDReference))
                .ForMember(p => p.VehicleSpecifications, opt => opt.MapFrom(x => x.QuotationsMotorRequest.VehicleSpecifications))
                .ForMember(p => p.IsExternalLogin, opt => opt.MapFrom(x => x.QuotationsMotorRequest.IsExternalLogin))


                .ForMember(p => p.VehiclePlateFirstLetterName, opt => opt.MapFrom(x => x.QuotationsMotorRequest.VehiclePlateFirstLetter.Name))
                .ForMember(p => p.VehiclePlateFirstLetterNameAr, opt => opt.MapFrom(x => x.QuotationsMotorRequest.VehiclePlateFirstLetter.NameAr))
                .ForMember(p => p.VehiclePlateSecondLetterName, opt => opt.MapFrom(x => x.QuotationsMotorRequest.VehiclePlateSecondLetter.Name))
                .ForMember(p => p.VehiclePlateFirstLetterNameAr, opt => opt.MapFrom(x => x.QuotationsMotorRequest.VehiclePlateSecondLetter.NameAr))
                .ForMember(p => p.VehiclePlateThirdLetterName, opt => opt.MapFrom(x => x.QuotationsMotorRequest.VehiclePlateThirsdLetter.Name))
                .ForMember(p => p.VehiclePlateThirdLetterNameAr, opt => opt.MapFrom(x => x.QuotationsMotorRequest.VehiclePlateThirsdLetter.NameAr))
                .ForMember(p => p.VehicleMakerName, opt => opt.MapFrom(x => x.QuotationsMotorRequest.VehicleMaker.Name))
                .ForMember(p => p.VehicleMakerNameAr, opt => opt.MapFrom(x => x.QuotationsMotorRequest.VehicleMaker.NameAr))
                .ForMember(p => p.VehicleModelName, opt => opt.MapFrom(x => x.QuotationsMotorRequest.VehicleModel.Name))
                .ForMember(p => p.VehicleModelNameAr, opt => opt.MapFrom(x => x.QuotationsMotorRequest.VehicleModel.NameAr))
                .ForMember(p => p.VehicleMajorColorName, opt => opt.MapFrom(x => x.QuotationsMotorRequest.VehicleMajorColor.Name))
                .ForMember(p => p.VehicleMajorColorNameAr, opt => opt.MapFrom(x => x.QuotationsMotorRequest.VehicleMajorColor.NameAr))
                .ForMember(p => p.VehicleBodyTypeName, opt => opt.MapFrom(x => x.QuotationsMotorRequest.VehicleBodyType.Name))
                .ForMember(p => p.VehicleBodyTypeNameAr, opt => opt.MapFrom(x => x.QuotationsMotorRequest.VehicleBodyType.NameAr))
                .ForMember(p => p.VehicleRegistrationCityName, opt => opt.MapFrom(x => x.QuotationsMotorRequest.VehicleRegistrationCity.Name))
                .ForMember(p => p.VehicleRegistrationCityNameAr, opt => opt.MapFrom(x => x.QuotationsMotorRequest.VehicleRegistrationCity.NameAr))
                .ForMember(p => p.VehicleUseName, opt => opt.MapFrom(x => x.QuotationsMotorRequest.VehicleUse.Name))
                .ForMember(p => p.VehicleUseNameAr, opt => opt.MapFrom(x => x.QuotationsMotorRequest.VehicleUse.NameAr))
                .ForMember(p => p.VehicleTransmissionTypeName, opt => opt.MapFrom(x => x.QuotationsMotorRequest.VehicleTransmissionType.Name))
                .ForMember(p => p.VehicleTransmissionTypeNameAr, opt => opt.MapFrom(x => x.QuotationsMotorRequest.VehicleTransmissionType.NameAr))
                .ForMember(p => p.VehicleAxleWeightName, opt => opt.MapFrom(x => x.QuotationsMotorRequest.VehicleAxleWeight.Name))
                .ForMember(p => p.CreatedBy, opt => opt.MapFrom(x => x.Client.ApplicationUser.Email))
                .ForMember(p => p.VehicleAxleWeightNameAr, opt => opt.MapFrom(x => x.QuotationsMotorRequest.VehicleAxleWeight.NameAr));

            CreateMap<ClientQuotationMotor, LatestActiveQuotationsDto>()
              .ForMember(p => p.ClientName, opt => opt.MapFrom(x => x.Client.FirstName + " " + x.Client.MiddleName + " " + x.Client.LastName))
              .ForMember(p => p.ClientNameAr, opt => opt.MapFrom(x => x.Client.FirstNameAr + " " + x.Client.MiddleNameAr + " " + x.Client.LastNameAr))
              .ForMember(p => p.InsuranceCompanyName, opt => opt.MapFrom(x => x.InsuranceCompany.Name))
              .ForMember(p => p.VechicleId, opt => opt.MapFrom(x => x.QuotationsMotorRequest.VehicleId))
              .ForMember(p => p.InsuranceCompanyNameAr, opt => opt.MapFrom(x => x.InsuranceCompany.NameAr))
              .ForMember(p => p.CreatedBy, opt => opt.MapFrom(x => x.Client.ApplicationUser.Email));

            CreateMap<ClientQuotationMotor, QoutationClinetDetailsDto>()
               .ForMember(p => p.FullName, opt => opt.MapFrom(x => x.Client.FirstName + " " + x.Client.MiddleName + " " + x.Client.LastName))
               .ForMember(p => p.FullNameAr, opt => opt.MapFrom(x => x.Client.FirstNameAr + " " + x.Client.MiddleNameAr + " " + x.Client.LastNameAr))
               .ForMember(p => p.Email, opt => opt.MapFrom(x => x.Client.Email))
               .ForMember(p => p.BirthDate, opt => opt.MapFrom(x => x.Client.BirthDate))
               .ForMember(p => p.PhoneNumber, opt => opt.MapFrom(x => x.Client.PhoneNumber));

            CreateMap<ClientQuotationMotor, QoutationDetailsDto>()
               .ForMember(p => p.PolicyEffectiveDate, opt => opt.MapFrom(x => x.QuotationsMotorRequest.PolicyEffectiveDate))
               .ForMember(p => p.ProductTypeName, opt => opt.MapFrom(x => x.QuotationsMotorResponseProduct.ProductType.Name))
               .ForMember(p => p.ProductTypeNameAr, opt => opt.MapFrom(x => x.QuotationsMotorResponseProduct.ProductType.NameAr))
               .ForMember(p => p.VehicleId, opt => opt.MapFrom(x => x.QuotationsMotorRequest.VehicleId))
               .ForMember(p => p.VehicleModelName, opt => opt.MapFrom(x => x.QuotationsMotorRequest.VehicleModel.Name))
               .ForMember(p => p.VehicleModelNameAr, opt => opt.MapFrom(x => x.QuotationsMotorRequest.VehicleModel.NameAr))
               .ForMember(p => p.VehicleRepairMethodName, opt => opt.MapFrom(x => x.QuotationsMotorRequest.VehicleRepairMethod.Name))
               .ForMember(p => p.VehicleRepairMethodNameAr, opt => opt.MapFrom(x => x.QuotationsMotorRequest.VehicleRepairMethod.NameAr))
               .ForMember(p => p.VehicleColorName, opt => opt.MapFrom(x => x.QuotationsMotorRequest.VehicleMajorColor.Name))
               .ForMember(p => p.VehicleColorNameAr, opt => opt.MapFrom(x => x.QuotationsMotorRequest.VehicleMajorColor.NameAr))
               .ForMember(p => p.DrivingCityName, opt => opt.MapFrom(x => x.QuotationsMotorRequest.DrivingCity.Name))
               .ForMember(p => p.DrivingCityNameAr, opt => opt.MapFrom(x => x.QuotationsMotorRequest.DrivingCity.NameAr))
               .ForMember(p => p.InsuranceCompanyEmail, opt => opt.MapFrom(x => x.InsuranceCompany.Email))
               .ForMember(p => p.InsuranceCompanyName, opt => opt.MapFrom(x => x.InsuranceCompany.Name))
               .ForMember(p => p.InsuranceCompanyNameAr, opt => opt.MapFrom(x => x.InsuranceCompany.NameAr))
               .ForMember(p => p.InsuranceCompanyPhone, opt => opt.MapFrom(x => x.InsuranceCompany.PhoneNumber));

            CreateMap<QuotationsMotorRequestVehicleDriver, VechicleDriversDto>()
              .ForMember(p => p.FullName, opt => opt.MapFrom(x => x.FirstName + " " + x.MiddleName + " " + x.LastName))
              .ForMember(p => p.FullNameAr, opt => opt.MapFrom(x => x.FirstNameAr + " " + x.MiddleNameAr + " " + x.LastNameAr))
              .ForMember(p => p.IdentityNumber, opt => opt.MapFrom(x => x.IdentityNumber))
              .ForMember(p => p.BirthDate, opt => opt.MapFrom(x => x.BirthDate))
              .ForMember(p => p.DrivingPercentageName, opt => opt.MapFrom(x => x.DrivingPercentage.Name))
              .ForMember(p => p.DrivingPercentageNameAr, opt => opt.MapFrom(x => x.DrivingPercentage.NameAr));

            CreateMap<QuotationsMotorResponseProductBenefit, QoutationBenefitDto>()
              .ForMember(p => p.Name, opt => opt.MapFrom(x => x.Benefit.Name))
              .ForMember(p => p.NameAr, opt => opt.MapFrom(x => x.Benefit.NameAr))
              .ForMember(p => p.BenefitAmount, opt => opt.MapFrom(x => x.BenefitAmount));

            CreateMap<PoliciesMotor, ChartDto>()
              .ForMember(p => p.Name, opt => opt.MapFrom(x => x.PolicyRequestRefId))
              .ForMember(p => p.Value, opt => opt.MapFrom(x => x.QuotationRequestRefId));

            CreateMap<ClientPayment, ClientInvoicesDto>()
             .ForMember(p => p.BankName, opt => opt.MapFrom(x => x.Bank.Name))
             .ForMember(p => p.BankNameAr, opt => opt.MapFrom(x => x.Bank.NameAr))
             .ForMember(p => p.ProductTypeName, opt => opt.MapFrom(x => x.ClientQuotation.QuotationsMotorResponseProduct.ProductType.Name))
             .ForMember(p => p.ProductTypeNameAr, opt => opt.MapFrom(x => x.ClientQuotation.QuotationsMotorResponseProduct.ProductType.NameAr))
             .ForMember(p => p.InsuranceCompanyName, opt => opt.MapFrom(x => x.ClientQuotation.InsuranceCompany.Name))
             .ForMember(p => p.InsuranceCompanyNameAr, opt => opt.MapFrom(x => x.ClientQuotation.InsuranceCompany.NameAr))
             .ForMember(p => p.PaymentMethodName, opt => opt.MapFrom(x => x.PaymentMethod.Name))
             .ForMember(p => p.CreatedBy, opt => opt.MapFrom(x => x.Client.ApplicationUser.Email))
             .ForMember(p => p.PaymentMethodNameAr, opt => opt.MapFrom(x => x.PaymentMethod.NameAr));

            CreateMap<ClientPayment, ApprovedClientInvoicesDto>()
            .ForMember(p => p.BankName, opt => opt.MapFrom(x => x.Bank.Name))
            .ForMember(p => p.BankNameAr, opt => opt.MapFrom(x => x.Bank.NameAr))
            .ForMember(p => p.ProductTypeName, opt => opt.MapFrom(x => x.ClientQuotation.QuotationsMotorResponseProduct.ProductType.Name))
            .ForMember(p => p.ProductTypeNameAr, opt => opt.MapFrom(x => x.ClientQuotation.QuotationsMotorResponseProduct.ProductType.NameAr))
            .ForMember(p => p.InsuranceCompanyName, opt => opt.MapFrom(x => x.ClientQuotation.InsuranceCompany.Name))
            .ForMember(p => p.InsuranceCompanyNameAr, opt => opt.MapFrom(x => x.ClientQuotation.InsuranceCompany.NameAr))
            .ForMember(p => p.PaymentMethodName, opt => opt.MapFrom(x => x.PaymentMethod.Name))
            .ForMember(p => p.CreatedBy, opt => opt.MapFrom(x => x.Client.ApplicationUser.Email))
            .ForMember(p => p.PaymentMethodNameAr, opt => opt.MapFrom(x => x.PaymentMethod.NameAr));

            CreateMap<ClientQuotationMotorBenefit, BenefitDto>()
             .ForMember(p => p.Name, opt => opt.MapFrom(x => x.Benefit.Name))
             .ForMember(p => p.NameAr, opt => opt.MapFrom(x => x.Benefit.NameAr));

            CreateMap<ApplicationRole, RoleDto>();
            CreateMap<ApplicationUser, UsersDtos>();
            CreateMap<Claim, UserClaimsDto>()
             .ForMember(p => p.ClaimValue, opt => opt.MapFrom(x => x.Value))
             .ForMember(p => p.ClaimType, opt => opt.MapFrom(x => x.Type));
            #endregion
            #region Tickets
            CreateMap<Ticket, TicketsDto>()
               .ForMember(p => p.ClientName, opt => opt.MapFrom(x => x.Client.FirstName + " " + x.Client.MiddleName + " " + x.Client.LastName))
               .ForMember(p => p.ClientNameAr, opt => opt.MapFrom(x => x.Client.FirstNameAr + " " + x.Client.MiddleNameAr + " " + x.Client.LastNameAr))
               .ForMember(p => p.Status, opt => opt.MapFrom(x => x.TicketStatus.Name))
               .ForMember(p => p.StatusAr, opt => opt.MapFrom(x => x.TicketStatus.NameAr))
               .ForMember(p => p.Type, opt => opt.MapFrom(x => x.TicketType.Name))
               .ForMember(p => p.TypeAr, opt => opt.MapFrom(x => x.TicketType.NameAr))
               .ForMember(p => p.ClosedBy, opt => opt.MapFrom(x => x.ApplicationUser.Email))
               .ForMember(p => p.CreatedBy, opt => opt.MapFrom(x => x.ApplicationUser.Email));

            CreateMap<TicketFollowUp, TicketFollowUpDto>()
              .ForMember(p => p.CreatedBy, opt => opt.MapFrom(x => x.Ticket.ApplicationUser.Email));
            #endregion



        } 

        #region Helper

        /// <summary>
        /// Use this in InsurQuotationRequest, when sending request to insurance company
        /// </summary>
        /// <param name="medicalConditionsStr">Medical condition Id in format 1,2,3</param>
        /// <returns>List of <code>DriverMedicalCondition</code></returns>
        private static List<DriverMedicalCondition> ToDriverMedicalConditionsList(string medicalConditionsStr)
        {
            return String.IsNullOrWhiteSpace(medicalConditionsStr) ? new List<DriverMedicalCondition>() : medicalConditionsStr.Split(',').Select(i => new DriverMedicalCondition { MedicalConditionId = Int32.Parse(i) }).ToList<DriverMedicalCondition>();
        }


        /// <summary>
        /// Use this in InquireResponseDto, when retrive data from database.
        /// </summary>
        /// <param name="medicalConditionsStr">Medical condition Id in format 1,2,3</param>
        /// <returns>List of <code>DriverMedicalConditionDto</code></returns>


        private static List<DriverViolation> ToDriverViolationsList(string driverViolationsStr)
        {
            return String.IsNullOrWhiteSpace(driverViolationsStr) ? new List<DriverViolation>() : driverViolationsStr.Split(',').Select(i => new DriverViolation { ViolationId = Int32.Parse(i) }).ToList<DriverViolation>();
        }




        private static List<Contracts.Request.VehicleSpecification> ToVehicleSpecificationList(string vehicleSpecificationStr)
        {
            return String.IsNullOrWhiteSpace(vehicleSpecificationStr) ? new List<Contracts.Request.VehicleSpecification>() : vehicleSpecificationStr.Split(',').Select(i => new Contracts.Request.VehicleSpecification { VehicleSpecificationId = Int32.Parse(i) }).ToList<Contracts.Request.VehicleSpecification>();
        }

        private static List<VehicleSpecificationList> ToVehicleSpecification(string vehicleSpecificationStr)
        {
            return String.IsNullOrWhiteSpace(vehicleSpecificationStr) ? new List<VehicleSpecificationList>() : vehicleSpecificationStr.Split(',').Select(i => new VehicleSpecificationList { VehicleSpecificationId = Int32.Parse(i), VehicleSpecification = i }).ToList<VehicleSpecificationList>();
        }

        #endregion
    }
}
