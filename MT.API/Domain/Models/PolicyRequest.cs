using System;

namespace  AggriPortal.API.Domain.Models
{
    public class PolicyRequest
    {
        public PolicyRequest()
        {
            Id = Guid.NewGuid();
            CreatedDate = DateTime.Now;
        }
        public Guid Id { get; set; }
        public string PolicyRequestRefId { get; set; }
        public string QuotationRequestRefId { get; set; }
        public string InsurQuotationId { get; set; }
        public int InsuranceCompanyId { get; set; }
        public Guid ClientQuotationId { get; set; }
        public Guid ClientId { get; set; }
        public string InsuredMobileNumber { get; set; }
        public string InsuredEmail { get; set; }
        public string InsuredIBAN { get; set; }
        public int? InsuredBankId { get; set; }
        public decimal? PaymentAmount { get; set; }
        public int? PaymentMethodId { get; set; }
        public bool IsPaymentSuccess { get; set; }
        public string PaymentInvoiceId { get; set; }
        public DateTime CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public InsuranceCompany InsuranceCompany { get; set; }
        public Client Client { get; set; }
        public Bank Bank { get; set; }
        public PaymentMethod PaymentMethod { get; set; }
        public ClientQuotationMotor ClientQuotation { get; set; }
    }
}
