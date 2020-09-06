using AggriPortal.API.Domain.Enums;
using System;
using System.Collections.Generic;

namespace  AggriPortal.API.Domain.Models
{
    /// <summary>
    /// 
    /// </summary>
    public class ClientQuotationMotor
    {
        public ClientQuotationMotor()
        {
            Id = Guid.NewGuid();
            CreatedDate = DateTime.Now;
            StatusId = (int)ClientQuotationStatusEnum.Previewed;
            ClientQuotationMotorBenefits = new HashSet<ClientQuotationMotorBenefit>();
            ClientQuotationMotorPremiumBreakdowns = new HashSet<ClientQuotationMotorPremiumBreakdown>();
            ClientQuotationMotorDiscounts = new HashSet<ClientQuotationMotorDiscount>();
            ClientPayments = new HashSet<ClientPayment>();
        }
        public Guid Id { get; set; }
        public Guid QuotationRequestId { get; set; }
        public Guid ClientId { get; set; }
        public Guid QuotationProductId { get; set; }
        public int InsuranceCompanyId { get; set; }
        public string QuoteReferenceId { get; set; }
        public string InsurQuotationId { get; set; }
        public DateTime QuotationStartDate { get; set; }
        public DateTime QuotationEndDate { get; set; }
        public decimal MaxLiability { get; set; }
        public decimal DeductibleValue { get; set; }
        public decimal TotalPremium { get; set; }
        public int StatusId { get; set; }
        public DateTime CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public string UpdatedBy { get; set; }
        public Client Client { get; set; }
        public QuotationsMotorRequest QuotationsMotorRequest { get; set; }
        public InsuranceCompany InsuranceCompany { get; set; }
        public QuotationsMotorResponseProduct QuotationsMotorResponseProduct { get; set; }
        public ICollection<ClientQuotationMotorBenefit> ClientQuotationMotorBenefits { get; set; }
        public ICollection<ClientQuotationMotorPremiumBreakdown> ClientQuotationMotorPremiumBreakdowns { get; set; }
        public ICollection<ClientPayment> ClientPayments { get; set; }
        public ICollection<ClientQuotationMotorDiscount> ClientQuotationMotorDiscounts { get; set; }


    }

    public class ClientQuotationMotorBenefit
    {
        public ClientQuotationMotorBenefit()
        {
            Id = Guid.NewGuid();
            CreatedDate = DateTime.Now;
        }
        public Guid Id { get; set; }
        public Guid ClientQuotationId { get; set; }
        public int BenefitId { get; set; }
        public int BenefitTypeId { get; set; }
        public decimal BenefitAmount { get; set; }
        public decimal BenefitVATAmount { get; set; }
        public DateTime CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public Benefit Benefit { get; set; }
        public ClientQuotationMotor ClientQuotation { get; set; }
    }

    public class ClientQuotationMotorPremiumBreakdown
    {
        public ClientQuotationMotorPremiumBreakdown()
        {
            Id = Guid.NewGuid();
            CreatedDate = DateTime.Now;
        }
        public Guid Id { get; set; }
        public Guid ClientQuotationId { get; set; }
        public int BreakdownTypeId { get; set; }
        public decimal BreakdownAmount { get; set; }
        public decimal BreakdownPercentage { get; set; }
        public DateTime CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public PremiumBreakdown PremiumBreakdown { get; set; }
        public ClientQuotationMotor ClientQuotation { get; set; }
    }

    public class ClientQuotationMotorDiscount
    {
        public ClientQuotationMotorDiscount()
        {
            Id = Guid.NewGuid();
            CreatedDate = DateTime.Now;
        }
        public Guid Id { get; set; }
        public Guid ClientQuotationId { get; set; }
        public int DiscountTypeId { get; set; }
        public decimal DiscountPercentage { get; set; }
        public decimal DiscountAmout { get; set; }
        public string NCDEligibility { get; set; }
        public DateTime CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public DiscountType DiscountType { get; set; }
        public ClientQuotationMotor ClientQuotation { get; set; }
    }
}
