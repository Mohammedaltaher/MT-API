
using AggriPortal.API.Contracts.Response;
using System.Collections.Generic;

namespace  AggriPortal.API.Resources
{
    public class UserClaimsResponseDto :BaseResponse
    {
        public IEnumerable<UsersDtos> users { get; set; }
        public int? TotalRecord { get; set; }

    }
    public class UserClaimsDto
    {
        public string ClaimType { get; set; }
        public string ClaimValue { get; set; }
    }

    public class UsersDtos
    {
        public string Id { get; set; }
        public string UserName { get; set; }
        public IEnumerable<UserClaimsDto> Permissions { get; set; }
    }
}

