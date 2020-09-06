
using FluentValidation;
using Microsoft.Extensions.Localization;

namespace  AggriPortal.API.Resources
{
    public class SignUserRoleRequestDto
    {
        public string UserId { get; set; }
        public string Roles { get; set; }

    }
    #region Request Validator
    public class  SignUserRoleRequestValidator : AbstractValidator<SignUserRoleRequestDto>
    {
        public  SignUserRoleRequestValidator(IStringLocalizer<SharedResources> localizer)
        {
            RuleFor(p => p.Roles)
                .NotEmpty().NotNull().WithMessage(x => localizer["RequiredField"]);
        }
    }
    #endregion
}

