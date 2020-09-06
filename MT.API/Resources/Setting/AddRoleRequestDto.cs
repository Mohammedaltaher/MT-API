
using FluentValidation;
using Microsoft.Extensions.Localization;

namespace  AggriPortal.API.Resources
{
    public class AddRoleRequestDto
    {
        public string Name { get; set; }

    }
    #region Request Validator
    public class AddRoleRequestValidator : AbstractValidator<AddRoleRequestDto>
    {
        public AddRoleRequestValidator(IStringLocalizer<SharedResources> localizer)
        {
            RuleFor(p => p.Name)
                .NotEmpty().NotNull().WithMessage(x => localizer["RequiredField"]);
        }
    }
    #endregion
}

