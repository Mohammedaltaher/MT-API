using System.Collections.Generic;

namespace  AggriPortal.API.Domain.Models
{
    /// <summary>
    /// NCDFreeYear
    /// </summary>
    public class NCDFreeYear
    {
        public NCDFreeYear()
        {
            QuotationsMotorRequestVehicleDrivers = new HashSet<QuotationsMotorRequestVehicleDriver>();
            ProductDiscounts = new HashSet<ProductDiscount>();
            QuotationsMotorRequests = new HashSet<QuotationsMotorRequest>();
        }
        /// <summary>
        /// Key
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Name in english
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Name in arabic.
        /// </summary>
        public string NameAr { get; set; }
        public ICollection<QuotationsMotorRequestVehicleDriver> QuotationsMotorRequestVehicleDrivers { get; set; }
        public ICollection<ProductDiscount> ProductDiscounts { get; set; }
        public ICollection<QuotationsMotorRequest> QuotationsMotorRequests { get; set; }
    }
}
