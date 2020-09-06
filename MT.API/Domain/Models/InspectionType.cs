using System.Collections.Generic;

namespace  AggriPortal.API.Domain.Models
{
    /// <summary>
    /// This indicates what kind of inspection IC wants to apply for this vehicle
    /// </summary>
    public class InspectionType
    {
        public InspectionType()
        {
            QuotationsMotorResponseProducts = new HashSet<QuotationsMotorResponseProduct>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public string NameAr { get; set; }
        public ICollection<QuotationsMotorResponseProduct> QuotationsMotorResponseProducts { get; set; }
    }
}
