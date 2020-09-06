using System.Collections.Generic;

namespace  AggriPortal.API.Domain.Models
{
    /// <summary>
    /// Vehicle Plate Type (Private,Public,..)
    /// </summary>
    public class VehiclePlateType
    {
        public VehiclePlateType()
        {
            ClientVehicles = new HashSet<ClientVehicle>();
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
        /// Name in arabic
        /// </summary>
        public string NameAr { get; set; }
        public ICollection<ClientVehicle> ClientVehicles { get; set; }
        public ICollection<QuotationsMotorRequest> QuotationsMotorRequests { get; set; }

    }
}
