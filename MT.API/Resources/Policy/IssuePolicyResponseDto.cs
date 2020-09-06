using AggriPortal.API.Contracts.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AggriPortal.API.Resources
{
    public class IssuePolicyResponseDto : BaseResponse
    {
        public string PolicyReferenceId { get; set; }
        public string QuoteReferenceId { get; set; }
        public string PolicyNumber { get; set; }
        public DateTime InvoiceDate { get; set; }
        public PolicyInsuredInfoDto InsuredInfo { get; set; }
        public PolicyVehicleInfoDto VehicleInfo { get; set; }
        public InsuranceCompanyDto InsuranceCompany { get; set; }
        public PolicyProductDto Product { get; set; }
        public List<PolicyLinkDto> Links { get; set; }

    }
    public class PolicyProductDto
    {
        public string Name { get; set; }
        public string NameAr { get; set; }
        public DateTime PolicyIssueDate { get; set; }
        public DateTime PolicyEffectiveDate { get; set; }
        public DateTime PolicyExpiryDate { get; set; }
        public ProductDeductibleDto Deductibles { get; set; }
        public List<ProductBenefitDto> Benefits { get; set; }

    }

    public class PolicyInsuredInfoDto
    {
        public long IdentityNumber { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string FirstNameAr { get; set; }
        public string MiddleNameAr { get; set; }
        public string LastNameAr { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }


    }

    public class PolicyVehicleInfoDto
    {
        public long VehicleId { get; set; }
        public int PlateNumber { get; set; }
        public string PlateFirstLetter { get; set; }
        public string PlateSecondLetter { get; set; }
        public string PlateThirdLetter { get; set; }
        public int ModelYear { get; set; }
        public string Maker { get; set; }
        public string Model { get; set; }
    }

    public class PolicyLinkDto
    {
        public string Name { get; set; }
        public string Url { get; set; }
    }
}
