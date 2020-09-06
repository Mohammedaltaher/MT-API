using System.Collections.Generic;

namespace  AggriPortal.API.Domain.Models
{
    /// <summary>
    /// Education Level Master Table.
    /// </summary>
    public class EducationLevel
    {
        public EducationLevel()
        {
            Clients = new HashSet<Client>();
            QuotationsMotorRequests = new HashSet<QuotationsMotorRequest>();
            QuotationsMotorRequestVehicleDrivers = new HashSet<QuotationsMotorRequestVehicleDriver>();
        }
        /// <summary>
        /// Key
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
        public ICollection<Client> Clients { get; set; }
        public ICollection<QuotationsMotorRequest> QuotationsMotorRequests { get; set; }
        public ICollection<QuotationsMotorRequestVehicleDriver> QuotationsMotorRequestVehicleDrivers { get; set; }
    }
}
