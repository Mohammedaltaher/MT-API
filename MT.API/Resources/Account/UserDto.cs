
using AggriPortal.API.Contracts.Response;
using System;
using System.Collections.Generic;

namespace  AggriPortal.API.Resources
{
    public class UserRequestDto
    {

        public string FullName { get; set; }
        public string FullNameAr { get; set; }
        public string Email { get; set; }
        public DateTime? DateFrom { get; set; }
        public DateTime? DateTo { get; set; }
        public bool? IsActive { get; set; }
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
    }
    public  class UserResponseDto : BaseResponse
    {
        public IEnumerable<ApplicationUserDto> Data { get; set; }
        public bool CanViewDetails { get; set; }
        public int? TotalRecord { get; set; }

    }
    public class ClientsDetailsResponseDto : BaseResponse
    {
        public ApplicationUserDto Data { get; set; }
        public bool CanUpdateAccount { get; set; }

    }
    public class EmployeeDetailsResponseDto : BaseResponse
    {
        public ApplicationUserDto Data { get; set; }
        public IEnumerable<UserClaimsDto> Permissions { get; set; }
        public bool CanUpdateAccount { get; set; }

    }
    public class ApplicationUserDto
    {
        public string Id { get; set; }
        public string FullName { get; set; }
        public string FullNameAr { get; set; }
        public DateTime CreatedDate { get; set; }
        public bool IsActive { get; set; }
        public string DefaultLang { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public bool EmailConfirmed { get; set; }
        public string PhoneNumber { get; set; }
        public bool PhoneNumberConfirmed { get; set; }

    }
}
