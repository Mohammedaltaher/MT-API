using System.Collections.Generic;

namespace  AggriPortal.API.Domain.Models
{
    /// <summary>
    /// Country Master Table.
    /// </summary>
    public class Country
    {
        public Country()
        {
            Clients = new HashSet<Client>();
            QuotationsMotorRequests = new HashSet<QuotationsMotorRequest>();
            QuotationsMotorRequestVehicleDriverLicenses = new HashSet<QuotationsMotorRequestVehicleDriverLicense>();
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
        public ICollection<Client> Clients { get; set; }
        public ICollection<QuotationsMotorRequest> QuotationsMotorRequests { get; set; }
        public ICollection<QuotationsMotorRequestVehicleDriverLicense> QuotationsMotorRequestVehicleDriverLicenses { get; set; }
    }
}
