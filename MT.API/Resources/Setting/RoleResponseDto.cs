
using AggriPortal.API.Contracts.Response;
using System.Collections.Generic;

namespace  AggriPortal.API.Resources
{
    public class RoleResponseDto :BaseResponse
    {
        public IEnumerable<RoleDto> Data { get; set; }
        public int? TotalRecord { get; set; }

    }
    public class RoleDto
    {
        public string Id { get; set; }
        public string Name { get; set; }
    }
}

