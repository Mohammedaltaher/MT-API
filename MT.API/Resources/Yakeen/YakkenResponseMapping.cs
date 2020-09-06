using AggriPortal.API.Contracts.Response;
using AggriPortal.API.Domain.Models;

namespace  AggriPortal.API.Resources
{
    public class YakkenClientMapping : BaseResponse
    {
        //public Client Client { get; set; }
    }

    public class YakkenVehicleDriverMapping : BaseResponse
    {
        public QuotationsMotorRequestVehicleDriver VehicleDriver { get; set; }
    }

    public class YakkenClientVehicleMapping : BaseResponse
    {
        public ClientVehicle ClientVehicle { get; set; }
    }
}
