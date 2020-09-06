using AggriPortal.API.Contracts.Response;
using System;
using System.Collections.Generic;

namespace  AggriPortal.API.Resources
{
    public class ProfileDashboardResponse : BaseResponse
    {
        public ProfilePoliciesDashboarDto Data { get; set; }
    }
    public class ProfilePoliciesDashboarDto
    {
        public int TotalPursharedPolicy { get; set; }
        public int TotalAlmostExpried { get; set; }
        public int TotalExpiry { get; set; }
        public int TotalPendingNajm { get; set; }
        public IEnumerable<ProfilePoliciesMotorDto> Policies { get; set; }
    }    

    public class ProfilePoliciesMotorDto
    {
        public Guid Id { get; set; }
        public long VehicleId { get; set; }
        public string InsuranceCompany { get; set; }
        public string InsuranceCompanyAr { get; set; }
        public string ProductType { get; set; }
        public string ProductTypeAr { get; set; }
        public string PolicyNumber { get; set; }
        public DateTime PolicyEffectiveDate { get; set; }
        public DateTime PolicyExpiryDate { get; set; }
        public DateTime PolicyIssueDate { get; set; }
        public decimal DeductibleAmount { get; set; }
        public decimal TotalPremium { get; set; }
    }
}
