using System.Collections.Generic;

namespace  AggriPortal.API.Domain.Models
{
    public class Relation
    {
        public Relation()
        {
            QuotationsMotorRequestVehicleDrivers = new HashSet<QuotationsMotorRequestVehicleDriver>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public string NameAr { get; set; }
        public ICollection<QuotationsMotorRequestVehicleDriver> QuotationsMotorRequestVehicleDrivers { get; set; }
    }
}
