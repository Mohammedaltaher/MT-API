using System;
using System.Collections.Generic;

namespace  AggriPortal.API.Contracts.Request
{
    public class Driver
    {
        /// <summary>
        /// Driver type Id 
        /// <list type="bullet">
        /// <item><description>1: Main Driver</description></item>
        /// <item><description>2: Additional Driver</description></item>
        /// </list>
        /// </summary>
        public int TypeId { get; set; }

        /// <summary>
        /// Driver identity card number.
        /// </summary>
        public long IdentityNumber { get; set; }

        /// <summary>
        /// Driver Birth Date
        /// </summary>
        public string BirthDate { get; set; }

        /// <summary>
        /// Driver Nationality Id.
        /// <para>Value from lookup table</para>
        /// </summary>
        public int? NationalityId { get; set; }

        /// <summary>
        /// Driver gender
        /// <list type="bullet">
        /// <item><description>M: Male</description></item>
        /// <item><description>F: Female</description></item>
        /// </list>
        /// </summary>
        public string GenderId { get; set; }

        /// <summary>
        /// Driver name in english (First, Middle, Last)
        /// </summary>
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }

        /// <summary>
        /// Driver name in arabic (First, Middle, Last).
        /// </summary>
        public string FirstNameAr { get; set; }
        public string MiddleNameAr { get; set; }
        public string LastNameAr { get; set; }

        /// <summary>
        /// Driver occupation Id.
        /// <para>Value from lookup table.</para>
        /// </summary>
        public int? OccupationId { get; set; }
        public string Occupation { get; set; }

        /// <summary>
        /// Driving percentage Id.
        /// <para>Value from 'DrivingPercentage' lookup table</para>
        /// </summary>
        public int? DrivingPercentageId { get; set; }

        /// <summary>
        /// Driver education level Id.
        /// <para>Value from 'EducationLevel' lookup table.</para>
        /// </summary>
        public int EducationLevelId { get; set; }

        /// <summary>
        /// Driver medical condition Id.
        /// <para>Value from 'MedicalCondition' lookup table.</para>
        /// </summary>
        public List<DriverMedicalCondition> MedicalConditions { get; set; }

        public int? SocialStatusId { get; set; }
        /// <summary>
        /// Number of children under 16 years
        /// </summary>
        public int? ChildrenUnder16Years { get; set; }

        public int? RelationId { get; set; }
        /// <summary>
        /// Driver home city Id.
        /// <para>Value from 'Cities' lookup table.</para>
        /// </summary>
        public int? HomeCityId { get; set; }

        /// <summary>
        /// Number of accident in last 5 years.
        /// </summary>
        public int? NumberOfAccidentsLast5Years { get; set; }
        public int? NumberOfClaimsLast5Years { get; set; }
        public List<NajmAccidentDetails> NajmAccidentsDetails { get; set; }

        /// <summary>
        /// Number of 
        /// <para>Value from Najm</para>
        /// </summary>
        public int NCDFreeYears { get; set; }

        /// <summary>
        /// NCD reference.
        /// <para>Value from Najm.</para>
        /// </summary>
        public string NCDReference { get; set; }

        public List<DriverLicense> DriverLicenses { get; set; }

        public List<DriverViolation> DriverViolations { get; set; }

        public Driver()
        {
            DriverLicenses = new List<DriverLicense>();
            DriverViolations = new List<DriverViolation>();
            MedicalConditions = new List<DriverMedicalCondition>();
        }
    }

    public class NajmAccidentDetails
    {
        public string CaseNumber { get; set; }
        public DateTime AccidentDate { get; set; }
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
    }

    /// <summary>
    /// Driver License Param
    /// </summary>
    public class DriverLicense
    {
        /// <summary>
        /// From master table.
        /// </summary>
        public int LicenseTypeId { get; set; }
        public int CountryId { get; set; }
        public int? NumberOfYears { get; set; }
        /// <summary>
        /// From master table.
        /// </summary>
        /// <summary>
        /// Required if LicenseCountryCode is (113 - Saudi)
        /// License Expiry Date In Hijri
        /// (Format: dd-MM-yyyy) 
        /// </summary>
        public string LicenseExpiryDate { get; set; }
        public bool IsSaudiLicense { get; set; }

    }

    /// <summary>
    /// Driver Violation Param
    /// </summary>
    public class DriverViolation
    {
        public int ViolationId { get; set; }
    }

    public class DriverMedicalCondition
    {
        public int MedicalConditionId { get; set; }
    }

}
