using System;
using System.Collections.Generic;

namespace  AggriPortal.API.Domain.Models
{
    /// <summary>
    /// 
    /// </summary>
    public class QuotationsMotorResponse
    {
        public QuotationsMotorResponse()
        {
            Id = Guid.NewGuid();
            CreatedDate = DateTime.Now;
            QuotationsMotorResponseProducts = new HashSet<QuotationsMotorResponseProduct>();
        } 
        public Guid Id { get; set; }
        public Guid QuotationReqtId { get; set; }
        public string RequestReferenceId { get; set; }
        public int InsuranceCompanyId { get; set; }
        /// <summary>
        /// Insurance Qoutation Reference Id
        /// </summary>
        public string QuotationId { get; set; }
        public DateTime QuotationStartDate { get; set; }
        public DateTime QuotationEndDate { get; set; }
        public DateTime CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public InsuranceCompany InsuranceCompany { get; set; }
        public QuotationsMotorRequest QuotationsMotorRequest { get; set; }
        public ICollection<QuotationsMotorResponseProduct> QuotationsMotorResponseProducts { get; set; }

    }
    public class QuotationsMotorResponseProduct
    {
        public QuotationsMotorResponseProduct()
        {
            Id = Guid.NewGuid();
            CreatedDate = DateTime.Now;
            QuotationsMotorResponseProductBenefits = new HashSet<QuotationsMotorResponseProductBenefit>();
            ClientQuotationMotors = new HashSet<ClientQuotationMotor>();
        }
        public Guid Id { get; set; }
        public Guid QuotationResponseId { get; set; }
        public int ProductTypeId { get; set; }
        public DateTime PolicyEffectiveDate { get; set; }
        public DateTime PolicyExpiryDate { get; set; }
        public decimal? MaxLiability { get; set; }
        public DateTime CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public ProductType ProductType { get; set; }
        public QuotationsMotorResponse QuotationsMotorResponse { get; set; }
        public ICollection<QuotationsMotorResponseProductDeductible> QuotationsMotorResponseProductDeductibles { get; set; }
        public ICollection<QuotationsMotorResponseProductBenefit> QuotationsMotorResponseProductBenefits { get; set; }
        public ICollection<ClientQuotationMotor> ClientQuotationMotors { get; set; }
    }
    public class QuotationsMotorResponseProductDeductible
    {
        public QuotationsMotorResponseProductDeductible()
        {
            Id = Guid.NewGuid();
            CreatedDate = DateTime.Now;
            PremiumBreakdowns = new HashSet<ProductPremiumBreakdown>();
            Discounts = new HashSet<ProductDiscount>();
        }
        public Guid Id { get; set; }
        public Guid QuotationProductId { get; set; }
        public decimal DeductibleValue { get; set; }
        public decimal TotalPremium { get; set; }
        public DateTime CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public ICollection<ProductPremiumBreakdown> PremiumBreakdowns { get; set; }
        public ICollection<ProductDiscount> Discounts { get; set; }
        public QuotationsMotorResponseProduct QuotationsMotorResponseProduct { get; set; }

    }
    public class QuotationsMotorResponseProductBenefit
    {
        public QuotationsMotorResponseProductBenefit()
        {
            Id = Guid.NewGuid();
            CreatedDate = DateTime.Now;
        }
        public Guid Id { get; set; }
        public Guid QuotationProductId { get; set; }
        public int BenefitId { get; set; }
        public int BenefitTypeId { get; set; }
        public decimal BenefitAmount { get; set; }
        public decimal BenefitVATAmount { get; set; }
        public DateTime CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public Benefit Benefit { get; set; }
        public QuotationsMotorResponseProduct QuotationsMotorResponseProduct { get; set; }
    }
    public class ProductPremiumBreakdown
    {
        public ProductPremiumBreakdown()
        {
            Id = Guid.NewGuid();
            CreatedDate = DateTime.Now;
        }
        public Guid Id { get; set; }
        public Guid ProductDeductibleId { get; set; }
        public int BreakdownTypeId { get; set; }
        public decimal BreakdownAmount { get; set; }
        public decimal BreakdownPercentage { get; set; }
        public DateTime CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public PremiumBreakdown PremiumBreakdown { get; set; }
        public QuotationsMotorResponseProductDeductible QuotationsMotorResponseProductDeductible { get; set; }
    }
    public class ProductDiscount
    {
        public ProductDiscount()
        {
            Id = Guid.NewGuid();
            CreatedDate = DateTime.Now;
        }
        public Guid Id { get; set; }
        public Guid ProductDeductibleId { get; set; }
        public int DiscountTypeId { get; set; }
        public decimal DiscountPercentage { get; set; }
        public decimal DiscountAmout { get; set; }
        public int? NCDFreeYearsId { get; set; }
        public DateTime CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public DiscountType DiscountType { get; set; }
        public NCDFreeYear NCDFreeYear { get; set; }
        public QuotationsMotorResponseProductDeductible QuotationsMotorResponseProductDeductible { get; set; }
    }
}
