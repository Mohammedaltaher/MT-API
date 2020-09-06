using System;

namespace  AggriPortal.API.Domain.Models
{
    public class PoliciesMotor
    {
        public PoliciesMotor()
        {
            Id = Guid.NewGuid();
            CreatedDate = DateTime.Now;
            CompCommissionVATPerc = 5;
        }
        public Guid Id { get; set; }
        public Guid PolicyRequestId { get; set; }
        public Guid ClientQuotationId { get; set; }
        public int InsuranceCompanyId { get; set; }
        public string PolicyRequestRefId { get; set; }
        public string QuotationRequestRefId { get; set; }
        public string InsuranceQuotationId { get; set; }
        public Guid ClientId { get; set; }
        public long InsuredId { get; set; }
        public long VehicleId { get; set; }
        public int ProductTypeId { get; set; }
        public string PolicyNumber { get; set; }
        public DateTime PolicyIssueDate { get; set; }
        public DateTime PolicyEffectiveDate { get; set; }
        public DateTime PolicyExpiryDate { get; set; }
        public decimal VehicleSumInsured { get; set; }
        public decimal DeductibleAmount { get; set; }
        public decimal TotalPremium { get; set; }
        public decimal TotalVATAmount { get; set; }
        public decimal TotalCompCommission { get; set; }
        public decimal CompCommissionPerc { get; set; }
        public decimal TotalCompCommissionVATAmount { get; set; }
        public decimal CompCommissionVATPerc { get; set; }
        public bool IsPolicyFileSent { get; set; }
        public string PolicyFilePath { get; set; }
        public string PolicyFile { get; set; }
        public bool IsNajmUpdated { get; set; }
        public DateTime? NajmUpdatedDate { get; set; }
        public string NajmVehicleReferenceId { get; set; }
        public DateTime CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public Client Client { get; set; }
        public ProductType ProductType { get; set; }
        public InsuranceCompany InsuranceCompany { get; set; }
        public ClientQuotationMotor ClientQuotation { get; set; }

    }
}
