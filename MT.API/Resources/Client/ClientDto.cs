
using AggriPortal.API.Contracts.Response;
using System;
using System.Collections.Generic;

namespace  AggriPortal.API.Resources
{
    public class ClientRequestDto
    {
        public string Name { get; set; }
        public string BirthDate { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public long? IdentityNumber { get; set; }
        public int? IdentityTypeId { get; set; }
        public int? NationalityId { get; set; }
        public int? EducationLevelId { get; set; }
        public DateTime? DateFrom { get; set; }
        public DateTime? DateTo { get; set; }
        public int? PageNumber { get; set; }
        public int? PageSize { get; set; }
    }
    public class ReminderRequestDto
    {
        public Guid  ClientId { get; set; }
        // 0 for Email
        // 1 for Sms
        public string MessageType { get; set; }
        public string Message { get; set; }
        
    }
    public  class ClientResponseDto : BaseResponse
    {
        public IEnumerable<ClientDto> Data { get; set; }
        public bool CanViewClient { get; set; }
        public int? TotalRecord { get; set; }


    }
    public class ClientDetailsResponseDto : BaseResponse
    {
        public ClientDto Data { get; set; }
        public bool CanUpdateClient { get; set; }
        public bool CanManageClientPayments { get; set; }

    }
    public class ClientDto
    {
        //client
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string FirstNameAr { get; set; }
        public string MiddleNameAr { get; set; }
        public string LastNameAr { get; set; }
        public string BirthDate { get; set; }

        //Identity
        public string IdentityTypeName { get; set; }
        public string IdentityTypeNameAr { get; set; }
        public long IdentityNumber { get; set; }
        public string IdentityIssuePlaceName { get;  set; }
        public string IdentityIssuePlaceNameAr { get;  set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }

        //gender
        public string GenderName { get; set; }
        public string GenderNameAr { get; set; }

        //Nationality
        public string NationalityName { get; set; }
        public string NationalityNameAr { get; set; }

        //SocialStatus
        public string SocialStatusName { get; set; }
        public string SocialStatusNameAr { get; set; }

        //Occupation
        public string OccupationName { get; set; }
        public string OccupationNameAr { get; set; }

        //EducationLevel
        public string EducationLevelName { get; set; }
        public string EducationLevelNameAr { get; set; }

        //address
        public string Street { get; set; }
        public string District { get; set; }
        public string SaudiAddressCity { get; set; }
        public int? PostalCode { get; set; }
        public int? AdditionalNumber { get; set; }
        public string WorkCityName { get; set; }
        public string WorkCityNameAr { get; set; }
       
       //count
        public int? TotalPolicies { get;  set; }
        public int? TotalPreviewedQuotes { get;  set; }
        public int? TotalSavedQuotes { get;  set; }

        //others
        public string IBAN { get; set; }
        public DateTime CreatedDate { get; set; }
        public string CreatedBy { get; set; }
    }
}
