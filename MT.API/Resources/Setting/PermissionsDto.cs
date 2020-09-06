
using AggriPortal.API.Contracts.Response;
using System.Collections.Generic;

namespace  AggriPortal.API.Resources
{
    public class PermissionsResponseDto : BaseResponse
    {
        public IEnumerable<PermissionsDto> Data { get; set; }
        public int? TotalRecord { get; set; }

    }
    public class PermissionsDto
    {
        public string Name { get; set; }
        public string ClaimType { get; set; }
        public string CalimValue { get; set; }
    }
}

