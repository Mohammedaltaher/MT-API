
using FluentValidation;
using Microsoft.Extensions.Localization;

namespace  AggriPortal.API.Resources
{
    public class UpdateClientRequestDto
    {

        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string FirstNameAr { get; set; }
        public string MiddleNameAr { get; set; }
        public string LastNameAr { get; set; }
        public int IdentityTypeId { get; set; }
        public long IdentityNumber { get; set; }
        public int? IdentityIssuePlaceId { get; set; }
        public string BirthDate { get; set; }
        public string GenderId { get; set; }
        public int? NationalityId { get; set; }
        public int? SocialStatusId { get; set; }
        public int? OccupationId { get; set; }
        public int? EducationLevelId { get; set; }
        public int? ChildrenUnder16Years { get; set; }
        public int? BuildingNumber { get; set; }
        public string Street { get; set; }
        public string District { get; set; }
        public string SaudiAddressCity { get; set; }
        public int? PostalCode { get; set; }
        public int? AdditionalNumber { get; set; }
        public int? WorkCityId { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string IBAN { get; set; }
    }
    #region Request Validator
    public class UpdateClientRequestDtoValidator : AbstractValidator<UpdateClientRequestDto>
    {
        public UpdateClientRequestDtoValidator(IStringLocalizer<SharedResources> localizer)
        {
            RuleFor(p => p.IdentityNumber)
                .NotEmpty().WithMessage(p => localizer["RequiredField"])
                .NotNull().WithMessage(p => localizer["RequiredField"]);

            RuleFor(p => p.IdentityTypeId)
                .NotEmpty().WithMessage(p => localizer["RequiredField"])
                .NotNull().WithMessage(p => localizer["RequiredField"]);

            RuleFor(p => p.BirthDate)
                .NotEmpty().WithMessage(p => localizer["RequiredField"])
                .NotNull().WithMessage(p => localizer["RequiredField"]);

            RuleFor(p => p.Email)
                .NotEmpty().WithMessage(p => localizer["RequiredField"])
                .NotNull().WithMessage(p => localizer["RequiredField"])
                .EmailAddress().WithMessage(p => localizer["InvalidEmail"]);

            RuleFor(p => p.PhoneNumber)
                .NotEmpty().WithMessage(p => localizer["RequiredField"])
                .NotNull().WithMessage(p => localizer["RequiredField"])
                .MaximumLength(12).MinimumLength(12).WithMessage(x => localizer["InvalidPhoneNumber"]);
        }
    }
}
#endregion