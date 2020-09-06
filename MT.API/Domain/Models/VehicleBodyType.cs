using System.Collections.Generic;

namespace  AggriPortal.API.Domain.Models
{
    public class VehicleBodyType
    {
        public VehicleBodyType()
        {
            ClientVehicles = new HashSet<ClientVehicle>();
            QuotationsMotorRequests = new HashSet<QuotationsMotorRequest>();

        }
        public int Id { get; set; }
        public string Name { get; set; }
        public string NameAr { get; set; }
        public ICollection<ClientVehicle> ClientVehicles { get; set; }
        public ICollection<QuotationsMotorRequest> QuotationsMotorRequests { get; set; }

    }
}
