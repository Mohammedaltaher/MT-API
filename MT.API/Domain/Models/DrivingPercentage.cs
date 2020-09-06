using System.Collections.Generic;

namespace  AggriPortal.API.Domain.Models
{
    /// <summary>
    /// Driving Percentage Master Table.
    /// </summary>
    public class DrivingPercentage
    {
        public DrivingPercentage()
        {
            QuotationsMotorRequestVehicleDrivers = new HashSet<QuotationsMotorRequestVehicleDriver>();
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
        public ICollection<QuotationsMotorRequestVehicleDriver> QuotationsMotorRequestVehicleDrivers { get; set; }
    }
}
