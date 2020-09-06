using System;
using System.Collections.Generic;

namespace  AggriPortal.API.Domain.Models
{
    public class InsuranceCompany
    {
        public InsuranceCompany()
        {
            CreatedDate = DateTime.Now;
            QuotationsMotorResponses = new HashSet<QuotationsMotorResponse>();
            ClientQuotationMotors = new HashSet<ClientQuotationMotor>();
            PolicyRequests = new HashSet<PolicyRequest>();
            PoliciesMotors = new HashSet<PoliciesMotor>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public string NameAr { get; set; }
        public string AboutCompany { get; set; }
        public string AboutCompanyAr { get; set; }
        public string Logo { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string Website { get; set; }
        public string Address { get; set; }
        public string ConditionsFilePath { get; set; }
        public string QuotationEndPoint { get; set; }
        public string IssuePolicyEndPoint { get; set; }
        public string HttpClientName { get; set; }
        public string LiveBaseUrl { get; set; }
        public string LiveToken { get; set; }
        public string TestBaseUrl { get; set; }
        public string TestToken { get; set; }
        public DateTime CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public ICollection<QuotationsMotorResponse> QuotationsMotorResponses { get; set; }
        public ICollection<PolicyRequest> PolicyRequests { get; set; }
        public ICollection<PoliciesMotor> PoliciesMotors { get; set; }
        public ICollection<ClientQuotationMotor> ClientQuotationMotors { get; set; }
    }
}
