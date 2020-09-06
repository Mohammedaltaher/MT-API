using System;
using System.Collections.Generic;

namespace  AggriPortal.API.Domain.Models
{
    public class QuotationsMotorRequestVehicleDriver
    {
        public QuotationsMotorRequestVehicleDriver()
        {
            Id = Guid.NewGuid();
            CreatedDate = DateTime.Now;
            QuotationsMotorRequestVehicleDriverAccidents = new HashSet<QuotationsMotorRequestVehicleDriverAccident>();
            QuotationsMotorRequestVehicleDriverLicenses = new HashSet<QuotationsMotorRequestVehicleDriverLicense>();
        }
        public Guid Id { get; set; }
        public Guid QuotationRequestId { get; set; }
        public int TypeId { get; set; }
        public long IdentityNumber { get; set; }
        public string BirthDate { get; set; }
        public int? NationalityId { get; set; }
        public string GenderId { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string FirstNameAr { get; set; }
        public string MiddleNameAr { get; set; }
        public string LastNameAr { get; set; }
        public int? OccupationId { get; set; }
        public string OccupationName { get; set; }
        public int? DrivingPercentageId { get; set; }
        public int? EducationLevelId { get; set; }
        public int? SocialStatusId { get; set; }
        public int? ChildrenUnder16Years { get; set; }
        public int? RelationId { get; set; }
        /// <summary>
        /// Insert medical condition Id as 1,2,3
        /// </summary>
        public string MedicalConditions { get; set; }

        /// <summary>
        /// Insert drivir violation Id as 1,2,3
        /// </summary>
        public string DriverViolations { get; set; }
        public int? HomeCityId { get; set; }
        public int? NumberOfAccidentsLast5Years { get; set; }
        public int? NumberOfClaimsLast5Years { get; set; }
        public int? NCDFreeYearsId { get; set; }
        public string NCDReference { get; set; }
        public DateTime CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public Gender Gender { get; set; }
        public NCDFreeYear NCDFreeYear { get; set; }
        public DrivingPercentage DrivingPercentage { get; set; }
        public EducationLevel EducationLevel { get; set; }
        public Relation Relation { get; set; }
        public QuotationsMotorRequest QuotationsMotorRequest { get; set; }
        public ICollection<QuotationsMotorRequestVehicleDriverAccident> QuotationsMotorRequestVehicleDriverAccidents { get; private set; }
        public ICollection<QuotationsMotorRequestVehicleDriverLicense> QuotationsMotorRequestVehicleDriverLicenses { get; private set; }
    }

    public class QuotationsMotorRequestVehicleDriverAccident
    {
        public QuotationsMotorRequestVehicleDriverAccident()
        {
            Id = Guid.NewGuid();
            CreatedDate = DateTime.Now;
        }
        public Guid Id { get; set; }
        public Guid VehicleDriverId { get; set; }
        public string CaseNumber { get; set; }
        public DateTime? AccidentDate { get; set; }
        public string Liability { get; set; }
        public string CityName { get; set; }
        public string DriverAge { get; set; }
        public string CarModel { get; set; }
        public string CarType { get; set; }
        public string DriverID { get; set; }
        public string SequenceNumber { get; set; }
        public string OwnerID { get; set; }
        public string EstimatedAmount { get; set; }
        public string DamageParts { get; set; }
        public string CauseOfAccident { get; set; }
        public DateTime CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public QuotationsMotorRequestVehicleDriver QuotationsMotorRequestVehicleDriver { get; set; }
    }

    /// <summary>
    /// Driver License Param
    /// </summary>
    public class QuotationsMotorRequestVehicleDriverLicense
    {
        /// <summary>
        /// From master table.
        /// </summary>
        ///

        public QuotationsMotorRequestVehicleDriverLicense()
        {
            Id = Guid.NewGuid();
            CreatedDate = DateTime.Now;
        }
        public Guid Id { get; set; }
        public int LicenseTypeId { get; set; }
        public int? CountryId { get; set; }
        public int? NumberOfYears { get; set; }
        public bool IsSaudiLicense { get; set; }
        public Guid VehicleDriverId { get; set; }
        /// <summary>
        /// From master table.
        /// </summary>
        /// <summary>
        /// Required if LicenseCountryCode is (113 - Saudi)
        /// License Expiry Date In Hijri
        /// (Format: dd-MM-yyyy) 
        /// </summary>
        public string LicenseExpiryDate { get; set; }
        public DateTime CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public QuotationsMotorRequestVehicleDriver QuotationsMotorRequestVehicleDriver { get; set; }
        public LicenseType LicenseType { get; set; }
        public Country Country { get; set; }
    }

}
