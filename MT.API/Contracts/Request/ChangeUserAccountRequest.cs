using FluentValidation;
using Microsoft.Extensions.Localization;
using System.Collections.Generic;

namespace  AggriPortal.API.Contracts.Request
{
    public class ChangePasswordRequest
    {
        public string UserId { get; set; }
        public string OldPassword { get; set; }
        public string NewPassword { get; set; }
        public string ConfirmNewPassword { get; set; }
    }

    public class ChangePasswordVerificationRequest
    {
        public string UserId { get; set; }
        public string NewPassword { get; set; }
        public string VerificationCode { get; set; }
    }

    public class PasswordResetRequest
    {
        public string Email { get; set; }
        public string LastPhoneDigits { get; set; }
    }

    public class PasswordResetVerificationRequest
    {
        public string Email { get; set; }
        public string Code { get; set; }
        public string NewPassword { get; set; }
    }

    public class ChangeUserNameRequest
    {
        public string UserId { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
    }

    public class ChangeUserNameVerificationRequest
    {
        public string UserId { get; set; }
        public string UserName { get; set; }
        public string VerificationCode { get; set; }
    }

    public class ChangePhoneNumberRequest
    {
        public string UserId { get; set; }
        public string NewPhoneNumber { get; set; }
        public string Password { get; set; }
    }

    public class ChangePhoneNumberVerificationRequest
    {
        public string UserId { get; set; }
        public string NewPhoneNumber { get; set; }
        public string VerificationCode { get; set; }
    }

    public class ChangeDefaultLanguageRequest
    {
        public string UserId { get; set; }
        public string Language { get; set; }
    }

    //public class PasswordChangedByAdminRequestDto
    //{
    //    public string Id { get; set; }
    //    public string NewPassword { get; set; }

    //}

    //public class ChangeEmailRequestDto
    //{
    //    public string Id { get; set; }
    //    public string Email { get; set; }
    //}
    //public class UserActivationRequestDto
    //{
    //    public string Id { get; set; }
    //    public bool IsActive { get; set; }
    //}
    #region Request Validator
    public class ChangePasswordRequestValidator : AbstractValidator<ChangePasswordRequest>
    {
        public ChangePasswordRequestValidator(IStringLocalizer<SharedResources> localizer)
        {
            RuleFor(p => p.UserId)
                .NotEmpty().NotNull().WithMessage(x => localizer["RequiredField"]);
            
            RuleFor(p => p.OldPassword)
                .NotEmpty().WithMessage(x => localizer["RequiredField"]);

            RuleFor(p => p.NewPassword)
                .NotEmpty().WithMessage(x => localizer["RequiredField"])
                .NotNull();

            RuleFor(p => p.ConfirmNewPassword)
                .Equal(p => p.NewPassword).WithMessage(x => localizer["ConfirmPasswordNotMatch"]);
        }
    }
    public class ChangePasswordVerificationRequestValidator : AbstractValidator<ChangePasswordVerificationRequest>
    {
        public ChangePasswordVerificationRequestValidator(IStringLocalizer<SharedResources> localizer)
        {
            RuleFor(p => p.UserId)
                .NotEmpty().NotNull().WithMessage(x => localizer["RequiredField"]);

            RuleFor(p => p.NewPassword)
                .NotEmpty().WithMessage(x => localizer["RequiredField"])
                .NotNull();

            RuleFor(p => p.VerificationCode)
                .NotEmpty().WithMessage(x => localizer["RequiredField"])
                .NotNull();
        }
    }
    
    public class PasswordResetRequestValidator : AbstractValidator<PasswordResetRequest>
    {
        public PasswordResetRequestValidator(IStringLocalizer<SharedResources> localizer)
        {
            RuleFor(p => p.Email)
                .NotEmpty().EmailAddress().WithMessage(x => localizer["RequiredField"])
                .NotNull();

            RuleFor(p => p.LastPhoneDigits)
                .NotEmpty().WithMessage(x => localizer["RequiredField"])
                .Length(4).WithMessage(x => "Should be 4 digits")
                .NotNull();
        }
    }
    public class PasswordResetVerificationRequestValidator : AbstractValidator<PasswordResetVerificationRequest>
    {
        public PasswordResetVerificationRequestValidator(IStringLocalizer<SharedResources> localizer)
        {
            RuleFor(p => p.Email)
                .NotEmpty().WithMessage(x => localizer["RequiredField"])
                .EmailAddress().WithMessage(x => "Invalid email")
                .NotNull();

            RuleFor(p => p.NewPassword)
                .NotEmpty().WithMessage(x => localizer["RequiredField"])
                .NotNull();

            RuleFor(p => p.Code)
                .NotEmpty().WithMessage(x => localizer["RequiredField"])
                .NotNull();
        }
    }
    
    public class ChangeUserNameRequestValidator : AbstractValidator<ChangeUserNameRequest>
    {
        public ChangeUserNameRequestValidator(IStringLocalizer<SharedResources> localizer)
        {
            RuleFor(p => p.UserId)
                .NotEmpty().WithMessage(x => localizer["RequiredField"])
                .NotNull();

            RuleFor(p => p.UserName)
                .NotEmpty().WithMessage(x => localizer["RequiredField"])
                .NotNull();

            RuleFor(p => p.Password)
                .NotEmpty().WithMessage(x => localizer["RequiredField"])
                .NotNull();
        }
    }
    public class ChangeUserNameVerificationRequestValidator : AbstractValidator<ChangeUserNameVerificationRequest>
    {
        public ChangeUserNameVerificationRequestValidator(IStringLocalizer<SharedResources> localizer)
        {
            RuleFor(p => p.UserId)
                .NotEmpty().WithMessage(x => localizer["RequiredField"])
                .NotNull();

            RuleFor(p => p.UserName)
                .NotEmpty().WithMessage(x => localizer["RequiredField"])
                .NotNull();

            RuleFor(p => p.VerificationCode)
                .NotEmpty().WithMessage(x => localizer["RequiredField"])
                .NotNull();
        }
    }

    public class ChangePhoneNumberRequestValidator : AbstractValidator<ChangePhoneNumberRequest>
    {
        public ChangePhoneNumberRequestValidator(IStringLocalizer<SharedResources> localizer)
        {
            RuleFor(p => p.UserId)
                .NotEmpty().WithMessage(x => localizer["RequiredField"])
                .NotNull();

            RuleFor(p => p.NewPhoneNumber)
                .NotEmpty().WithMessage(x => localizer["RequiredField"])
                .NotNull();

            RuleFor(p => p.Password)
                .NotEmpty().WithMessage(x => localizer["RequiredField"])
                .NotNull();
        }
    }
    public class ChangePhoneNumberVerificationRequestValidator : AbstractValidator<ChangePhoneNumberVerificationRequest>
    {
        public ChangePhoneNumberVerificationRequestValidator(IStringLocalizer<SharedResources> localizer)
        {
            RuleFor(p => p.UserId)
                .NotEmpty().WithMessage(x => localizer["RequiredField"])
                .NotNull();

            RuleFor(p => p.NewPhoneNumber)
                .NotEmpty().WithMessage(x => localizer["RequiredField"])
                .NotNull();

            RuleFor(p => p.VerificationCode)
                .NotEmpty().WithMessage(x => localizer["RequiredField"])
                .NotNull();
        }
    }
    
    public class ChangeDefaultLanguageRequestValidator : AbstractValidator<ChangeDefaultLanguageRequest>
    {
        public ChangeDefaultLanguageRequestValidator(IStringLocalizer<SharedResources> localizer)
        {
            List<string> languages = new List<string>{ "en", "ar" };

            RuleFor(p => p.Language)
                .NotEmpty().WithMessage(x => localizer["RequiredField"])
                .Must(p => languages.Contains(p)).WithMessage(x => "Invalid language")
                .NotNull();
        }
    }
    #endregion
}