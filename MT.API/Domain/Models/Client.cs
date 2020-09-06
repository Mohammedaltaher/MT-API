using System;
using System.Collections.Generic;

namespace  AggriPortal.API.Domain.Models
{
    public class Client
    {
        public Client()
        {
            Id = Guid.NewGuid();
            CreatedDate = DateTime.Now;
            ClientVehicles = new HashSet<ClientVehicle>();
            QuotationsMotorRequests = new HashSet<QuotationsMotorRequest>();
            ClientQuotationMotors = new HashSet<ClientQuotationMotor>();
            Policies = new HashSet<PoliciesMotor>();
            PolicyRequests = new HashSet<PolicyRequest>();
            ClientPayments = new HashSet<ClientPayment>();
        }
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string FirstNameAr { get; set; }
        public string MiddleNameAr { get; set; }
        public string LastNameAr { get; set; }
        public int IdentityTypeId { get; set; }
        public long IdentityNumber { get; set; }
        public int? IdentityIssuePlaceId { get; set; }
        public string BirthDate { get; set; }
        public string GenderId { get; set; }
        public int? NationalityId { get; set; }
        public int? SocialStatusId { get; set; }
        public int? OccupationId { get; set; }
        public int? EducationLevelId { get; set; }
        public int? ChildrenUnder16Years { get; set; }
        public int? BuildingNumber { get; set; }
        public string Street { get; set; }
        public string District { get; set; }
        public string SaudiAddressCity { get; set; }
        public int? PostalCode { get; set; }
        public int? AdditionalNumber { get; set; }
        public int? WorkCityId { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string IBAN { get; set; }
        public string ApplicationUserId { get; set; }
        public DateTime CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public IdentityType IdentityType { get; set; }
        public Gender Gender { get; set; }
        public City IdentityIssuePlace { get; set; }
        public City WorkCity { get; set; }
        public Country Nationality { get; set; }
        public SocialStatus SocialStatus { get; set; }
        public EducationLevel EducationLevel { get; set; }
        public ApplicationUser ApplicationUser { get; set; }

        public ICollection<ClientVehicle> ClientVehicles { get; set; }
        public ICollection<QuotationsMotorRequest> QuotationsMotorRequests { get; set; }
        public ICollection<ClientQuotationMotor> ClientQuotationMotors { get; set; }
        public ICollection<PoliciesMotor> Policies { get; set; }
        public ICollection<PolicyRequest> PolicyRequests { get; set; }
        public ICollection<ClientPayment> ClientPayments { get; set; }
        public ICollection<Ticket> Tickets { get; set; }

    }
}
