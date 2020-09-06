using System.Collections.Generic;

namespace  AggriPortal.API.Domain.Models
{
    public class VehicleMaker
    {
        public VehicleMaker()
        {
            VehicleModels = new HashSet<VehicleModel>();
            ClientVehicles = new HashSet<ClientVehicle>();
            QuotationsMotorRequests = new HashSet<QuotationsMotorRequest>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public string NameAr { get; set; }
        public string Logo { get; set; }
        public ICollection<VehicleModel> VehicleModels { get; set; }
        public ICollection<ClientVehicle> ClientVehicles { get; set; }
        public ICollection<QuotationsMotorRequest> QuotationsMotorRequests { get; set; }

    }
}
