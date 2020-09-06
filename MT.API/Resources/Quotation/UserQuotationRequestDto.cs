using System;
using System.Collections.Generic;
using FluentValidation;
using Microsoft.Extensions.Localization;


namespace  AggriPortal.API.Contracts.Request
{
    public class UserQuotationRequestDto
    {
        public UserQuotationRequestDto()
        {
            VehicleSpecifications = new List<VehicleSpecificationDto>();
            Drivers = new List<DriverDto>();
        }
        public int InsuredIdentityTypeId { get; set; }
        public long InsuredIdentityNumber { get; set; }
        public int VehicleIdTypeId { get; set; }
        public long VehicleId { get; set; }
        public DateTime PolicyEffectiveDate { get; set; }
        public long? NationalityId { get; set; }
        public string InsuredBirthDate { get; set; }
        public string InsuredGenderId { get; set; }
        public int InsuredSocialStatusId { get; set; }
        public int InsuredEducationLevelId { get; set; }
        public int? ChildrenUnder16Years { get; set; }
        public int? InsuredWorkCityId { get; set; }
        public int DrivingCityId { get; set; }
        public int? InsuredHomeCityId { get; set; }
        public string PromoCode { get; set; }
        public decimal VehicleSumInsured { get; set; }
        public int VehicleUseId { get; set; }
        public int? VehicleTransmissionTypeId { get; set; }
        public int? VehicleParkingLocationId { get; set; }
        public bool IsVehicleModified { get; set; }
        public string VehicleModificationDetails { get; set; }
        public int VehicleCurrentMileage { get; set; }
        public int? VehicleMileageExpectedAnnualId { get; set; }
        public bool IsVehicleOwnerTransfer { get; set; }
        public int VehicleRepairMethodId { get; set; }
        public long? VehicleOwnerIdentityNumber { get; set; }
        public List<VehicleSpecificationDto> VehicleSpecifications { get; set; }
        public List<DriverDto> Drivers { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
    }

    public class DriverDto
    {
        public int TypeId { get; set; }
        public long IdentityNumber { get; set; }
        public string BirthDate { get; set; }
        public string GenderId { get; set; }
        public int? DrivingPercentageId { get; set; }
        public int? EducationLevelId { get; set; }
        public int? SocialStatusId { get; set; }
        public int? RelationId { get; set; }
        public int? ChildrenUnder16Years { get; set; }
        public int? HomeCityId { get; set; }
        public int? NumberOfAccidentsLast5Years { get; set; }
        public int? NumberOfClaimsLast5Years { get; set; }
        public List<DriverMedicalConditionDto> MedicalConditions { get; set; }
        public List<DriverLicenseDto> DriverLicenses { get; set; }
        public List<DriverViolationDto> DriverViolations { get; set; }
        
    }

    public class DriverLicenseDto
    {
        public int LicenseTypeId { get; set; }
        public int? CountryId { get; set; }
        public int? NumberOfYears { get; set; }
        public bool IsSaudiLicense { get; set; }
    }

    public class DriverViolationDto
    {
        public int ViolationId { get; set; }
    }

    public class DriverMedicalConditionDto
    {
        public int MedicalConditionId { get; set; }
    }

    public class VehicleSpecificationDto
    {
        public int VehicleSpecificationId { get; set; }
    }

    #region Request Validator
    public class UserQuotationRequestValidator : AbstractValidator<UserQuotationRequestDto>
    {
        public UserQuotationRequestValidator(IStringLocalizer<UserQuotationRequestDto> localizer)
        {
            RuleFor(p => p.InsuredIdentityTypeId)
            .NotEmpty().NotNull().WithMessage(p=> localizer["RequiredField"]);

            RuleFor(p => p.PolicyEffectiveDate)
                .NotEmpty().WithMessage(p=> localizer["RequiredField"])
                .NotNull().WithMessage(p=> localizer["RequiredField"]);

            RuleFor(p => p.InsuredIdentityNumber)
                .NotEmpty().WithMessage(p=> localizer["RequiredField"])
                .NotNull().WithMessage(p=> localizer["RequiredField"])
                .InclusiveBetween(1000000000, 7999999999).WithMessage("Invalid Insured Identity number.");

            RuleFor(p => p.VehicleIdTypeId)
                .NotEmpty().WithMessage(p => localizer["RequiredField"])
                .NotNull().WithMessage(p => localizer["RequiredField"]);

            RuleFor(p => p.VehicleId)
                .NotEmpty().WithMessage(p => localizer["RequiredField"])
                .NotNull().WithMessage(p => localizer["RequiredField"]);

            RuleFor(p => p.VehicleOwnerIdentityNumber)
                .NotEmpty().WithMessage(p => localizer["RequiredField"])
                .NotNull().WithMessage(p => localizer["RequiredField"]);

            RuleFor(p => p.VehicleSumInsured)
                .NotEmpty().WithMessage(p => localizer["RequiredField"])
                .NotNull().WithMessage(p => localizer["RequiredField"]);

            RuleFor(p => p.VehicleRepairMethodId)
                .NotEmpty().WithMessage(p => localizer["RequiredField"])
                .NotNull().WithMessage(p => localizer["RequiredField"]);

            RuleFor(p => p.VehicleUseId)
                .NotEmpty().WithMessage(p => localizer["RequiredField"])
                .NotNull().WithMessage(p => localizer["RequiredField"]);

            RuleFor(p => p.VehicleTransmissionTypeId)
                .NotEmpty().WithMessage(p => localizer["RequiredField"])
                .NotNull().WithMessage(p => localizer["RequiredField"]);

            RuleFor(p => p.VehicleParkingLocationId)
                .NotEmpty().WithMessage(p => localizer["RequiredField"])
                .NotNull().WithMessage(p => localizer["RequiredField"]);

            RuleFor(p => p.VehicleModificationDetails)
                .NotEmpty().When(req => req.IsVehicleModified);

            RuleFor(model => model.Drivers)
                .Must(collection => collection != null)
                .WithMessage("Drivers required");
        }
    }
    #endregion
}
