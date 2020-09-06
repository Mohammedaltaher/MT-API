using System.Collections.Generic;

namespace  AggriPortal.API.Domain.Models
{
    public class PremiumBreakdown
    {
        public PremiumBreakdown()
        {
            ProductPremiumBreakdowns = new HashSet<ProductPremiumBreakdown>();
            ClientQuotationMotorPremiumBreakdowns = new HashSet<ClientQuotationMotorPremiumBreakdown>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public string NameAr { get; set; }
        public ICollection<ProductPremiumBreakdown> ProductPremiumBreakdowns { get; set; }
        public ICollection<ClientQuotationMotorPremiumBreakdown> ClientQuotationMotorPremiumBreakdowns { get; set; }
    }
}
