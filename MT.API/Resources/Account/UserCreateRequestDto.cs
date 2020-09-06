using FluentValidation;
using Microsoft.Extensions.Localization;

namespace  AggriPortal.API.Resources
{
    public class UserCreateRequestDto
    {
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
        public string Roles { get; set; }
         public string FullName { get; set; }
        public string FullNameAr { get; set; }
    }

    #region Validations
    public class UserRegistrationRequestValidator : AbstractValidator<UserCreateRequestDto>
    {
        public UserRegistrationRequestValidator(IStringLocalizer<SharedResources> localizer)
        {
            RuleFor(p => p.PhoneNumber)
                .NotNull().WithMessage(x => localizer["RequiredField"])
                .NotEmpty().WithMessage(x => localizer["RequiredField"])
                .MaximumLength(12).MinimumLength(12).WithMessage(x => localizer["InvalidPhoneNumber"]);
            
            RuleFor(p => p.Email)
                .NotNull().WithMessage(x => localizer["RequiredField"])
                .NotEmpty().WithMessage(x => localizer["RequiredField"])
                .EmailAddress().WithMessage(x => localizer["InvalidEmail"]);

            RuleFor(p => p.Password)
                .NotNull().WithMessage(x => localizer["RequiredField"])
                .NotEmpty().WithMessage(x => localizer["RequiredField"]);
            RuleFor(p => p.ConfirmPassword)
                .Equal(p => p.Password).WithMessage(x=> localizer["ConfirmPasswordNotMatch"]);
        }
    }
    #endregion
}
