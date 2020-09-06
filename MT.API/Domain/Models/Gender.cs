using System.Collections.Generic;

namespace  AggriPortal.API.Domain.Models
{
    /// <summary>
    /// Gender Master Table.
    /// </summary>
    public class Gender
    {
        public Gender()
        {
            Clients = new HashSet<Client>();
            QuotationsMotorRequests = new HashSet<QuotationsMotorRequest>();
            QuotationsMotorRequestVehicleDrivers = new HashSet<QuotationsMotorRequestVehicleDriver>();
        }
        /// <summary>
        /// Key
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// Name in english.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Name in arabic.
        /// </summary>
        public string NameAr { get; set; }
        public ICollection<Client> Clients { get; set; }
        public ICollection<QuotationsMotorRequest> QuotationsMotorRequests { get; set; }
        public ICollection<QuotationsMotorRequestVehicleDriver> QuotationsMotorRequestVehicleDrivers { get; set; }
    }
}
