using System.Collections.Generic;

namespace  AggriPortal.API.Domain.Models
{
    public class VehicleModel
    {
        public VehicleModel()
        {
            ClientVehicles = new HashSet<ClientVehicle>();
            QuotationsMotorRequests = new HashSet<QuotationsMotorRequest>();

        }
        public int Id { get; set; }
        public string Name { get; set; }
        public string NameAr { get; set; }
        public string ElmModelCode { get; set; }
        public int VehicleMakerId { get; set; }
        public VehicleMaker VehicleMaker { get; set; }
        public ICollection<ClientVehicle> ClientVehicles { get; set; }
        public ICollection<QuotationsMotorRequest> QuotationsMotorRequests { get; set; }

    }
}
