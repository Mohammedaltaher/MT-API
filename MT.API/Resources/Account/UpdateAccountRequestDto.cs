
using FluentValidation;
using Microsoft.Extensions.Localization;
using System;

namespace  AggriPortal.API.Resources
{
    public class UpdateAccountRequestDto
    {
        public string FullName { get; set; }
        public string FullNameAr { get; set; }
        public DateTime CreatedDate { get; set; }
        public bool IsActive { get; set; }
        public string DefaultLang { get; set; }
        public string UserName { get; set; }
        public string NormalizedUserName { get; set; }
        public string Email { get; set; }
        public string NormalizedEmail { get; set; }
        public bool EmailConfirmed { get; set; }
        public string PhoneNumber { get; set; }
        public bool PhoneNumberConfirmed { get; set; }
        public bool TwoFactorEnabled { get; set; }
        public bool LockoutEnabled { get; set; }
        public int AccessFailedCount { get; set; }

    }
    #region Request Validator
    public class UpdateAccountRequestDtoValidator : AbstractValidator<UpdateAccountRequestDto>
    {
        public UpdateAccountRequestDtoValidator(IStringLocalizer<SharedResources> localizer)
        {
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