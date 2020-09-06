
using AggriPortal.API.Contracts.Response;
using System;
using System.Collections.Generic;

namespace  AggriPortal.API.Resources
{
    public class ClientInvoicesRequestDto
    {
        public Guid ClientId { get; set; }
        public int[] Status { get; set; }
        public int? PageNumber { get; set; } 
        public int? PageSize { get; set; }
    }

    public class ClientInvoicesResponseDto : BaseResponse
    {
        public IEnumerable<ClientInvoicesDto> Data { get; set; }
        public int? TotalRecord { get; set; }
    }
    public class ApprovedClientInvoicesResponseDto : BaseResponse
    {
        public IEnumerable<ApprovedClientInvoicesDto> Data { get; set; }
        public int? TotalRecord { get; set; }

    }
    public class ClientInvoicesDto
    {
        public Guid Id { get; set; }
        public string PaymentReferenceId { get; set; }
        public Guid ClientQuotationId { get; set; }
        public string ClientQuoteReferenceId { get; set; }
        public string HyperpayCheckoutRefId { get; set; }
        public string HyperpayPaymentStatusRefId { get; set; }
        public string CardHolder { get; set; }
        public string CardToken { get; set; }
        public string CardBin { get; set; }
        public decimal Amount { get; set; }
        public string Currency { get; set; }
        public string InsuredIBAN { get; set; }
        public string BankName { get; set; }
        public string BankNameAr { get; set; }
        public string ProductTypeName { get; set; }
        public string ProductTypeNameAr { get; set; }
        public string InsuranceCompanyNameAr { get; set; }
        public string InsuranceCompanyName { get; set; }
        public string PaymentMethodName { get; set; }
        public string PaymentMethodNameAr { get; set; }
        public string PaymentResponseResultCode { get; set; }
        public string PaymentResponseResultDesc { get; set; }
        public string HyperpayCheckoutJsonResponse { get; set; }
        public string HyperpayPaymentStatusJsonResponse { get; set; }
        public DateTime CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public string UpdatedBy { get; set; }
       
    }

    public class ApprovedClientInvoicesDto
    {
        public Guid Id { get; set; }
        public string PaymentReferenceId { get; set; }
        public Guid ClientQuotationId { get; set; }
        public string ClientQuoteReferenceId { get; set; }
        public string CardToken { get; set; }
        public decimal Amount { get; set; }
        public string Currency { get; set; }
        public string InsuredIBAN { get; set; }
        public string BankName { get; set; }
        public string BankNameAr { get; set; }
        public string ProductTypeName { get; set; }
        public string ProductTypeNameAr { get; set; }
        public string InsuranceCompanyNameAr { get; set; }
        public string InsuranceCompanyName { get; set; }
        public string PaymentMethodName { get; set; }
        public string PaymentMethodNameAr { get; set; }
        public string HyperpayPaymentStatusJsonResponse { get; set; }
        public DateTime CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public string UpdatedBy { get; set; }

    }
}
