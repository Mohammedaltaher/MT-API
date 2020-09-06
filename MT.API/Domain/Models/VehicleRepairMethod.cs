using System.Collections.Generic;

namespace  AggriPortal.API.Domain.Models
{
    /// <summary>
    /// Repair method
    /// </summary>
    public class VehicleRepairMethod
    {
        public VehicleRepairMethod()
        {
            ClientVehicles = new HashSet<ClientVehicle>();
            QuotationsMotorRequests = new HashSet<QuotationsMotorRequest>();

        }
        /// <summary>
        /// Key.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Name in english.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Name in arabic.
        /// </summary>
        public string NameAr { get; set; }
        public ICollection<ClientVehicle> ClientVehicles { get; set; }
        public ICollection<QuotationsMotorRequest> QuotationsMotorRequests { get; set; }

    }
}
