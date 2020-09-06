
using FluentValidation;
using Microsoft.Extensions.Localization;

namespace  AggriPortal.API.Resources
{
    public class AddUserClaimRequestDto
    {
        public string UserId { get; set; }
        public string ClaimsValue { get; set; }

    }
    #region Request Validator
    public class AddUserClaimRequestValidator : AbstractValidator<AddUserClaimRequestDto>
    {
        public AddUserClaimRequestValidator(IStringLocalizer<SharedResources> localizer)
        {
            RuleFor(p => p.UserId)
                .NotEmpty().NotNull().WithMessage(x => localizer["RequiredField"]);
            RuleFor(p => p.ClaimsValue)
               .NotEmpty().NotNull().WithMessage(x => localizer["RequiredField"]);
        }
    }
    #endregion
}

