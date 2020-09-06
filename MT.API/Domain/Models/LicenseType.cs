using System.Collections.Generic;

namespace  AggriPortal.API.Domain.Models
{
    /// <summary>
    /// License Type Master Table.
    /// </summary>
    public class LicenseType
    {
        public LicenseType()
        {
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

        public ICollection<QuotationsMotorRequestVehicleDriverLicense> QuotationsMotorRequestVehicleDriverLicenses { get; private set; }
    }
}
