using FluentValidation;
using Microsoft.Extensions.Localization;

namespace  AggriPortal.API.Resources
{
    public class AddClientRequestDto
    {
        public long IdentityNumber { get; set; }
        public string BirthDate { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
    }

    #region Request Validator
    public class AddClientRequestDtoValidator : AbstractValidator<AddClientRequestDto>
    {
        public AddClientRequestDtoValidator(IStringLocalizer<AddClientRequestDto> localizer)
        {
            RuleFor(p => p.IdentityNumber)
                .NotEmpty().WithMessage(p => localizer["RequiredField"])
                .NotNull().WithMessage(p => localizer["RequiredField"]);
            //.InclusiveBetween(1000000000, 7999999999).WithMessage("Invalid Insured Identity number.");

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
    #endregion
}
