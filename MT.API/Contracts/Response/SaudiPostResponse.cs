using System.Collections.Generic;

namespace  AggriPortal.API.Contracts.Response
{

    public class SaudiPostResponse : BaseResponse
    {
        public SaudiPostInfo Data { get; set; }
    }

    public class AllSaudiPostResponse : BaseResponse
    {
        public AllSaudiPostResponse()
        {
            Data = new List<SaudiPostInfo>();
        }
        public List<SaudiPostInfo> Data { get; set; }
    }

    public class SaudiPostInfo
    {
        public long InsuredId { get; set; }
        public int? BuildingNumber { get; set; }
        public string Street { get; set; }
        public string District { get; set; }
        public string City { get; set; }
        public int? PostalCode { get; set; }
        public int? AdditionalNumber { get; set; }
    }
}
