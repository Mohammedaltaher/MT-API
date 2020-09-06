﻿using AggriPortal.API.Contracts.Response;
using System.Collections.Generic;

namespace  AggriPortal.API.Contracts.Request
{
    public class IssuePolicyRequest
    {
        public string PolicyRequestId { get; set; }

        /// <summary>
        /// Unique request id generated by Concord System Format:QT-MT-YY-MM-DD- 0000
        /// </summary>
        public string QuotationRequestId { get; set; }

        /// <summary>
        /// Quotation reference Id generated by Insurance Company.
        /// </summary>
        public string QuotationId { get; set; }
        public int InsuranceCompanyId { get; set; }
        public int ProductTypeId { get; set; }
        public decimal DeductibleValue { get; set; }
        public decimal TotalPremium { get; set; }
        public List<Benefit> Benefits { get; set; }
        public string InsuredMobileNo { get; set; }
        public string InsuredEmail { get; set; }
        public string InsuredIBAN { get; set; }
        public int InsuredBankId { get; set; }
        public int? PaymentMethodId { get; set; }
        public bool IsPaymentSuccess { get; set; }
        public decimal PaymentAmount { get; set; }
        public string PaymentInvoiceId { get; set; }
    }
}
