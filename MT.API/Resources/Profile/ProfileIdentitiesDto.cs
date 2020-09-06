using AggriPortal.API.Contracts.Response;
using System;
using System.Collections.Generic;

namespace  AggriPortal.API.Resources
{
    public class ProfileIdentitiesResponse : BaseResponse
    {
        public IEnumerable<ProfileIdentitiesDto> Data { get; set; }
        public ProfileIdentitiesResponse()
        {
            Data = new List<ProfileIdentitiesDto>();
        }
    }

    /// <summary>
    /// 
    /// </summary>
    public class ProfileIdentitiesDto
    {
        public Guid ClientId { get; set; }
        public long IdentityNumber { get; set; }
        public string FullName { get; set; }
        public string FullNameAr { get; set; }
        public string BirthDate { get; set; }
    }
}
