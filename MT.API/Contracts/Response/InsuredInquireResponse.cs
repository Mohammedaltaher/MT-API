using System;

namespace  AggriPortal.API.Contracts.Response
{
    public class GetInsuredByIdResponse : BaseResponse  
    {
        public InsuredInfo Data { get; set; }
    }
    public class InsuredInfo
    {
        public Guid ReferenceId { get; set; }
        public long IdentityNumber { get; set; }
        public int? InsuredNationalityId { get; set; }
        public int? IdentityIssuePlaceId { get; set; }
        public string FirstNameAr { get; set; }
        public string MiddleNameAr { get; set; }
        public string LastNameAr { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
    }
}
