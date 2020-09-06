using System;
using System.Collections.Generic;

namespace  AggriPortal.API.Contracts.Response
{
    public class InsureQuotationResponse : BaseResponse
    {
        public string QuotationRequestId { get; set; }
        public int InsuranceCompanyId { get; set; }
        public string QuotationId { get; set; }
        public DateTime QuotationStartDate { get; set; }
        public DateTime QuotationEndDate { get; set; }
        public List<Product> Products { get; set; }
    }

    public class Product
    {
        public int ProductTypeId { get; set; }
        public DateTime PolicyEffectiveDate { get; set; }
        public DateTime PolicyExpiryDate { get; set; }
        public decimal MaxLiability { get; set; }
        public List<Deductible> Deductibles { get; set; }
        public List<Benefit> Benefits { get; set; }
    }
    public class Deductible
    {
        public decimal TotalPremium { get; set; }
        public decimal DeductibleValue { get; set; }
        public decimal TotalVATAmount { get; set; }
        public List<PremiumBreakdown> PremiumBreakdowns { get; set; }
        public List<PremiumDiscount> Discounts { get; set; }
    }
    public class Benefit
    {
        public int BenefitId { get; set; }
        public int BenefitTypeId { get; set; }
        public decimal BenefitAmount { get; set; }
        public decimal BenefitVATAmount { get; set; }
    }

    public class PremiumBreakdown
    {
        public int BreakdownTypeId { get; set; }
        public decimal BreakdownPercentage { get; set; }
        public decimal BreakdownAmount { get; set; }
    }

    public class PremiumDiscount
    {
        public int DiscountTypeId { get; set; }
        public decimal DiscountPercentage { get; set; }
        public decimal DiscountAmount { get; set; }
        public int? NCDFreeYears { get; set; }
    }
}
