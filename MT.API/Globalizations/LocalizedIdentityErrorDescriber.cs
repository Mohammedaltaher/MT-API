using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Localization;

namespace  AggriPortal.API.Globalizations
{
    public class LocalizedIdentityErrorDescriber : IdentityErrorDescriber
    {
        private readonly IStringLocalizer<SharedResources> _localizer;
        public LocalizedIdentityErrorDescriber(IStringLocalizer<SharedResources> localizer)
        {
            _localizer = localizer;
        }
        public override IdentityError DuplicateEmail(string email)
        {
            return new IdentityError
            {
                Code = nameof(DuplicateEmail),
                Description = string.Format(_localizer["IdentityErrorDuplicateEmail"], email)
            };
        }

        public override IdentityError DuplicateUserName(string userName)
        {
            return new IdentityError
            {
                Code = nameof(DuplicateUserName),
                Description = string.Format(_localizer["IdentityErrorDuplicateUserName"], userName)
            };
        }

        public override IdentityError InvalidEmail(string email)
        {
            return new IdentityError
            {
                Code = nameof(InvalidEmail),
                Description = string.Format(_localizer["IdentityErrorInvalidEmail"], email)
            };
        }

        public override IdentityError DuplicateRoleName(string role)
        {
            return new IdentityError
            {
                Code = nameof(DuplicateRoleName),
                Description = string.Format(_localizer["IdentityErrorDuplicateRoleName"], role)
            };
        }

        public override IdentityError InvalidRoleName(string role)
        {
            return new IdentityError
            {
                Code = nameof(InvalidRoleName),
                Description = string.Format(_localizer["IdentityErrorInvalidRoleName"], role)
            };
        }

        public override IdentityError InvalidToken()
        {
            return new IdentityError
            {
                Code = nameof(InvalidToken),
                Description = _localizer["IdentityErrorInvalidToken"]
            };
        }

        public override IdentityError InvalidUserName(string userName)
        {
            return new IdentityError
            {
                Code = nameof(InvalidUserName),
                Description = string.Format(_localizer["IdentityErrorInvalidUserName"], userName)
            };
        }

        //public override IdentityError LoginAlreadyAssociated()
        //{
        //    return new IdentityError
        //    {
        //        Code = nameof(LoginAlreadyAssociated),
        //        Description = _localizer["IdentityErrorLoginAlreadyAssociated"]
        //    };
        //}

        public override IdentityError PasswordMismatch()
        {
            return new IdentityError
            {
                Code = nameof(PasswordMismatch),
                Description = _localizer["IdentityErrorPasswordMismatch"]
            };
        }

        public override IdentityError PasswordRequiresDigit()
        {
            return new IdentityError
            {
                Code = nameof(PasswordRequiresDigit),
                Description = _localizer["IdentityErrorPasswordRequiresDigit"]
            };
        }

        public override IdentityError PasswordRequiresLower()
        {
            return new IdentityError
            {
                Code = nameof(PasswordRequiresLower),
                Description = _localizer["IdentityErrorPasswordRequiresLower"]
            };
        }

        public override IdentityError PasswordRequiresNonAlphanumeric()
        {
            return new IdentityError
            {
                Code = nameof(PasswordRequiresNonAlphanumeric),
                Description = _localizer["IdentityErrorPasswordRequiresNonAlphanumeric"]
            };
        }

        public override IdentityError PasswordRequiresUniqueChars(int uniqueChars)
        {
            return new IdentityError
            {
                Code = nameof(PasswordRequiresUniqueChars),
                Description = string.Format(_localizer["IdentityErrorPasswordRequiresUniqueChars"], uniqueChars)
            };
        }

        public override IdentityError PasswordRequiresUpper()
        {
            return new IdentityError
            {
                Code = nameof(PasswordRequiresUpper),
                Description = _localizer["IdentityErrorPasswordRequiresUpper"]
            };
        }

        public override IdentityError PasswordTooShort(int length)
        {
            return new IdentityError
            {
                Code = nameof(PasswordTooShort),
                Description = string.Format(_localizer["IdentityErrorPasswordTooShort"], length)
            };
        }

        public override IdentityError UserAlreadyHasPassword()
        {
            return new IdentityError
            {
                Code = nameof(UserAlreadyHasPassword),
                Description = _localizer["IdentityErrorUserAlreadyHasPassword"]
            };
        }

        public override IdentityError UserAlreadyInRole(string role)
        {
            return new IdentityError
            {
                Code = nameof(UserAlreadyInRole),
                Description = string.Format(_localizer["IdentityErrorUserAlreadyInRole"], role)
            };
        }

        public override IdentityError UserNotInRole(string role)
        {
            return new IdentityError
            {
                Code = nameof(UserNotInRole),
                Description = string.Format(_localizer["IdentityErrorUserNotInRole"], role)
            };
        }

        public override IdentityError UserLockoutNotEnabled()
        {
            return new IdentityError
            {
                Code = nameof(UserLockoutNotEnabled),
                Description = _localizer["IdentityErrorUserLockoutNotEnabled"]
            };
        }

        public override IdentityError RecoveryCodeRedemptionFailed()
        {
            return new IdentityError
            {
                Code = nameof(RecoveryCodeRedemptionFailed),
                Description = _localizer["IdentityErrorRecoveryCodeRedemptionFailed"]
            };
        }

        public override IdentityError ConcurrencyFailure()
        {
            return new IdentityError
            {
                Code = nameof(ConcurrencyFailure),
                Description = _localizer["IdentityErrorConcurrencyFailure"]
            };
        }

        public override IdentityError DefaultError()
        {
            return new IdentityError
            {
                Code = nameof(DefaultError),
                Description = _localizer["IdentityErrorDefault"]
            };
        }
    }
}
