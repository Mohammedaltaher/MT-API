using AggriPortal.API.Contracts.Response;

namespace  AggriPortal.API.Resources
{
    public class AccessTokenDto : BaseResponse
    {
        public string AccessToken { get; set; }
        public string RefreshToken { get; set; }
        public long Expiration { get; set; }
    }
}
