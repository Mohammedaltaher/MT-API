using System.Collections.Generic;

namespace  AggriPortal.API.Domain.Models
{
    /// <summary>
    /// Product Type Master Table.
    /// </summary>
    public class ProductType
    {
        public ProductType()
        {
            QuotationsMotorResponseProducts = new HashSet<QuotationsMotorResponseProduct>();
            Policies = new HashSet<PoliciesMotor>();
        }
        /// <summary>
        /// Key
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Type in English.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Type in Arabic.
        /// </summary>
        public string NameAr { get; set; }
        public decimal CompCommissionPerc { get; set; }
        public ICollection<QuotationsMotorResponseProduct> QuotationsMotorResponseProducts { get; set; }
        public ICollection<PoliciesMotor> Policies { get; set; }

    }
}
