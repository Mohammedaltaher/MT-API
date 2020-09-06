using FluentValidation;
using Microsoft.Extensions.Localization;

namespace  AggriPortal.API.Resources
{
    public class LoginRequestDto
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        //public string ExtId { get; set; }  // ClientId.
        public bool RememberMe { get; set; }
    }

    #region Request Validator
    public class UserLoginRequestValidator : AbstractValidator<LoginRequestDto>
    {
        public UserLoginRequestValidator(IStringLocalizer<SharedResources> localizer)
        {
            RuleFor(p => p.UserName)
                .NotEmpty().WithMessage(x => localizer["RequiredField"]);
            RuleFor(p => p.Password)
                .NotEmpty().WithMessage(x => localizer["RequiredField"]);

        }
    }
    #endregion
}
