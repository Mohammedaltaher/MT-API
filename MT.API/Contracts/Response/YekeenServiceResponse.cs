using AggriPortal.API.Domain.ServiceModels;
using System.Collections.Generic;

namespace  AggriPortal.API.Contracts.Response
{
    public class YakeenInsuredInfoResponse: BaseResponse
    {
        public YakeenInsuredInfo Data { get; set; }
    }
    public class AllYakeenInsuredInfoResponse : BaseResponse
    {
        public AllYakeenInsuredInfoResponse()
        {
            Data = new List<YakeenInsuredInfo>();
        }
        public List<YakeenInsuredInfo> Data { get; set; }
        
    }

    public class AllYakeenVehicleInfoResponse:BaseResponse
    {
        public AllYakeenVehicleInfoResponse()
        {
            Data = new List<YakeenVehicleInfo>();
        }
        public List<YakeenVehicleInfo> Data { get; set; }
    }
    public class YakeenVehicleInfoResponse:BaseResponse
    {
        public YakeenVehicleInfo Data { get; set; }
    }
}
