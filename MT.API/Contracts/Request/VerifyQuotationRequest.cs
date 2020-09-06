using FluentValidation;
using Microsoft.Extensions.Localization;

namespace  AggriPortal.API.Contracts.Request
{
    public class VerifyQuotationRequest
    {
        public int InsuredIdentityTypeId { get; set; }
        public long InsuredIdentityNumber { get; set; }
        public int VehicleIdTypeId { get; set; }
        public long VehicleId { get; set; }
    }

    #region Request Validator
    public class VerifyQuotationRequestValidator : AbstractValidator<VerifyQuotationRequest>
    {
        public VerifyQuotationRequestValidator(IStringLocalizer<VerifyQuotationRequestValidator> localizer)
        {
            RuleFor(p => p.InsuredIdentityTypeId).NotEmpty().NotNull().WithMessage(p => localizer["RequiredField"]);

            RuleFor(p => p.InsuredIdentityNumber)
                .NotEmpty().WithMessage(p => localizer["RequiredField"])
                .NotNull().WithMessage(p => localizer["RequiredField"])
                .InclusiveBetween(1000000000, 7999999999).WithMessage("Invalid Insured Identity number.");

            RuleFor(p => p.VehicleIdTypeId)
                .NotEmpty().WithMessage(p => localizer["RequiredField"])
                .NotNull().WithMessage(p => localizer["RequiredField"]);

            RuleFor(p => p.VehicleId)
                .NotEmpty().WithMessage(p => localizer["RequiredField"])
                .NotNull().WithMessage(p => localizer["RequiredField"]);
        }
    }
    #endregion
}
