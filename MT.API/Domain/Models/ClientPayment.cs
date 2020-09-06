using AggriPortal.API.Domain.Enums;
using System;

namespace  AggriPortal.API.Domain.Models
{
    public class ClientPayment
    {
        public ClientPayment()
        {
            Id = Guid.NewGuid();
            PaymentStatusId = (int)PaymentStatusEnum.Pending;
            CreatedDate = DateTime.Now;
        }
        public Guid Id { get; set; }
        public Guid ClientId { get; set; }
        public string PaymentReferenceId { get; set; }
        public Guid ClientQuotationId { get; set; }
        public string ClientQuoteReferenceId { get; set; }
        public string HyperpayCheckoutRefId { get; set; }
        public string HyperpayPaymentStatusRefId { get; set; }
        public string CardHolder { get; set; }
        public string CardToken { get; set; }
        public string CardBin { get; set; }
        public string CardLast4 { get; set; }
        public string ExpiryMonth { get; set; }
        public string ExpiryYear { get; set; }
        public decimal Amount { get; set; }
        public string Currency { get; set; }
        public string InsuredIBAN { get; set; }
        public int? BankId { get; set; }
        public int? PaymentMethodId { get; set; }
        public int PaymentStatusId { get; set; }
        public string PaymentResponseResultCode { get; set; }
        public string PaymentResponseResultDesc { get; set; }
        public string HyperpayCheckoutJsonResponse { get; set; }
        public string HyperpayPaymentStatusJsonResponse { get; set; }
        public DateTime CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public string UpdatedBy { get; set; }
        public PaymentMethod PaymentMethod { get; set; }
        public Client Client { get; set; }
        public ClientQuotationMotor ClientQuotation { get; set; }
        public Bank Bank { get; set; }

    }
}
