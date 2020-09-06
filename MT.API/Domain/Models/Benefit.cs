using System.Collections.Generic;

namespace  AggriPortal.API.Domain.Models
{
    /// <summary>
    /// Policy Benefit Master Table.
    /// </summary>
    public class Benefit
    {
        public Benefit()
        {
            QuotationsMotorResponseProductBenefits = new HashSet<QuotationsMotorResponseProductBenefit>();
            ClientQuotationMotorBenefits = new HashSet<ClientQuotationMotorBenefit>();
        }
        /// <summary>
        /// Primary Key
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Benefit Name in English
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Benefit Name In Arabic.
        /// </summary>
        public string NameAr { get; set; }
        public ICollection<QuotationsMotorResponseProductBenefit> QuotationsMotorResponseProductBenefits { get; private set; }
        public ICollection<ClientQuotationMotorBenefit> ClientQuotationMotorBenefits { get; private set; }

    }
}
